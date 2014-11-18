//-----------------------------------------------------------------------
// <copyright file="TimerTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Transitions.Time
{
    using UnityEngine;

    /// Represent the transition, which waits for a timer.
    public sealed class TimerTransition : Transition
    {
#pragma warning disable 0649
        /// Time in seconds.
        [Header("Transit after"), SerializeField, Tooltip("Insert time in seconds.")]
        float seconds;

        /// Where the action should happen
        [SerializeField, Tooltip("Choose where the action should happen.")]
        Where @in;
#pragma warning restore 0649

        /// Where the action should happen. This property is used in the base class.
        protected override Where In { get { return @in; } }

        /// Temporary timer.
        private float timer;

        /// Checks, whether the transition should happen or not.
        protected override void Do()
        {
            timer += Time.deltaTime;
            if (timer >= seconds)
                NeedTransit = true;
        }

        /// Resets the timer.
        void OnEnable()
        {
            timer = 0f;
        }
    }
}
