//-----------------------------------------------------------------------
// <copyright file="EnableBehaviour.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Behaviour
{
    using UnityEngine;

    /// Enables/disables the specified Behaviour.
     [AddComponentMenu("Easy State Machine/Functions/Behaviour/Enable")]
    public class EnableBehaviour : Function
    {
        #region Input
#pragma warning disable 0649
        /// Should the Behaviour be enabled or disabled?
        [SerializeField, Tooltip("Should the Behaviour be enabled or disabled?")]
        bool enable = true;

        /// Behaviour.
        [SerializeField, Tooltip("Specify the Behaviour.")]
        Behaviour the;

#pragma warning disable 1635
#pragma warning disable 0169
#pragma warning disable 0414
        /// Where the job should be done.
        [SerializeField, Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414
#pragma warning restore 0169
#pragma warning restore 1635
#pragma warning restore 0649
        #endregion

        /// Does the job.
        void Do()
        {
            if (the.enabled != enable)
                the.enabled = enable;
        }
    }
}
