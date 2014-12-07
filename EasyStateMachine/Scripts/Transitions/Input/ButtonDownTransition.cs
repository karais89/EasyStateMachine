//-----------------------------------------------------------------------
// <copyright file="ButtonDownTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Transitions.Input
{
    using UnityEngine;

    /// Transits if button is pressed.
    [AddComponentMenu("Easy State Machine/Transitions/Input/Button Down")]
    public sealed class ButtonDownTransition : Transition
    {
        #region Input
#pragma warning disable 0649
        /// Button name.
        [Header("if")]
        [SerializeField, Tooltip("Button name.")]
        string pressed;

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
            if (Input.GetButtonDown(pressed))
                NeedTransit = true;
        }
    }
}
