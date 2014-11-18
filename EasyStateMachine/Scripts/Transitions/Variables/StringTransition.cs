//-----------------------------------------------------------------------
// <copyright file="StringTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Transitions.Variables
{
    using UnityEngine;

    /// Represent the transition, which checks the value of a string variable.
    public sealed class StringTransition : Transition
    {
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("Transit if")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// The name of a variable of type 'string'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of a variable of type 'string'.")]
        string @string;

        /// Equality operator.
        [SerializeField, Tooltip("Choose equality operator.")]
        Equality @is;

        /// Value to compare to.
        [SerializeField, Tooltip("Insert the value to compare to (if this field is empty, the variable will be compared both to null and to empty string).")]
        string otherString;

        /// Where the action should happen.
        [SerializeField, Tooltip("Choose where the action should happen.")]
        Where @in;
#pragma warning restore 0649

        /// Where the action should happen. This property is used in the base class.
        protected override Where In { get { return @in; } }

        /// Checks, whether the transition should happen or not.
        protected override void Do()
        {
            string value;
            if (!TryGet(@string, global, out value))
                return;

            // Check if both strings are null or empty.
            var bothAreNullOrEmpty = string.IsNullOrEmpty(value) && string.IsNullOrEmpty(otherString);
            if (bothAreNullOrEmpty)
            {
                if(@is == Equality.EqualTo)    
                    NeedTransit = true;

                return;
            }

            // Check if at least one string is null or empty.
            var oneIsNullOrEmpty = string.IsNullOrEmpty(value) || string.IsNullOrEmpty(otherString);
            if (oneIsNullOrEmpty)
            {
                if(@is == Equality.NotEqualTo)
                    NeedTransit = true;

                return;
            }

            // Strings are not null and not empty, compare one to another.
            var equals = @string.Equals(otherString);
            if ((equals && @is == Equality.EqualTo) || 
                (!equals && @is == Equality.NotEqualTo))
                NeedTransit = true;
        }
    }
}