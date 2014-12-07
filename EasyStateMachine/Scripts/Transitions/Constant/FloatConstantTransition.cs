//-----------------------------------------------------------------------
// <copyright file="FloatConstantTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Transitions.Float
{
    using UnityEngine;

    /// Transits, when the result of the comparison of 
    /// a float variable and a float constant is 'true'.
    [AddComponentMenu("Easy State Machine/Transitions/Float/Constant")]
    public sealed class FloatConstantTransition : Transition
    {
        #region Input
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("if")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// Name of the variable of type 'float'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of type 'float'.")]
        string @float;

        /// Comparison operator.
        [SerializeField, Tooltip("Choose comparison operator.")]
        Comparison @is;

        /// The value of type 'float'.
        [SerializeField, Tooltip("Specify the value of type 'float'.")]
        float constantValue;

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
            float variable;
            if (!TryGet(global, @float, out variable, 0f))
                return;

            switch (@is)
            {
                case Comparison.GreaterThan:
                    NeedTransit = variable > constantValue;
                    break;
                case Comparison.GreaterThanOrEqualTo:
                    NeedTransit = variable >= constantValue || Mathf.Approximately(variable, constantValue);
                    break;
                case Comparison.EqualTo:
                    NeedTransit = Mathf.Approximately(variable, constantValue);
                    break;
                case Comparison.NotEqualTo:
                    NeedTransit = !Mathf.Approximately(variable, constantValue);
                    break;
                case Comparison.LessThanOrEqualTo:
                    NeedTransit = variable <= constantValue || Mathf.Approximately(variable, constantValue);
                    break;
                case Comparison.LessThan:
                    NeedTransit = variable < constantValue;
                    break;
            }
        }
    }
}
