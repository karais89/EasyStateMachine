//-----------------------------------------------------------------------
// <copyright file="ButtonTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Transitions.UI
{
    using UnityEngine;
    using UnityEngine.UI;

    /// Transits if button is pressed.
    [AddComponentMenu("Easy State Machine/Transitions/UI/Button")]
    public sealed class ButtonTransition : Transition
    {
        #region Input
#pragma warning disable 0649
        /// Button from new Unity UI.
        [Header("if")]
        [SerializeField, Tooltip("Button from new Unity UI.")]
        Button pressed;

#pragma warning disable 1635
#pragma warning disable 0169
#pragma warning disable 0414
        /// Where the job should be done.
        [Header("Immediately or")]
        [SerializeField, Tooltip("Choose where the job should be done.")]
        In @in = In.None;
#pragma warning restore 0414
#pragma warning restore 0169
#pragma warning restore 1635
#pragma warning restore 0649
        #endregion

        /// True, if button was pressed, but shouldn't be handled immediately.
        bool wasPressed;

        /// Does the job.
        void Do()
        {
            if (wasPressed)
            {
                NeedTransit = wasPressed;
                wasPressed = false;
            }
        }

        /// Handles click.
        void Handler()
        {
            if (@in == In.None)
                NeedTransit = true;
            else
                wasPressed = true;
        }

        /// Adds click listener.
        void OnEnable()
        {
            pressed.onClick.AddListener(Handler);
        }

        /// Removes click listener.
        void OnDisable()
        {
            pressed.onClick.RemoveListener(Handler);
        }
    }
}
