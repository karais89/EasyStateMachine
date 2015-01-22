//-----------------------------------------------------------------------
// <copyright file="ConstantTimerTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Time.Transitions
{
    using UnityEngine;
    
    /// Transites by constant timer.
    [AddComponentMenu("Easy State Machine/Functions/Time/Transitions/Constant Timer")]
    public sealed class ConstantTimerTransition : Transition
    {
        [Header("after")]
        [SerializeField]
        float timeInSeconds = 0f;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414

        float timer;
        
        /// Resets the timer.
        void OnEnable()
        {
            timer = 0f;
        }
        
        void Do()
        {
            timer += Time.deltaTime;
            if (timer >= timeInSeconds)
                NeedTransit = true;
        }
    }
}
