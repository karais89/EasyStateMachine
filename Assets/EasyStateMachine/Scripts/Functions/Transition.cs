//-----------------------------------------------------------------------
// <copyright file="Transition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine
{
    using UnityEngine;

    /// Represents the base class for Transitions. Transition is the 
    /// special kind of Function, that could initiate a state change.
    /// IMPORTANT NOTE: all Transitions should be disabled in Inspector.
    public abstract class Transition : Function
    {
        [Header("Transit"), SerializeField, Tooltip("Destination State of the Transition. The Transition will transit to this State only.")]
        State to = null;

        bool needTransit;

        // Gets the destination State.
        public State To { get { return to; } }

        /// Set this property to true, when the Transition should happen.
        /// This property is reset automatically when the State is entered.
        protected bool NeedTransit
        {
            get { return needTransit; }
            set
            {
                needTransit = value;
                if (needTransit && State != null && State.StateMachine != null)
                    State.StateMachine.Transit(To);
            }
        }

        /// Enables Transition and resets the NeedTransit property.
        public override void Enter()
        {
            if (enabled)
                return;

            NeedTransit = false;
            enabled = true;
        }
    }
}