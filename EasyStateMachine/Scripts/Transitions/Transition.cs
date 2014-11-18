//-----------------------------------------------------------------------
// <copyright file="Transition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine
{
	using UnityEngine;

    /// Represents the base class for transitions.
    /// Transition is the special type of actions, 
    /// which could initiate the state change.
    /// Derived classes should be disabled in Inspector.
    public abstract class Transition : Action
    {
#pragma warning disable 0649
        /// Destination state.
        [SerializeField, Tooltip("Destination state.")]
        State next;
#pragma warning restore 0649

        /// Gets next state.
        public State Next { get { return next; } }

        /// If true, transition should happen.
        bool needTransit;

        /// Set it to true in derived classes when transition should happen.
        /// It is reset automatically when current state is entered.
        protected bool NeedTransit
        {
            get { return needTransit; }
            set 
            {
                needTransit = value;
                if (needTransit && State != null && State.StateMachine != null)
                    State.StateMachine.Transit(Next);
            }
        }

        /// Enables transition and resets the NeedTransit property.
        public override void Enter()
        {
            if (!enabled) 
            {
                NeedTransit = false;
                enabled = true;
            }
        }
    }
}