//-----------------------------------------------------------------------
// <copyright file="BaseWithStorage.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine
{
    using UnityEngine;
    using System.Collections.Generic;
    using System.Text;

    /// Represents the storage for variables.
    public abstract class BaseForStates : Base
    {
        #region Private
        /// Dictionary to store the variables.
        readonly Dictionary<string, object> _variables = new Dictionary<string, object>();
        #endregion

        /// Sets the variable by name. The variable may be not set, 
        /// if the name is 'null' or empty, or if the variable with 
        /// same name already exists but is of different type.
        public void Set(string variableName, object value)
        {
            if (string.IsNullOrEmpty(variableName))
            {
                #region Editor
#if UNITY_EDITOR
                Debug.LogError("Failed to set the variable. IntVariableTransition name is 'null' or empty.");
                Debug.Break();
#endif
                #endregion
                return;
            }

            object obj;
            if (_variables.TryGetValue(variableName, out obj) && !(ReferenceEquals(value.GetType(), obj.GetType())))
            {
                #region Editor
#if UNITY_EDITOR
                Debug.LogError("Failed to set the variable '" + variableName + "'. " +
                               "The variable you are trying to set exists and is of different type. " +
                               "You want to set the variable of type: " + value.GetType() + ". " +
                               "Type of existing variable is: " + obj.GetType() + ".");
                Debug.Break();
#endif
                #endregion
                return;
            }

            _variables[variableName] = value;
        }

        /// Gets the variable by name. Returns 'null' if
        /// the variable name is 'null' or empty, or if
        /// the variable does not exist.
        public object Get(string variableName)
        {
            if (string.IsNullOrEmpty(variableName))
            {
                #region Editor
#if UNITY_EDITOR
                Debug.LogWarning("Failed to set the variable. IntVariableTransition name is 'null' or empty.");
#endif
                #endregion
                return null;
            }

            object obj;
            if (!_variables.TryGetValue(variableName, out obj))
            {
                #region Editor
#if UNITY_EDITOR
                Debug.LogWarning("Failed to get the variable '" + variableName + "'. " +
                                 "The variable you are trying to get does not exist.");
#endif
                #endregion
                return null;
            }

            return obj;
        }

        /// Gets the variable by name. Returns 'null' if
        /// the variable name is 'null' or empty, if
        /// the variable does not exist or if the specified
        /// type doesn't match the type of the variable.
        public object Get<T>(string variableName)
        {
            if (string.IsNullOrEmpty(variableName))
            {
                #region Editor
#if UNITY_EDITOR
                Debug.LogWarning("Failed to get the variable. IntVariableTransition name is 'null' or empty.");
#endif
                #endregion
                return null;
            }

            object obj;
            if (!_variables.TryGetValue(variableName, out obj))
            {
                #region Editor
#if UNITY_EDITOR
                    Debug.LogWarning("Failed to get the variable '" + variableName + "'. " +
                                 "The variable you are trying to get does not exist.");
#endif
                #endregion
                return null;
            }

            if (!(obj is T))
            {
                #region Editor
#if UNITY_EDITOR
                Debug.LogWarning("Failed to get the variable '" + variableName + "'. " +
                                 "The variable you are trying to get exists but is of different type. " +
                                 "You want to get the variable of type: " + typeof(T) + ". " +
                                 "Type of existing variable is: " + obj.GetType() + ". ");
#endif
                #endregion
                return null;
            }

            return obj;
        }

        #region Editor
#if UNITY_EDITOR
        public virtual string Info
        {
            get
            {
                if (_variables == null || _variables.Count <= 0)
                    return Application.isPlaying ? "There are no variables present\n" : string.Empty;

                var sb = new StringBuilder("Variables:");
                sb.AppendLine();
                foreach (var variable in _variables)
                {
                    sb.AppendFormat("{0}: {1}", variable.Key, variable.Value).AppendLine();
                }

                return sb.ToString();
            }
        }
#endif
        #endregion
    }
}
