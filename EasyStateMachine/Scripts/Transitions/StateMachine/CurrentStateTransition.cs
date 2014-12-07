//-----------------------------------------------------------------------
// <copyright file="CurrentStateTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Transitions.StateMachine
{
    using UnityEngine;

    /// Transits if the specified state machine is in the specified state.
    [AddComponentMenu("Easy State Machine/Transitions/State Machine/Current State")]
    public sealed class CurrentStateTransition : Transition
    {
        #region Input
#pragma warning disable 0649
        /// State machine.
        [Header("if state machine")]
        [SerializeField, Tooltip("Specify the state machine.")]
        EasyStateMachine.StateMachine reference;

        /// State machine tag.
        [SerializeField, Tooltip("Specify the state machine tag.")]
        string _tag;

        /// State machine name.
        [SerializeField, Tooltip("Specify the state machine name.")]
        string _name;

        /// State.
        [Header("is in the state")]
        [SerializeField, Tooltip("Specify the state.")]
        State _reference;

        /// State tag.
        [SerializeField, Tooltip("Specify the state tag.")]
        string stateTag;

        /// State name.
        [SerializeField, Tooltip("Specify the state name.")]
        string stateName;

#pragma warning disable 1635
#pragma warning disable 0169
#pragma warning disable 0414
        /// Where the job should be done.
        [SerializeField, Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414
#pragma warning restore 0169
#pragma warning restore 1635
#pragma warning restore 0649
        #endregion

        /// Does the job.
        void Do()
        {
            var stateMachine = GetStateMachine();
            if (stateMachine == null)
                return;

            var state = GetState();
            if (state == null)
                return;

            var current = stateMachine.CurrentState;
            NeedTransit = ReferenceEquals(state, current);
        }

        /// Gets the state machine.
        EasyStateMachine.StateMachine GetStateMachine()
        {
            if (reference != null)
                return reference;

            var stateMachine = GetByTag();
            return (stateMachine == null) ? GetByName() : stateMachine;
        }

        /// Gets the state machine by tag.
        EasyStateMachine.StateMachine GetByTag()
        {
            if (string.IsNullOrEmpty(_tag))
                return null;

            var go = GameObject.FindGameObjectWithTag(_tag);
            if (go == null)
                return null;

            var stateMachine = go.GetComponent<EasyStateMachine.StateMachine>();
            return (stateMachine != null) ? stateMachine : null;
        }

        /// Gets the state machine by name.
        EasyStateMachine.StateMachine GetByName()
        {
            if (string.IsNullOrEmpty(_name))
                return null;

            var go = GameObject.Find(_name);
            if (go == null)
                return null;

            var stateMachine = go.GetComponent<EasyStateMachine.StateMachine>();
            return (stateMachine != null) ? stateMachine : null;
        }

        /// Gets the state.
        State GetState()
        {
            if (_reference != null)
                return _reference;

            var state = GetStateByTag();
            return (state == null) ? GetStateByName() : state;
        }

        /// Gets the state by tag.
        State GetStateByTag()
        {
            if (string.IsNullOrEmpty(stateTag))
                return null;

            var go = GameObject.FindGameObjectWithTag(stateTag);
            if (go == null)
                return null;

            var state = go.GetComponent<State>();
            return (state != null) ? state : null;
        }

        /// Gets the state by name.
        State GetStateByName()
        {
            if (string.IsNullOrEmpty(stateName))
                return null;

            var go = GameObject.Find(stateName);
            if (go == null)
                return null;

            var state = go.GetComponent<State>();
            return (state != null) ? state : null;
        }
    }
}
