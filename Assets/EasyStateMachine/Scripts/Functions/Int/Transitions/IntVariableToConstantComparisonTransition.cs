//-----------------------------------------------------------------------
// <copyright file="IntVariableToConstantComparisonTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Int.Transitions
{
    using UnityEngine;

    /// Transits if the result of the comparison of an int variable and an
    /// int constant is true. "Transit to (State) if (global) int variable (string) 
    /// is (comparison) constant value (int) in (In)." 
    [AddComponentMenu("Easy State Machine/Functions/Int/Transitions/Variable To Constant Comparison")]
    public sealed class IntVariableToConstantComparisonTransition : Transition
    {
        [Header("if")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string intVariable = null;

        [SerializeField]
        Comparison @is = Comparison.EqualTo;

        [SerializeField]
        int constantValue = 0;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414

        void Do()
        {
            int variable;
            if (!TryGet(global, intVariable, out variable, 0))
                return;

            switch (@is)
            {
                case Comparison.GreaterThan:
                    NeedTransit = variable > constantValue;
                    break;
                case Comparison.GreaterThanOrEqualTo:
                    NeedTransit = variable >= constantValue;
                    break;
                case Comparison.EqualTo:
                    NeedTransit = variable == constantValue;
                    break;
                case Comparison.NotEqualTo:
                    NeedTransit = variable != constantValue;
                    break;
                case Comparison.LessThanOrEqualTo:
                    NeedTransit = variable <= constantValue;
                    break;
                case Comparison.LessThan:
                    NeedTransit = variable < constantValue;
                    break;
            }
        }
    }
}
