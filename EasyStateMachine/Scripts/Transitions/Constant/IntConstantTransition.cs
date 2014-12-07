//-----------------------------------------------------------------------
// <copyright file="IntConstantTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Transitions.Int
{
    using UnityEngine;

    /// Transits, when the result of the comparison of an 
    /// int variable and an int constant is 'true'.
    [AddComponentMenu("Easy State Machine/Transitions/Int/Constant")]
    public sealed class IntConstantTransition : Transition
    {
        #region Input
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("if")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// Name of the variable of type 'int'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of type 'int'.")]
        string @int;

        /// Comparison operator.
        [SerializeField, Tooltip("Choose comparison operator.")]
        Comparison @is;

        /// The value of type 'int'.
        [SerializeField, Tooltip("Specify the value of type 'int'.")]
        int constantValue;

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
            
            int variable;
            if (!TryGet(global, @int, out variable, 0))
                return;

            switch (@is)
            {
                case Comparison.GreaterThan:
                    NeedTransit = variable > constantValue;
                    break;
                case Comparison.GreaterThanOrEqualTo:
                    NeedTransit = variable >= constantValue;
                    break;
                case Comparison.EqualTo:
                    NeedTransit = variable == constantValue;
                    break;
                case Comparison.NotEqualTo:
                    NeedTransit = variable != constantValue;
                    break;
                case Comparison.LessThanOrEqualTo:
                    NeedTransit = variable <= constantValue;
                    break;
                case Comparison.LessThan:
                    NeedTransit = variable < constantValue;
                    break;
            }
        }
    }
}
