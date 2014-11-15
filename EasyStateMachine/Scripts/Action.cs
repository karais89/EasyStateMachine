//-----------------------------------------------------------------------
// <copyright file="Action.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine
{
    using UnityEngine;

    /// Represents the base class for actions.
    public abstract class Action : Base
    {
        /// Action belongs to this state.
        [SerializeField]
        State state;

        /// Gets the state.
        public State State
        {
            get { return state; }
        }

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
    }
}
