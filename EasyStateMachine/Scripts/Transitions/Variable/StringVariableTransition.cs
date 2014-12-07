//-----------------------------------------------------------------------
// <copyright file="StringVariableTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Transitions.String
{
    using UnityEngine;

    /// Transits, when the result of the comparison of two string variables is 'true'.
    [AddComponentMenu("Easy State Machine/Transitions/String/Variable")]
    public sealed class StringVariableTransition : Transition
    {
        #region Input
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("if")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// The name of the variable of type 'string'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of type 'string'.")]
        string stringA;

        /// Comparison operator.
        [SerializeField, Tooltip("Choose the comparison operator.")]
        Equality @is;

        /// Is the variable below global?
        [SerializeField, Tooltip("Is the variable below global?")]
        bool _global;

        /// The name of the variable of type 'string'.
        [SerializeField, Tooltip("Specify the name of the variable of type 'string'.")]
        string stringB;

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
            string valueA;
            if (!TryGet(global, stringA, out valueA, string.Empty))
                return;

            string valueB;
            if (!TryGet(_global, stringB, out valueB, string.Empty))
                return;

            switch (@is)
            {
                case Equality.EqualTo:
                    NeedTransit = valueA.Equals(valueB, System.StringComparison.Ordinal);
                    break;
                case Equality.NotEqualTo:
                    NeedTransit = !valueA.Equals(valueB, System.StringComparison.Ordinal);
                    break;
            }
        }
    }
}
