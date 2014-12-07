//-----------------------------------------------------------------------
// <copyright file="BoolVariableTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Transitions.Float
{
    using UnityEngine;

    /// Transits, when the result of the comparison of two float variables is 'true'.
    [AddComponentMenu("Easy State Machine/Transitions/Float/Variable")]
    public sealed class FloatVariableTransition : Transition
    {
        #region Input
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("if")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// The name of the variable of type 'float'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of type 'float'.")]
        string floatA;

        /// Comparison operator.
        [SerializeField, Tooltip("Choose comparison operator.")]
        Comparison @is;

        /// Is the variable below global?
        [SerializeField, Tooltip("Is the variable below global?")]
        bool _global;

        /// The name of the variable of type 'float'.
        [SerializeField, Tooltip("Specify the name of the variable of type 'float'.")]
        string floatB;

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
            float valueA;
            if (!TryGet(global, floatA, out valueA, 0f))
                return;

            float valueB;
            if (!TryGet(_global, floatB, out valueB, 0f))
                return;

            switch (@is)
            {
                case Comparison.GreaterThan:
                    NeedTransit = valueA > valueB;
                    break;
                case Comparison.GreaterThanOrEqualTo:
                    NeedTransit = valueA >= valueB || Mathf.Approximately(valueA, valueB);
                    break;
                case Comparison.EqualTo:
                    NeedTransit = Mathf.Approximately(valueA, valueB);
                    break;
                case Comparison.NotEqualTo:
                    NeedTransit = !Mathf.Approximately(valueA, valueB);
                    break;
                case Comparison.LessThanOrEqualTo:
                    NeedTransit = valueA <= valueB || Mathf.Approximately(valueA, valueB);
                    break;
                case Comparison.LessThan:
                    NeedTransit = valueA < valueB;
                    break;
            }
        }
    }
}
