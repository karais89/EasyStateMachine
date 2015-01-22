//-----------------------------------------------------------------------
// <copyright file="TransitionEditor.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Editor
{
    using UnityEngine;
    using UnityEditor;
    using System.Collections.Generic;

    /// Represents the Editor part of the Transition class.
    [CustomEditor(typeof(Transition), true)]
    public class TransitionEditor : EditorBase
    {
        Transition transition;
        State previousOriginState;
        State previousDestinationState;
        int previousPriority;

        void OnEnable()
        {
            GetTarget(out transition);
			previousOriginState = transition.State;
			previousDestinationState = transition.To;
            previousPriority = transition.Priority;
        }

        /// Is called when the user changes something in the UI.
        public override void OnInspectorGUI()
        {
            GetTarget(out transition);
            DisableWhenNotPlaying(transition);
            DrawDefaultInspector();
            HandleChanges();
            DrawWarnings();
        }

        void HandleChanges()
        {
            if (!GUI.changed)
                return;

            HandleDestinationStateChange ();
            HandleOriginStateChange ();
            HandlePriorityChange ();
        }

		void HandleDestinationStateChange()
        {
            // TODO: clear the To state, if it does not belong to the same state machine, as From, show OK messagebox.
			
            if (ReferenceEquals(previousDestinationState, transition.To))
                return;

            // Store the previous StateMachine of the origin State and 
            // previous StateMachine of the destination state, because 
            // Transition fields might be cleared.
			var previousOriginStateMachine = GetStateMachineFromState(previousOriginState);
			var previousDestinationStateMachine = GetStateMachineFromState(previousDestinationState);

            // Clear the StateMachine reference from all subsequent States (starting 
            // from the previous destination State).
			ClearStateMachineForState(previousDestinationState);

            // Store the current destination State of the Transition 
            // as the previous destination State.
			previousDestinationState = transition.To;

            // Rebuild/reconnect the StateMachine, to which the Transition still belongs.
            RebuildStateMachine(previousOriginStateMachine);

            // If the previous destination StateMachine differs from the previous origin,
            // StateMachine, rebuild/reconnect the destination StateMachine too.
            if (!ReferenceEquals(previousDestinationStateMachine, previousOriginStateMachine))
                RebuildStateMachine(previousDestinationStateMachine);
        }

        void HandleOriginStateChange()
        {
            // TODO: clear the To state, if it does not belong to the same state machine, as new From. Show YES/NO messagebox.

			if (ReferenceEquals(previousOriginState, transition.State))
                return;

            // Store the previous and new StateMachines of the origin State, 
            // because Transition field might be cleared.
			var previousOriginStateMachine = GetStateMachineFromState(previousOriginState);
            var newOriginStateMachine = GetStateMachineFromState(transition.State);

            // Remove the Transition from its previous origin State and then clear
            // the StateMachine reference from all subsequent States (starting 
            // from its previous destination State).
			RemoveTransitionFromState(transition, previousOriginState);
			ClearStateMachineForState(previousDestinationState);

            // Store the current origin State of the Transition as the previous 
            // origin State and add this Transition to its new State.
			previousOriginState = transition.State;
			AddTransitionToState(transition, transition.State);

            // Rebuild/reconnect the StateMachine, to which the Transition belongs from now.
            RebuildStateMachine(newOriginStateMachine);

            // If the StateMachine was changed, rebuild/reconnect previous StateMachine.
            if (!ReferenceEquals(previousOriginStateMachine, newOriginStateMachine))
                RebuildStateMachine(previousOriginStateMachine);
        }

        void HandlePriorityChange()
        {
            if (previousPriority == transition.Priority)
                return;

            var state = transition.State;
            if (state == null)
                return;

            state.SortFunctions();
            EditorUtility.SetDirty(state);
        }

        static StateMachine GetStateMachineFromState(State state)
        {
            return (state == null) ? null : state.StateMachine;
        }

        static void ClearStateMachineForState(State state)
        {
            if (state == null)
                return;
                
            // Clear the state machine field of the 
            // specified state and of all subsequent states.
            var processed = new List<State>();
            state.SetStateMachine(processed, null);
        }

        static void RebuildStateMachine(StateMachine stateMachine)
        {
            // If state machine exists, set the specified state 
            // machine reference to all connected states.
            if (stateMachine != null)
                stateMachine.RebuildStateMachine();
        }

        static void RemoveTransitionFromState(Transition transition, State state)
        {
            if (state == null)
                return;

            state.RemoveFunction(transition);
            EditorUtility.SetDirty(state);
        }

        static void AddTransitionToState(Transition transition, State state)
        {
            if (state == null)
                return;
            
            state.AddFunction(transition);
            EditorUtility.SetDirty(state);
        }

        void DrawWarnings()
        {
            if (transition.State == null)
                EditorGUILayout.HelpBox("Current state is not assigned.", MessageType.Warning);

            if (transition.To == null)
                EditorGUILayout.HelpBox("Next state is not assigned.", MessageType.Warning);
        }
    }
}