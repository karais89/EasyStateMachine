//-----------------------------------------------------------------------
// <copyright file="BoolVariableToVariableComparisonTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Bool.Transitions
{
    using UnityEngine;

    /// Transits if the result of the comparison of two bool variables is true.
    [AddComponentMenu("Easy State Machine/Functions/Bool/Transitions/Variable To Variable Comparison")]
    public sealed class BoolVariableToVariableComparisonTransition : Transition
    {
        [Header("if")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string boolVariable = null;

        [SerializeField]
        Equality @is = Equality.EqualTo;

        [SerializeField]
        bool _global = false;

        [SerializeField]
        string _boolVariable = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414

        void Do()
        {
            bool a;
            if (!TryGet(global, boolVariable, out a, false))
                return;

            bool b;
            if (!TryGet(_global, _boolVariable, out b, false))
                return;

            switch (@is)
            {
                case Equality.EqualTo:
                    NeedTransit = (boolVariable == _boolVariable);
                    break;
                case Equality.NotEqualTo:
                    NeedTransit = (boolVariable != _boolVariable);
                    break;
            }
        }
    }
}
