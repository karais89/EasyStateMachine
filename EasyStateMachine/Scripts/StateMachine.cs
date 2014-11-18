//-----------------------------------------------------------------------
// <copyright file="StateMachine.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine
{
    using UnityEngine;
    using System.Collections.Generic;

    /// Represents the state machine.
    public class StateMachine : VariablesStorage
    {
#pragma warning disable 0649
        /// List of states in state machine.
        [SerializeField, HideInInspector]
        List<State> states = new List<State> ();

        /// Starting state.
        [SerializeField]
        State startingState;
#pragma warning restore 0649

        /// Gets starting state.
        public State StartingState { get { return startingState; } }

        /// Currently active state.
        State current;

        /// Gets current state.
        public State Current { get { return current; } }

        /// Initialization.
        void Start()
        {
            Reset ();
        }

        /// Resets the state machine.
        public void Reset()
        {
            Transit (StartingState);
        }

        /// Transits the state machine to te specified state.
        public void Transit(State next)
        {
            if (current != null) 
                current.Exit ();

            current = next;
            if (current != null) 
            {
#if UNITY_EDITOR
                if( this != current.StateMachine)
                    Debug.LogWarning("State machine " + Info + " has entered the state " + current.Info + ", which does not belong to this state machine. Behaviour is undefined.");
#endif

                current.Enter ();
            }
        }

#if UNITY_EDITOR
        /// Gets the states info.
        public string StatesInfo
        {
            get
            {
                if(states == null || states.Count <= 0)
                    return "State machine has no states";

                return "States:\n" + GetInfo(states);
            }
        }

        /// Adds states to the state machine.
        public void SetStateMachineToStates()
        {
            states.Clear ();
            if(StartingState != null)
                StartingState.SetStateMachine (states, this);
        }
#endif
    }
}