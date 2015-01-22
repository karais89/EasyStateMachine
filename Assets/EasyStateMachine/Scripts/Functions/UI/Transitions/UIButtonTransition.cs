//-----------------------------------------------------------------------
// <copyright file="ButtonTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.UI.Transitions
{
    using UnityEngine;
    using UnityEngine.UI;

    /// Transits if the specified UI button is pressed.
    [AddComponentMenu("Easy State Machine/Functions/UI/Transitions/Button Press")]
    public sealed class UIButtonTransition : Transition
    {
        [Header("if")]
        [SerializeField]
        Button pressed = null;

        // TODO: add other button events.

        [Header("Immediately or")]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.None;

        bool needHandle;

        void Do()
        {
            if (needHandle)
            {
                NeedTransit = true;
                needHandle = false;
            }
        }

        void ClickHandler()
        {
            if (@in == In.None)
                NeedTransit = true;
            else
                needHandle = true;
        }

        /// Adds the click listener.
        void OnEnable()
        {
            pressed.onClick.AddListener(ClickHandler);
        }

        /// Removes the click listener.
        void OnDisable()
        {
            pressed.onClick.RemoveListener(ClickHandler);
        }
    }
}
