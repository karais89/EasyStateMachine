//-----------------------------------------------------------------------
// <copyright file="StringVariableToConstantComparisonTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.String.Transitions
{
    using UnityEngine;
    using Comparison = System.StringComparison;

    /// Transits if the result of the comparison of a string variable and a string constant is true.
    [AddComponentMenu("Easy State Machine/Functions/String/Transitions/Variable To Constant Comparison")]
    public sealed class StringVariableToConstantComparisonTransition : Transition
    {
        [Header("if")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string variable = null;

        [SerializeField]
        Equality @is = Equality.EqualTo;

        // TODO: implement string comparison selection.

        [SerializeField] 
        string stringValue = string.Empty;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414

        void Do()
        {
            string value;
            if (!TryGet(global, variable, out value, string.Empty))
                return;

            switch (@is)
            {
                case Equality.EqualTo:
                    NeedTransit = value.Equals(stringValue, System.StringComparison.Ordinal);
                    break;
                case Equality.NotEqualTo:
                    NeedTransit = !value.Equals(stringValue, System.StringComparison.Ordinal);
                    break;
            }
        }
    }
}
