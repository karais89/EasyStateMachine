//-----------------------------------------------------------------------
// <copyright file="ButtonDownTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Input.Transitions
{
    using UnityEngine;

    /// Transits if the soecified button is pressed.
    [AddComponentMenu("Easy State Machine/Functions/Input/Transitions/Button Down")]
    public sealed class ButtonDownTransition : Transition
    {
        [Header("if")]
        [SerializeField]
        string pressed = null;

        // TODO: implement other button events (up, continuous).

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414

        void Do()
        {
            if (Input.GetButtonDown(pressed))
                NeedTransit = true;
        }
    }
}
