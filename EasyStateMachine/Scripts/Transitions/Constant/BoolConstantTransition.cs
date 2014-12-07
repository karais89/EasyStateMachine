//-----------------------------------------------------------------------
// <copyright file="BoolConstantTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Transitions.Bool
{
    using UnityEngine;

    /// Transits, when the result of the comparison 
    /// of a bool variable and a bool constant is 'true'.
    [AddComponentMenu("Easy State Machine/Transitions/Bool/Constant")]
    public sealed class BoolConstantTransition : Transition
    {
        #region Input
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("if")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// Name of the variable of type 'bool'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of type 'bool'.")]
        string @bool;

        /// Comparison operator.
        [SerializeField, Tooltip("Choose comparison operator.")]
        Equality @is;

        /// The value of type 'bool'.
        [SerializeField, Tooltip("Specify the value of type 'bool'.")]
        Boolean constantValue = Boolean.True;

#pragma warning disable 1635
#pragma warning disable 0169
#pragma warning disable 0414
        /// Where the job should be done.
        [SerializeField, Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414
#pragma warning restore 0169
#pragma warning restore 1635
#pragma warning restore 0649
        #endregion

        /// Does the job.
        void Do()
        {
            bool variable;
            if (!TryGet(global, @bool, out variable, false))
                return;

            switch (@is)
            {
                case Equality.EqualTo:
                    NeedTransit = (variable && constantValue == Boolean.True) ||
                                  (!variable && constantValue == Boolean.False);
                    break;
                case Equality.NotEqualTo:
                    NeedTransit = (variable && constantValue == Boolean.False) ||
                                  (!variable && constantValue == Boolean.True);
                    break;
            }
        }
    }
}
