//-----------------------------------------------------------------------
// <copyright file="FloatTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Transitions.Variables
{
    using UnityEngine;

    /// Represent the transition, which checks the value of a float variable.
    public sealed class FloatTransition : Transition
    {
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("Transit if")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// The name of a variable of type 'float'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of a variable of type 'float'.")]
        private string @float;

        /// Comparison operator.
        [SerializeField, Tooltip("Choose comparison operator.")]
        Comparison @is;

        /// Value to compare to.
        [SerializeField, Tooltip("Insert value to compare to.")]
        float value;

        /// Where the action should happen.
        [SerializeField, Tooltip("Choose where the action should happen.")]
        Where @in;
#pragma warning restore 0649

        /// Where the action should happen. This property is used in the base class.
        protected override Where In { get { return @in; } }

        /// Checks, whether the transition should happen or not.
        protected override void Do()
        {
            float floatValue;
            if (!TryGet(@float, global, out floatValue))
                return;

            switch (@is)
            {
                case Comparison.GreaterThan:
                    NeedTransit = floatValue > value;
                    break;
                case Comparison.GreaterThanOrEqualTo:
                    NeedTransit = floatValue >= value;
                    break;
                case Comparison.EqualTo:
                    NeedTransit = Mathf.Approximately(floatValue, value);
                    break;
                case Comparison.LessThanOrEquaTo:
                    NeedTransit = floatValue <= value;
                    break;
                case Comparison.LessThan:
                    NeedTransit = floatValue < value;
                    break;
            }
        }
    }
}
