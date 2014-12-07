//-----------------------------------------------------------------------
// <copyright file="Function.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine
{
    using UnityEngine;

    /// Represents the base class for functions.
    /// !!! Functions should be disabled in Inspector.
    public abstract class Function : BaseForFunctions
    {
        #region Private
#pragma warning disable 0649
        /// The State this Function belongs to.
        [SerializeField, Tooltip("The State this Function belongs to.")]
        State _state;

        /// Functions with higher priority are called first in the State.
        [SerializeField, Tooltip("Functions with higher priority are called first in the State.")]
        int _priority;
#pragma warning restore 0649
        #endregion

        /// Gets the state.
        public State State { get { return _state; } }

        /// Gets the priority.
        public int Priority { get { return _priority; } }

        /// Gets the value of the specified variable. 
        /// Returns true, if succeeded, false otherwise.
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

        /// Sets the value to the specified variable.
        /// Returns true, if succeeded, false otherwise.
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

        /// Gets the actual variables storage.
        protected BaseForStates GetStorage(bool global)
        {
            if (!global)
                return State;

            return State != null ? State.StateMachine : null;
        }
    }
}