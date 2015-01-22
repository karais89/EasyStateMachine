//-----------------------------------------------------------------------
// <copyright file="IntVariableToVariableComparisonTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Int.Transitions
{
    using UnityEngine;

    /// Transits if the result of the comparison of two int variables is true.
    /// "Transit to (State) if (global) int variable (string) is (comparison) (global) int 
    /// variable (string) in (In)." 
    [AddComponentMenu("Easy State Machine/Functions/Int/Transitions/Variable To Variable Comparison")]
    public sealed class IntVariableToVariableComparisonTransition : Transition
    {
        [Header("if")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string intVariable = null;

        [SerializeField]
        Comparison @is = Comparison.EqualTo;

        [SerializeField]
        bool _global = false;

        [SerializeField]
        string _intVariable = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414

        void Do()
        {
            int a;
            if (!TryGet(global, intVariable, out a, 0))
                return;

            int b;
            if (!TryGet(_global, _intVariable, out b, 0))
                return;

            switch (@is)
            {
                case Comparison.GreaterThan:
                    NeedTransit = a > b;
                    break;
                case Comparison.GreaterThanOrEqualTo:
                    NeedTransit = a >= b;
                    break;
                case Comparison.EqualTo:
                    NeedTransit = a == b;
                    break;
                case Comparison.NotEqualTo:
                    NeedTransit = a != b;
                    break;
                case Comparison.LessThanOrEqualTo:
                    NeedTransit = a <= b;
                    break;
                case Comparison.LessThan:
                    NeedTransit = a < b;
                    break;
            }
        }
    }
}
