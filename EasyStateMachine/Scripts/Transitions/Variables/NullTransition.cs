//-----------------------------------------------------------------------
// <copyright file="NullTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Transitions.Variables
{
    using UnityEngine;

    /// Represent the transition, which checks the value of a variable of type 'object'.
    public sealed class NullTransition : Transition
    {
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("Transit if")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// The name of a variable of type 'object'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of a variable of type 'object'.")]
        string @object;

        /// Value to compare to.
        [SerializeField, Tooltip("Choose value to compare to.")]
        Reference @is;

        /// Where the action should happen.
        [SerializeField, Tooltip("Choose where the action should happen.")]
        Where @in;
#pragma warning restore 0649

        /// Where the action should happen. This property is used in the base class.
        protected override Where In { get { return @in; } }

        /// Checks, whether the transition should happen or not.
        protected override void Do()
        {
            object value;
            if (!TryGet(@object, global, out value))
                return;

            if ((value == null && @is == Reference.Null) || 
                (value != null && @is == Reference.NotNull))
                NeedTransit = true;
        }
    }
}