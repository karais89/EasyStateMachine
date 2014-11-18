//-----------------------------------------------------------------------
// <copyright file="Action.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine
{
    using UnityEngine;

    /// Represents the base class for actions.
    /// Derived classes should be disabled in Inspector.
    public abstract class Action : ActionBase
    {
#pragma warning disable 0649
        /// Current state.
        [SerializeField, Tooltip("Current state.")]
        State state;
#pragma warning restore 0649

        /// Gets the state.
        public State State { get { return state; } }

        /// Enables action.
        public virtual void Enter()
        {
            if(!enabled)
                enabled = true;
        }

        /// Disables action.
        public virtual void Exit()
        {
            if(enabled)
                enabled = false;
        }

        /// Gets the actual variables storage. Is called by the base class.
        protected sealed override VariablesStorage GetVariablesStorage(bool global)
        {
            if (!global)
                return State;

            return State != null ? State.StateMachine : null;
        }
    }
}