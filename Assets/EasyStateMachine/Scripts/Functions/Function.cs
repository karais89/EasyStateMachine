//-----------------------------------------------------------------------
// <copyright file="Function.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine
{
    using UnityEngine;

    /// Represents the base class for Functions.
    /// IMPORTANT NOTE: all Functions should be disabled in Inspector.
    public abstract class Function : BaseForFunctions
    {
        [SerializeField, Tooltip("Current State of the Function. The Function will be executed in this State only.")]
        State state = null;

        [SerializeField, Tooltip("Functions with higher priority are called first.")]
        int priority = 0;

        public State State { get { return state; } }
        public int Priority { get { return priority; } }

        /// Gets the value of the specified variable. 
        /// Returns true if succeeded, false otherwise.
        protected bool TryGet<T>(bool global, string variable, out T value, T @default)
        {
            value = @default;
            if (string.IsNullOrEmpty(variable))
                return false;

            var storage = GetStorage(global);
            if (storage == null)
                return false;

            var result = storage.Get<T>(variable);
            if (result == null)
                return false;

            value = (T)result;
            return true;
        }
       
        /// Sets the value of the specified variable.
        /// Returns true if succeeded, false otherwise.
        protected bool TrySet<T>(bool global, string variable, T value)
        {
            if (string.IsNullOrEmpty(variable))
                return false;

            var storage = GetStorage(global);
            if (storage == null)
                return false;

            storage.Set(variable, value);
            return true;
        }

        /// Gets the desired (global or local) storage of variables.
        protected BaseForStates GetStorage(bool global)
        {
            if (!global)
                return State;

            return State != null ? State.StateMachine : null;
        }
    }
}