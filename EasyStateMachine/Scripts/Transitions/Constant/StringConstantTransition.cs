﻿//-----------------------------------------------------------------------
// <copyright file="StringConstantTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Transitions.String
{
    using UnityEngine;

    /// Transits, when the result of the comparison 
    /// of a string variable and a string constant is 'true'.
    [AddComponentMenu("Easy State Machine/Transitions/String/Constant")]
    public sealed class StringConstantTransition : Transition
    {
        #region Input
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("if")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// Name of the variable of type 'string'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of type 'string'.")]
        string variable;

        /// Comparison operator.
        [SerializeField, Tooltip("Choose comparison operator.")]
        Equality @is;

        /// The value of type 'string'.
        [SerializeField, Tooltip("Specify the value of type 'string'.")] 
        string stringValue;

#pragma warning disable 1635
#pragma warning disable 0169
#pragma warning disable 0414
        /// Where the job should be done.
        [SerializeField, Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414
#pragma warning restore 0169
#pragma warning restore 1635
#pragma warning restore 0649
        #endregion

        /// Does the job.
        void Do()
        {
            string value;
            if (!TryGet(global, variable, out value, string.Empty))
                return;

            switch (@is)
            {
                case Equality.EqualTo:
                    NeedTransit = value.Equals(stringValue, System.StringComparison.Ordinal);
                    break;
                case Equality.NotEqualTo:
                    NeedTransit = !value.Equals(stringValue, System.StringComparison.Ordinal);
                    break;
            }
        }
    }
}
