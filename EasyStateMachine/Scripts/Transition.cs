//-----------------------------------------------------------------------
// <copyright file="Transition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine
{
	using UnityEngine;

    /// Represents the base class for transitions.
    /// NOTE: derived classes should be disabled in Inspector.
    public abstract class Transition : Base
    {
        /// Origin.
        [SerializeField, Tooltip("Origin.")]
        State current;

        /// Gets current state.
        public State Current
        {
            get { return current; }
        }
      
        /// Destination.
        [SerializeField, Tooltip("Destination.")]
        State next;

        /// Gets next state.
        public State Next
        {
            get { return next; }
        }

        /// If true, transition should happen.
        bool needTransit;

        /// Set it to true when transition should happen.
        /// It is reset automatically when current state is entered.
        protected bool NeedTransit
        {
            get { return needTransit; }
            set 
            {
                needTransit = value;
                if(needTransit && Current != null && Current.StateMachine != null)
                    Current.StateMachine.Transit(Next);
            }
        }

        /// Enables transition and resets the NeedTransit property.
        public virtual void Enter()
        {
            if (!enabled) 
            {
                NeedTransit = false;
                enabled = true;
            }
        }

        /// Disables transition.
        public virtual void Exit()
        {
            if(enabled)
                enabled = false;
        }
    }
}