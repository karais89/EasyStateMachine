//-----------------------------------------------------------------------
// <copyright file="TimerTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Transitions.Time
{
    using UnityEngine;

    /// Transition by timer.
    [AddComponentMenu("Easy State Machine/Transitions/Time/Timer")]
    public sealed class TimerTransition : Transition
    {
        #region Input
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("after time stored in")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// Name of the variable of type 'float' containing time in seconds.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of type 'float' containing time in seconds.")]
        string @float;

        /// Time in seconds.
        [Header("or, if variable is not specifed, after")]
        [SerializeField, Tooltip("Insert time in seconds.")]
        float seconds;

#pragma warning disable 1635
#pragma warning disable 0169
#pragma warning disable 0414
        /// Where the job should be done.
        [SerializeField, Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414
#pragma warning restore 0169
#pragma warning restore 1635
        #endregion

        /// Actual time to wait.
        float timeToWait;

        /// Temporary timer.
        float timer;

        /// Resets the timer.
        void OnEnable()
        {
            timer = 0f;
            TryGet(global, @float, out timeToWait, seconds);
        }

        /// Does the job.
        void Do()
        {
            timer += Time.deltaTime;
            if (timer >= timeToWait)
                NeedTransit = true;
        }
    }
}
