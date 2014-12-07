//-----------------------------------------------------------------------
// <copyright file="SetUIButtonColor.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.UI
{
    using UnityEngine;
    using UnityEngine.UI;

    /// Sets button colors.
    [AddComponentMenu("Easy State Machine/Functions/UI/Set Button Color")]
    public sealed class SetUIButtonColor : Function
    {
        #region Input
#pragma warning disable 0649
        /// Color to set.
        [SerializeField, Tooltip("Specify color to set.")]
        Color set = Color.white;

        /// Where to set the color
        [SerializeField, Tooltip("Choose where to set the color.")]
        ButtonColors @as;

        /// Button from new Unity UI.
        [SerializeField, Tooltip("Button from new Unity UI.")]
        Button to;

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
            var colors = to.colors;
            switch (@as)
            {
                case ButtonColors.NormalColor:
                    colors.normalColor = set;
                    break;
                case ButtonColors.HighlightedColor:
                    colors.highlightedColor = set;
                    break;
                case ButtonColors.PressedColor:
                    colors.pressedColor = set;
                    break;
                case ButtonColors.DisabledColor:
                    colors.disabledColor = set;
                    break;
            }
            to.colors = colors;
        }
    }
}