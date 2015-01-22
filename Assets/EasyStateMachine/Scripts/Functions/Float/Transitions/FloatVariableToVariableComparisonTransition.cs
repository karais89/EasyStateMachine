//-----------------------------------------------------------------------
// <copyright file="FloatVariableToVariableComparisonTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Float.Transitions
{
    using UnityEngine;

    /// Transits if the result of the comparison of two float variables is true.
    [AddComponentMenu("Easy State Machine/Functions/Float/Transitions/Variable To Variable Comparison")]
    public sealed class FloatVariableToVariableComparisonTransition : Transition
    {
        [Header("if")] 
        [SerializeField]
        bool global = false;

        [SerializeField]
        string floatVariable = null;

        [SerializeField]
        Comparison @is = Comparison.EqualTo;

        [SerializeField]
        bool _global = false;

        [SerializeField]
        string _floatVariable = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414

        void Do()
        {
            float a;
            if (!TryGet(global, floatVariable, out a, 0f))
                return;

            float b;
            if (!TryGet(_global, _floatVariable, out b, 0f))
                return;

            switch (@is)
            {
                case Comparison.GreaterThan:
                    NeedTransit = a > b;
                    break;
                case Comparison.GreaterThanOrEqualTo:
                    NeedTransit = a >= b || Mathf.Approximately(a, b);
                    break;
                case Comparison.EqualTo:
                    NeedTransit = Mathf.Approximately(a, b);
                    break;
                case Comparison.NotEqualTo:
                    NeedTransit = !Mathf.Approximately(a, b);
                    break;
                case Comparison.LessThanOrEqualTo:
                    NeedTransit = a <= b || Mathf.Approximately(a, b);
                    break;
                case Comparison.LessThan:
                    NeedTransit = a < b;
                    break;
            }
        }
    }
}
