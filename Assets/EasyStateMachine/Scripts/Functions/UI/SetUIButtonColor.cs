//-----------------------------------------------------------------------
// <copyright file="SetUIButtonColor.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.UI
{
    using UnityEngine;
    using UnityEngine.UI;

    /// Sets the color to a button.
    [AddComponentMenu("Easy State Machine/Functions/UI/Set Button Color")]
    public sealed class SetUIButtonColor : Function
    {
        [SerializeField]
        Color set = Color.white;

        [SerializeField]
        ButtonColors @as = ButtonColors.NormalColor;

        [SerializeField]
        Button to = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.OnEnable;
#pragma warning restore 0414

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