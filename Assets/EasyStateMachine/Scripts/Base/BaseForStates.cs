//-----------------------------------------------------------------------
// <copyright file="BaseForStates.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine
{
    using UnityEngine;
    using System.Collections.Generic;
    using System.Text;

    /// Represents the base class for States.
    public abstract class BaseForStates : Base
    {
        /// Dictionary to store the variables.
        readonly Dictionary<string, object> variables = new Dictionary<string, object>();

        /// Sets the variable by name. The variable may be not set, 
        /// if the name is null or empty, or if the variable with 
        /// same name already exists but is of different type.
        public void Set(string variableName, object value)
        {
            if (string.IsNullOrEmpty(variableName))
            {
#if UNITY_EDITOR
                Debug.LogError("Failed to set the variable. Variable name is null or empty.");
                Debug.Break();
#endif
                return;
            }

            object obj;
            if (variables.TryGetValue(variableName, out obj) && !(ReferenceEquals(value.GetType(), obj.GetType())))
            {
#if UNITY_EDITOR
                Debug.LogError("Failed to set the variable \"" + variableName +
                               "\" of type " + value.GetType() + ". " + "The " +
                               "variable you are trying to set already exists " +
                               "but is of type: " + obj.GetType() + ". ");
                Debug.Break();
#endif
                return;
            }

            variables[variableName] = value;
        }

        /// Gets the variable by name. Returns null if the variable 
        /// name is null or empty or if the variable does not exist.
        public object Get(string variableName)
        {
            if (string.IsNullOrEmpty(variableName))
            {
#if UNITY_EDITOR
                Debug.LogWarning("Failed to get the variable. Variable name is null or empty.");
#endif
                return null;
            }

            object obj;
            if (!variables.TryGetValue(variableName, out obj))
            {
#if UNITY_EDITOR
                Debug.LogWarning("Failed to get the variable \"" + variableName + "\". " +
                                 "The variable you are trying to get does not exist.");
#endif
                return null;
            }

            return obj;
        }

        /// Gets the variable by name. Returns null if the variable name 
        /// is null or empty, if the variable does not exist or if the 
        /// specified type doesn't match the type of the variable.
        public object Get<T>(string variableName)
        {
            if (string.IsNullOrEmpty(variableName))
            {
#if UNITY_EDITOR
                Debug.LogWarning("Failed to get the variable. Variable name is null or empty.");
#endif
                return null;
            }

            object obj;
            if (!variables.TryGetValue(variableName, out obj))
            {
#if UNITY_EDITOR
                    Debug.LogWarning("Failed to get the variable \"" + variableName + "\". " +
                                     "The variable you are trying to get does not exist.");
#endif
                return null;
            }

            if (!(obj is T))
            {
#if UNITY_EDITOR
                Debug.LogError("Failed to get the variable \"" + variableName +
                               "\" of type " + typeof(T) + ". " + "The " +
                               "variable you are trying to set already exists " +
                               "but is of type: " + obj.GetType() + ". ");
#endif
                return null;
            }

            return obj;
        }

#if UNITY_EDITOR
        /// Returns the variables info.
        /// This info is shown in Inspector.
        public virtual string Info
        {
            get
            {
                if (variables == null || variables.Count <= 0)
                    return Application.isPlaying ? "There are no variables present\n" : string.Empty;

                var sb = new StringBuilder("Variables:");
                sb.AppendLine();
                foreach (var variable in variables)
                    sb.AppendFormat("{0}: {1}", variable.Key, variable.Value).AppendLine();

                return sb.ToString();
            }
        }
#endif
    }
}
