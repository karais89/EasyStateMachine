//-----------------------------------------------------------------------
// <copyright file="IntTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Transitions.Variables
{
    using UnityEngine;

    /// Represent the transition, which checks the value of an integer variable.
    public sealed class IntTransition : Transition
    {
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("Transit if")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// The name of a variable of type 'int'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of a variable of type 'int'.")]
        private string @int;

        /// Comparison operator.
        [SerializeField, Tooltip("Choose comparison operator.")]
        Comparison @is;

        /// Value to compare to.
        [SerializeField, Tooltip("Insert value to compare to.")]
        int value;

        /// Where the action should happen.
        [SerializeField, Tooltip("Choose where the action should happen.")]
        Where @in;
#pragma warning restore 0649

        /// Where the action should happen. This property is used in the base class.
        protected override Where In { get { return @in; } }

        /// Checks, whether the transition should happen or not.
        protected override void Do()
        {
            int intValue;
            if (!TryGet(@int, global, out intValue))
                return; // If the variable does not exist transition doesn't happen.

            switch (@is)
            {
                case Comparison.GreaterThan:
                    NeedTransit = intValue > value;
                    break;
                case Comparison.GreaterThanOrEqualTo:
                    NeedTransit = intValue >= value;
                    break;
                case Comparison.EqualTo:
                    NeedTransit = intValue == value;
                    break;
                case Comparison.LessThanOrEquaTo:
                    NeedTransit = intValue <= value;
                    break;
                case Comparison.LessThan:
                    NeedTransit = intValue < value;
                    break;
            }
        }
    }
}
