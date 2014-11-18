//-----------------------------------------------------------------------
// <copyright file="BoolTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Transitions.Variables
{
    using UnityEngine;

    /// Represent the transition, which checks the value of a bool variable.
    public sealed class BoolTransition : Transition
    {
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("Transit if")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// Name of a variable of type 'bool'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of a variable of type 'bool'.")]
        string @bool;

        /// Value to compare to.
        [SerializeField, Tooltip("Choose a value to compare to.")]
        Boolean isEqualTo;

        /// Where the action should happen
        [SerializeField, Tooltip("Choose where the action should happen.")]
        Where @in;
#pragma warning restore 0649

        /// Where the action should happen. This property is used in the base class.
        protected override Where In { get { return @in; } }

        /// Checks, whether the transition should happen or not.
        protected override void Do()
        {
            bool value;
            if (!TryGet(@bool, global, out value)) 
                return;

            if ((value && isEqualTo == Boolean.True) || (!value && isEqualTo == Boolean.False))
                NeedTransit = true;
        }
    }
}
