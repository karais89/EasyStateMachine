//-----------------------------------------------------------------------
// <copyright file="ImmediateTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Special.Transitions
{
    using UnityEngine;

    /// Transits immediately.
    [AddComponentMenu("Easy State Machine/Functions/Special/Transitions/Immediate")]
    public sealed class ImmediateTransition : Transition
    {
#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414

        void Do()
        {
            NeedTransit = true;
        }
    }
}
