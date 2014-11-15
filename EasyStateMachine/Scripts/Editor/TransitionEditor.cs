//-----------------------------------------------------------------------
// <copyright file="TransitionEditor.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Editor
{
    using UnityEngine;
    using UnityEditor;

    /// Represents the editor part of Transition.
    [CustomEditor(typeof(Transition), true)]
    public class TransitionEditor : EditorBase 
    {
        /// Actual transition component.
        Transition transition;

        /// Previously set origin state.
        State previousCurrent;

        /// Previously set destination state.
        State previousNext;

        /// Initialization.
        void OnEnable()
        {
            GetTarget (out transition);
            previousCurrent = transition.Current;
            previousNext = transition.Next;
        }

        /// Updates the Transition inspector.
        public override void OnInspectorGUI()
        {
            GetTarget (out transition);
            DisableWhenNotPlaying (transition);
            DrawDefaultInspector ();
            HandleChanges ();
            DrawWarnings ();
        }

        /// Handles GUI changes.
        void HandleChanges()
        {
            if(GUI.changed)
            {
                HandleNextChange();
                HandleCurrentChange();
            }
        }

        /// Handles destination state change.
        void HandleNextChange()
        {
            if (previousNext == transition.Next) 
                return;

            // Store state machines because component fields might be cleared.
            var previousCurrentStateMachine = GetStateMachineOfState(previousCurrent); 
            var previousNextStateMachine = GetStateMachineOfState(previousNext);
            ClearStateMachineOfState(previousNext);
            previousNext = transition.Next;
            UpdateStateMachine(previousCurrentStateMachine); 
            if(previousCurrentStateMachine != previousNextStateMachine)
                UpdateStateMachine(previousNextStateMachine);
        }

        /// Handles origin state change.
        void HandleCurrentChange()
        {
            if (previousCurrent == transition.Current) 
                return;

            // Store state machines because component fields might be cleared.
            var previousCurrentStateMachine = GetStateMachineOfState(previousCurrent);
            var newCurrentStateMachine = GetStateMachineOfState(transition.Current);
            RemoveTransitionFromState(transition, previousCurrent);
            ClearStateMachineOfState(previousNext);
            previousCurrent = transition.Current;
            AddTransitionToState(transition, previousCurrent);
            UpdateStateMachine(newCurrentStateMachine);
            if(previousCurrentStateMachine != newCurrentStateMachine)
                UpdateStateMachine(previousCurrentStateMachine);
        }

        /// Gets the state machine from the specified state.
        static StateMachine GetStateMachineOfState(State state)
        {
            return (state == null) ? null : state.StateMachine;
        }

        /// Clears the state machine field of the specified state and subsequent states.
        static void ClearStateMachineOfState(State state)
        {
            if(state != null && state.StateMachine != null)
                StateMachineEditor.UpdateStateMachine(state, null);
        }

        /// Updates the specified state machine.
        static void UpdateStateMachine(StateMachine stateMachine)
        {
            if(stateMachine != null)
                StateMachineEditor.UpdateStateMachine(stateMachine.StartingState, stateMachine);
        }

        /// Removes the specified transition from the specified state.
        static void RemoveTransitionFromState(Transition transition, State state)
        {
            if (state != null) 
            {   
                state.RemoveTransition (transition);
                EditorUtility.SetDirty(state);
            }
        }

        /// Adds the specified transition to the specified state.
        static void AddTransitionToState(Transition transition, State state)
        {
            if(state != null)
            {
                state.AddTransition(transition);
                EditorUtility.SetDirty(state);
            }
        }

        /// Shows warnings.
        void DrawWarnings()
        {
            if(transition.Current == null)
                EditorGUILayout.HelpBox("Current state is not assigned.", MessageType.Warning);
            
            if(transition.Next == null)
                EditorGUILayout.HelpBox("Next state is not assigned.", MessageType.Warning);
        }
    }
}