//-----------------------------------------------------------------------
// <copyright file="PlayLegacyAnimation.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.LegacyAnimation
{
    using UnityEngine;

    /// Plays the specified legacy animation.
    [AddComponentMenu("Easy State Machine/Functions/Legacy Animation/Play")]
    public sealed class PlayLegacyAnimation : Function
    {
        [Header("Play")]
        [SerializeField]
        string clipWithName = null;

        [SerializeField]
        Animation inAnimation = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.OnEnable;
#pragma warning restore 0414

        void Do()
        {
            inAnimation.Play(clipWithName);
        }
    }
}