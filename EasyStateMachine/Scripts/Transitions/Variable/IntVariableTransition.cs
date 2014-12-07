//-----------------------------------------------------------------------
// <copyright file="IntVariableTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Transitions.Int
{
    using UnityEngine;

    /// Transits, when the result of the comparison of two int variables is 'true'.
    [AddComponentMenu("Easy State Machine/Transitions/Int/Variable")]
    public sealed class IntVariableTransition : Transition
    {
        #region Input
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("if")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// The name of the variable of type 'int'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of type 'int'.")]
        string intA;

        /// Comparison operator.
        [SerializeField, Tooltip("Choose comparison operator.")]
        Comparison @is;

        /// Is the variable below global?
        [SerializeField, Tooltip("Is the variable below global?")]
        bool _global;

        /// The name of the variable of type 'int'.
        [SerializeField, Tooltip("Specify the name of the variable of type 'int'.")]
        string intB;

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
            int valueA;
            if (!TryGet(global, intA, out valueA, 0))
                return;

            int valueB;
            if (!TryGet(_global, intB, out valueB, 0))
                return;

            switch (@is)
            {
                case Comparison.GreaterThan:
                    NeedTransit = valueA > valueB;
                    break;
                case Comparison.GreaterThanOrEqualTo:
                    NeedTransit = valueA >= valueB;
                    break;
                case Comparison.EqualTo:
                    NeedTransit = valueA == valueB;
                    break;
                case Comparison.NotEqualTo:
                    NeedTransit = valueA != valueB;
                    break;
                case Comparison.LessThanOrEqualTo:
                    NeedTransit = valueA <= valueB;
                    break;
                case Comparison.LessThan:
                    NeedTransit = valueA < valueB;
                    break;
            }
        }
    }
}
