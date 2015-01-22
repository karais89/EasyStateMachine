//-----------------------------------------------------------------------
// <copyright file="StringVariableToVariableComparisonTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.String.Transitions
{
    using UnityEngine;
    using Comparison = System.StringComparison;

    /// Transits if the result of the comparison of two string variables is true.
    [AddComponentMenu("Easy State Machine/Functions/String/Transitions/Variable To Variable Comparison")]
    public sealed class StringVariableToVariableComparisonTransition : Transition
    {
        [Header("if")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string stringVariable = null;

        [SerializeField]
        Equality @is = Equality.EqualTo;

        // TODO: implement string comparison selection.

        [SerializeField]
        bool _global = false;

        [SerializeField]
        string _stringVariable = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414

        void Do()
        {
            string a;
            if (!TryGet(global, stringVariable, out a, string.Empty))
                return;

            string b;
            if (!TryGet(_global, _stringVariable, out b, string.Empty))
                return;

            switch (@is)
            {
                case Equality.EqualTo:
                NeedTransit = a.Equals(b, Comparison.Ordinal);
                    break;
                case Equality.NotEqualTo:
                    NeedTransit = !a.Equals(b, Comparison.Ordinal);
                    break;
            }
        }
    }
}
