//-----------------------------------------------------------------------
// <copyright file="TransitionEditor.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Editor
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEditor;

    /// Represents the Editor part of Transition.
    [CustomEditor(typeof(Transition), true)]
    public class TransitionEditor : EditorBase
    {
        #region Private
        /// Actual Transition.
        Transition transition;

        /// Previously set origin state.
        State previousState;

        /// Previously set destination state.
        State previousNext;

        /// Initialization.
        void OnEnable()
        {
            GetTarget(out transition);
            previousState = transition.State;
            previousNext = transition.To;
        }
        #endregion

        /// Updates the Transition Inspector GUI.
        public override void OnInspectorGUI()
        {
            GetTarget(out transition);
            DisableWhenNotPlaying(transition);
            DrawDefaultInspector();
            HandleChanges();
            DrawWarnings();
        }

        #region Private
        /// Handles GUI changes.
        void HandleChanges()
        {
            if (GUI.changed)
            {
                HandleNextChange();
                HandleCurrentChange();
                HandlePriorityChange();
            }
        }

        /// Handles destination state change.
        void HandleNextChange()
        {
            if (previousNext == transition.To)
                return;

            // Store state machines because component fields might be cleared.
            var previousCurrentStateMachine = GetStateMachineOfState(previousState);
            var previousNextStateMachine = GetStateMachineOfState(previousNext);
            ClearStateMachineForState(previousNext);
            previousNext = transition.To;
            RebuildStateMachine(previousCurrentStateMachine);
            if (previousCurrentStateMachine != previousNextStateMachine)
                RebuildStateMachine(previousNextStateMachine);
        }

        /// Handles origin state change.
        void HandleCurrentChange()
        {
            if (previousState == transition.State)
                return;

            // Store state machines because component fields might be cleared.
            var previousCurrentStateMachine = GetStateMachineOfState(previousState);
            var newCurrentStateMachine = GetStateMachineOfState(transition.State);
            RemoveTransitionFromState(transition, previousState);
            ClearStateMachineForState(previousNext);
            previousState = transition.State;
            AddTransitionToState(transition, previousState);
            RebuildStateMachine(newCurrentStateMachine);
            if (previousCurrentStateMachine != newCurrentStateMachine)
                RebuildStateMachine(previousCurrentStateMachine);
        }

        /// Handles priority change.
        void HandlePriorityChange()
        {
            var state = transition.State;
            if (state != null)
            {
                state.SortFunctions();
                EditorUtility.SetDirty(state);
            }
        }

        /// Gets the state machine from the specified state.
        static StateMachine GetStateMachineOfState(State state)
        {
            return (state == null) ? null : state.StateMachine;
        }

        /// Clears the state machine field of the specified state and all subsequent states.
        static void ClearStateMachineForState(State state)
        {
            if (state != null)
            {
                var processed = new List<State>();
                state.SetStateMachine(processed, null);
            }
        }

        /// Sets the specified state machine reference to all connected states.
        static void RebuildStateMachine(StateMachine stateMachine)
        {
            if (stateMachine != null)
                stateMachine.RebuildStateMachine();
        }

        /// Removes the specified transition from the specified state.
        static void RemoveTransitionFromState(Transition transition, State state)
        {
            if (state != null)
            {
                state.RemoveFunction(transition);
                EditorUtility.SetDirty(state);
            }
        }

        /// Adds the specified transition to the specified state.
        static void AddTransitionToState(Transition transition, State state)
        {
            if (state != null)
            {
                state.AddFunction(transition);
                EditorUtility.SetDirty(state);
            }
        }

        /// Shows warnings.
        void DrawWarnings()
        {
            if (transition.State == null)
                EditorGUILayout.HelpBox("Current state is not assigned.", MessageType.Warning);

            if (transition.To == null)
                EditorGUILayout.HelpBox("Next state is not assigned.", MessageType.Warning);
        }
        #endregion
    }
}