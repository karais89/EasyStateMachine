//-----------------------------------------------------------------------
// <copyright file="EnableBehaviour.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Behaviour
{
    using UnityEngine;

    /// Enables/disables the specified Behaviour.
    [AddComponentMenu("Easy State Machine/Functions/Behaviour/Enable")]
    public class EnableBehaviour : Function
    {
        [SerializeField]
        bool enable = true;

        [SerializeField]
        Behaviour the = null;

#pragma warning disable 0414
        [Space(8)] 
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414

        void Do()
        {
            if (the.enabled != enable)
                the.enabled = enable;
        }
    }
}
