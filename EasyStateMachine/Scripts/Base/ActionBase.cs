//-----------------------------------------------------------------------
// <copyright file="ActionBase.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine
{
    using UnityEngine;

    /// Represents the access methods for variables.
    public abstract class ActionBase : Base
    {
        /// Where the storing should happen.
        /// Override it in children.
        protected abstract Where In { get; }

        /// Does the action when script gets enabled.
        void OnEnable()
        {
            if (In == Where.OnEnable)
                Do();
        }

        /// Does the action every frame.
        void Update()
        {
            if (In == Where.Update)
                Do();
        }

        /// Does the action every fixed framerate frame.
        void FixedUpdate()
        {
            if (In == Where.FixedUpdate)
                Do();
        }

        /// Does the action every frame after all Update functions have been called.
        void LateUpdate()
        {
            if (In == Where.LateUpdate)
                Do();
        }

        /// Does the actions when script gets disabled.
        void OnDisable()
        {
            if (In == Where.OnDisable)
                Do();
        }

        /// Does the action. 
        /// Override it in children.
        protected abstract void Do();

        /// Obtains the value of the specified variable.
        protected bool TryGet(string variable, bool global, out bool value)
        {
            var storage = GetVariablesStorage(global);
            if (storage != null)
                return storage.TryGet(variable, out value);

            value = false;
            return false;
        }

        /// Obtains the value of the specified variable.
        protected bool TryGet(string variable, bool global, out int value)
        {
            var storage = GetVariablesStorage(global);
            if (storage != null)
                return storage.TryGet(variable, out value);

            value = 0;
            return false;
        }

        /// Obtains the value of the specified variable.
        protected bool TryGet(string variable, bool global, out float value)
        {
            var storage = GetVariablesStorage(global);
            if (storage != null)
                return storage.TryGet(variable, out value);

            value = 0;
            return false;
        }

        /// Obtains the value of the specified variable.
        protected bool TryGet(string variable, bool global, out string value)
        {
            var storage = GetVariablesStorage(global);
            if (storage != null)
                return storage.TryGet(variable, out value);

            value = string.Empty;
            return false;
        }

        /// Obtains the value of the specified variable.
        protected bool TryGet(string variable, bool global, out object value)
        {
            var storage = GetVariablesStorage(global);
            if (storage != null)
                return storage.TryGet(variable, out value);

            value = null;
            return false;
        }

        /// Obtains the value of the specified variable.
        protected bool TryGet(string variable, bool global, out Vector2 value)
        {
            var storage = GetVariablesStorage(global);
            if (storage != null)
                return storage.TryGet(variable, out value);

            value = Vector2.zero;
            return false;
        }

        /// Obtains the value of the specified variable.
        protected bool TryGet(string variable, bool global, out Vector3 value)
        {
            var storage = GetVariablesStorage(global);
            if (storage != null)
                return storage.TryGet(variable, out value);

            value = Vector3.zero;
            return false;
        }

        /// Obtains the value of the specified variable.
        protected bool TryGet(string variable, bool global, out Vector4 value)
        {
            var storage = GetVariablesStorage(global);
            if (storage != null)
                return storage.TryGet(variable, out value);

            value = Vector4.zero;
            return false;
        }

        /// Sets the value to the specified variable.
        protected bool TrySet(string variable, bool global, bool value)
        {
            var storage = GetVariablesStorage(global);
            if (storage != null)
            {
                storage.Set(variable, value);
                return true;
            }

            return false;
        }

        /// Sets the value to the specified variable.
        protected bool TrySet(string variable, bool global, int value)
        {
            var storage = GetVariablesStorage(global);
            if (storage != null)
            {
                storage.Set(variable, value);
                return true;
            }

            return false;
        }

        /// Sets the value to the specified variable.
        protected bool TrySet(string variable, bool global, float value)
        {
            var storage = GetVariablesStorage(global);
            if (storage != null)
            {
                storage.Set(variable, value);
                return true;
            }

            return false;
        }

        /// Sets the value to the specified variable.
        protected bool TrySet(string variable, bool global, string value)
        {
            var storage = GetVariablesStorage(global);
            if (storage != null)
            {
                storage.Set(variable, value);
                return true;
            }

            return false;
        }

        /// Sets the value to the specified variable.
        protected bool TrySet(string variable, bool global, object value)
        {
            var storage = GetVariablesStorage(global);
            if (storage != null)
            {
                storage.Set(variable, value);
                return true;
            }

            return false;
        }

        /// Sets the value to the specified variable.
        protected bool TrySet(string variable, bool global, Vector2 value)
        {
            var storage = GetVariablesStorage(global);
            if (storage != null)
            {
                storage.Set(variable, value);
                return true;
            }

            return false;
        }

        /// Sets the value to the specified variable.
        protected bool TrySet(string variable, bool global, Vector3 value)
        {
            var storage = GetVariablesStorage(global);
            if (storage != null)
            {
                storage.Set(variable, value);
                return true;
            }

            return false;
        }

        /// Sets the value to the specified variable.
        protected bool TrySet(string variable, bool global, Vector4 value)
        {
            var storage = GetVariablesStorage(global);
            if (storage != null)
            {
                storage.Set(variable, value);
                return true;
            }

            return false;
        }

        /// Gets the actual variables storage.
        protected abstract VariablesStorage GetVariablesStorage(bool global);
    }
}