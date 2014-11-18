//-----------------------------------------------------------------------
// <copyright file="VariablesStorage.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine
{
    using UnityEngine;
    using System.Collections.Generic;

    /// Represents the storage for variables.
    public class VariablesStorage : Base
    {
        /// Contains bool variables.
        private Dictionary<string, bool> bools = new Dictionary<string, bool>();

        /// Sets the bool variable by name.
        public void Set(string variableName, bool value)
        {
            if(!string.IsNullOrEmpty(variableName)) 
                bools[variableName] = value;
        }

        /// Gets the bool variable by name.
        public bool TryGet(string variableName, out bool value)
        {
            value = false;
            return !string.IsNullOrEmpty(variableName) && bools.TryGetValue(variableName, out value);
        }

        /// Contains int variables.
        private Dictionary<string, int> ints = new Dictionary<string, int>();

        /// Sets the int variable by name.
        public void Set(string variableName, int value)
        {
            if (!string.IsNullOrEmpty(variableName)) 
                ints[variableName] = value;
        }

        /// Gets the int variable by name.
        public bool TryGet(string variableName, out int value)
        {
            value = 0;
            return !string.IsNullOrEmpty(variableName) && ints.TryGetValue(variableName, out value);
        }

        /// Contains float variables.
        private Dictionary<string, float> floats = new Dictionary<string, float>();

        /// Sets the float variable by name.
        public void Set(string variableName, float value)
        {
            if (!string.IsNullOrEmpty(variableName)) 
                floats[variableName] = value;
        }

        /// Gets the float value by name.
        public bool TryGet(string variableName, out float value)
        {
            value = 0;
            return !string.IsNullOrEmpty(variableName) && floats.TryGetValue(variableName, out value);
        }

        /// Contains string variables.
        private Dictionary<string, string> strings = new Dictionary<string, string>();

        /// Sets the string variable by name.
        public void Set(string variableName, string value)
        {
            if (!string.IsNullOrEmpty(variableName)) 
                strings[variableName] = value;
        }

        /// Gets the string variable by name.
        public bool TryGet(string variableName, out string value)
        {
            value = string.Empty;
            return !string.IsNullOrEmpty(variableName) && strings.TryGetValue(variableName, out value);
        }

        /// Contains object variables.
        private Dictionary<string, object> objects = new Dictionary<string, object>();

        /// Sets the object variable by name.
        public void Set(string variableName, object value)
        {
            if (!string.IsNullOrEmpty(variableName)) 
                objects[variableName] = value;
        }

        /// Gets the object variable by name.
        public bool TryGet(string variableName, out object value)
        {
            value = null;
            return !string.IsNullOrEmpty(variableName) && objects.TryGetValue(variableName, out value);
        }

        /// Contains Vector2 variables.
        private Dictionary<string, Vector2> vectors2 = new Dictionary<string, Vector2>();

        /// Sets the Vector2 variable by name.
        public void Set(string variableName, Vector2 value)
        {
            if (!string.IsNullOrEmpty(variableName)) 
                vectors2[variableName] = value;
        }

        /// Gets the Vector2 variable by name.
        public bool TryGet(string variableName, out Vector2 value)
        {
            value = Vector2.zero;
            return !string.IsNullOrEmpty(variableName) && vectors2.TryGetValue(variableName, out value);
        }

        /// Contains Vector3 variables.
        private Dictionary<string, Vector3> vectors3 = new Dictionary<string, Vector3>();

        /// Sets the Vector3 variable by name.
        public void Set(string variableName, Vector3 value)
        {
            if (!string.IsNullOrEmpty(variableName)) 
                vectors3[variableName] = value;
        }

        /// Gets the Vector3 variable by name.
        public bool TryGet(string variableName, out Vector3 value)
        {
            value = Vector3.zero;
            return !string.IsNullOrEmpty(variableName) && vectors3.TryGetValue(variableName, out value);
        }

        /// Contains Vector4 variables.
        private Dictionary<string, Vector4> vectors4 = new Dictionary<string, Vector4>();

        /// Sets the Vector4 variable by name.
        public void Set(string variableName, Vector4 value)
        {
            if (!string.IsNullOrEmpty(variableName)) 
                vectors4[variableName] = value;
        }

        /// Gets the Vector4 variable by name.
        public bool TryGet(string variableName, out Vector4 value)
        {
            value = Vector4.zero;
            return !string.IsNullOrEmpty(variableName) && vectors4.TryGetValue(variableName, out value);
        }
    }
}
