//-----------------------------------------------------------------------
// <copyright file="CurrentStateTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.StateMachine.Transitions
{
    using UnityEngine;

    /// Transits if the specified StateMachine is in the desired State.
    [AddComponentMenu("Easy State Machine/Functions/State Machine/Transitions/Current State")]
    public sealed class CurrentStateTransition : Transition
    {
        [Header("if the state machine, identified by")]
        [SerializeField]
        EasyStateMachine.StateMachine reference = null;

        [SerializeField]
        string orTag = null;

        [SerializeField]
        string orName = null;

        [Header("is in the state, identified by")]
        [SerializeField]
        State _reference = null;

        [SerializeField]
        string _orTag = null;

        [SerializeField]
        string _orName = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414

        void Do()
        {
            var stateMachine = Get<EasyStateMachine.StateMachine>(reference, orTag, orName);
            if (stateMachine == null)
                return;

            var state = Get<State>(_reference, _orTag, _orName);
            if (state == null)
                return;

            var current = stateMachine.CurrentState;
            NeedTransit = ReferenceEquals(state, current);
        }
    }
}
