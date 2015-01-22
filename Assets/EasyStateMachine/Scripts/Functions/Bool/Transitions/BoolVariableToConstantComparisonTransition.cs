//-----------------------------------------------------------------------
// <copyright file="BoolVariableToConstantComparisonTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Bool.Transitions
{
    using UnityEngine;

    /// Transits if the result of the comparison of a bool variable and a bool constant is true. 
    [AddComponentMenu("Easy State Machine/Functions/Bool/Transitions/Variable To Constant Comparison")]
    public sealed class BoolVariableToConstantComparisonTransition : Transition
    {
        [Header("if")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string boolVariable = null;

        [SerializeField]
        Equality @is = Equality.EqualTo;

        [SerializeField]
        Boolean constantValue = Boolean.True;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414

        void Do()
        {
            bool variable;
            if (!TryGet(global, boolVariable, out variable, false))
                return;

            switch (@is)
            {
                case Equality.EqualTo:
                    NeedTransit = (variable && constantValue == Boolean.True) 
                                || (!variable && constantValue == Boolean.False);
                    break;
                case Equality.NotEqualTo:
                    NeedTransit = (variable && constantValue == Boolean.False) 
                                || (!variable && constantValue == Boolean.True);
                    break;
            }
        }
    }
}
