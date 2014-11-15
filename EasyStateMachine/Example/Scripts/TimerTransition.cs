//-----------------------------------------------------------------------
// <copyright file="TimerTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Example
{
    using UnityEngine;
    using System.Collections;

    /// Represent the transition by timer.
    public class TimerTransition : Transition 
    {
        /// Time in seconds.
        [SerializeField, Tooltip("Time in seconds.")]
        float time;

        // Starts the Timer coroutine.
        void OnEnable()
        {
            StartCoroutine("Timer");
        }

        /// Timer.
        IEnumerator Timer()
        {
            yield return new WaitForSeconds(time);
            NeedTransit = true;
        }

        /// Stops the Timer coroutine.
        void OnDisable()
        {
            StopCoroutine ("Timer");
        }
    }
}
