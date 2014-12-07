//-----------------------------------------------------------------------
// <copyright file="BoolVariableTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Transitions.Bool
{
    using UnityEngine;

    /// Transits, when the result of the comparison of two boolean variables is 'true'.
    [AddComponentMenu("Easy State Machine/Transitions/Bool/Variable")]
    public sealed class BoolVariableTransition : Transition
    {
        #region Input
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("if")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// The name of the variable of type 'bool'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of type 'bool'.")]
        string boolA;

        /// Comparison operator.
        [SerializeField, Tooltip("Choose comparison operator.")]
        Equality @is;

        /// Is the variable below global?
        [SerializeField, Tooltip("Is the variable below global?")]
        bool _global;

        /// The name of the variable of type 'bool'.
        [SerializeField, Tooltip("Specify the name of the variable of type 'bool'.")]
        string boolB;

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
            bool valueA;
            if (!TryGet(global, boolA, out valueA, false))
                return;

            bool valueB;
            if (!TryGet(_global, boolB, out valueB, false))
                return;

            switch (@is)
            {
                case Equality.EqualTo:
                    NeedTransit = (boolA == boolB);
                    break;
                case Equality.NotEqualTo:
                    NeedTransit = (boolA != boolB);
                    break;
            }
        }
    }
}
