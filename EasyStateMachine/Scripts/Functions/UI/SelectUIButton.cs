//-----------------------------------------------------------------------
// <copyright file="SelectUIButton.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.UI
{
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;

    /// Sets button colors.
    [AddComponentMenu("Easy State Machine/Functions/UI/Select Button")]
    public sealed class SelectUIButton : Function
    {
        #region Input
#pragma warning disable 0649
        /// Button from new Unity UI.
        [SerializeField, Tooltip("Button from new Unity UI.")]
        Button button;

#pragma warning disable 1635
#pragma warning disable 0169
#pragma warning disable 0414
        /// Where the job should be done.
        [SerializeField, Tooltip("Choose where the job should be done.")]
        In @in = In.OnEnable;
#pragma warning restore 0414
#pragma warning restore 0169
#pragma warning restore 1635
#pragma warning restore 0649
        #endregion

        // Does the job.
        void Do()
        {
            button.Select();
        }
    }
}