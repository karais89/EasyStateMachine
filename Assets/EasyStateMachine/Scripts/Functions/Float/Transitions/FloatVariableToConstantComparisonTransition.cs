//-----------------------------------------------------------------------
// <copyright file="FloatVariableToConstantComparisonTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Float.Transitions 
{
    using UnityEngine;

    /// Transits if the result of the comparison of a float variable and a float constant is true.
    [AddComponentMenu("Easy State Machine/Functions/Float/Transitions/Variable To Constant Comparison")]
    public sealed class FloatVariableToConstantComparisonTransition : Transition
    {
        [Header("if")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string floatVariable = null;

        [SerializeField]
        Comparison @is = Comparison.EqualTo;

        [SerializeField]
        float constantValue = 0f;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414

        void Do()
        {
            float variable;
            if (!TryGet(global, @floatVariable, out variable, 0f))
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
