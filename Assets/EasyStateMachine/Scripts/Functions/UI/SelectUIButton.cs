//-----------------------------------------------------------------------
// <copyright file="SelectUIButton.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.UI
{
    using UnityEngine;
    using UnityEngine.UI;

    /// Selects an UI button.
    [AddComponentMenu("Easy State Machine/Functions/UI/Select Button")]
    public sealed class SelectUIButton : Function
    {
        [Header("Select")]
        [SerializeField]
        Button the = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.OnEnable;
#pragma warning restore 0414

        void Do()
        {
            the.Select();
        }
    }
}