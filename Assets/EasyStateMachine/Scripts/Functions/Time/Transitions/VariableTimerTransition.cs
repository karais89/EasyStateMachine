//-----------------------------------------------------------------------
// <copyright file="VariableTimerTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Time.Transitions
{
    using UnityEngine;

    /// Transites by variable timer.
    [AddComponentMenu("Easy State Machine/Functions/Time/Transitions/Variable Timer")]
    public sealed class VariableTimerTransition : Transition
    {
        [Header("after time stored in")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string floatVariable = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414

        float timeToWait;
        float timer;

        /// Resets the timer.
        void OnEnable()
        {
            timer = 0f;
            TryGet(global, floatVariable, out timeToWait, 0f);
        }

        void Do()
        {
            timer += Time.deltaTime;
            if (timer >= timeToWait)
                NeedTransit = true;
        }
    }
}
