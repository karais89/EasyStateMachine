//-----------------------------------------------------------------------
// <copyright file="Transition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine
{
    using UnityEngine;

    /// Represents the base class for Transitions.
    /// Transition is special type of Functions, 
    /// which could initiate the state change.
    /// !!! Transitions should be disabled in Inspector.
    public abstract class Transition : Function
    {
        #region Private
#pragma warning disable 0649
        /// The state this Transition transits to.
        [Header("Transit"), SerializeField, Tooltip("The state this Transition transits to.")]
        State _to;
#pragma warning restore 0649

        /// If true, transition should happen.
        bool _needTransit;
        #endregion

        /// Gets next state.
        public State To { get { return _to; } }

        /// Set it to true in derived classes when transition should happen.
        /// It is reset automatically when current state is entered.
        protected bool NeedTransit
        {
            get { return _needTransit; }
            set
            {
                _needTransit = value;
                if (_needTransit && State != null && State.StateMachine != null)
                    State.StateMachine.Transit(To);
            }
        }

        /// Enables transition and resets the NeedTransit property.
        public override void Enter()
        {
            if (enabled)
                return;

            NeedTransit = false;
            enabled = true;
        }
    }
}