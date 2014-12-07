//-----------------------------------------------------------------------
// <copyright file="SetKinematic.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Physics2d
{
    using UnityEngine;

    /// Sets kinematic flag to Rigidbody2D.
    [AddComponentMenu("Easy State Machine/Functions/Physics2d/Set Kinematic")]
    public sealed class SetKinematic : Function
    {
        #region Input
#pragma warning disable 0649
        /// Should the Rigidbody2D be kinematic or not?
        [Header("Set")]
        [SerializeField, Tooltip("Should the Rigidbody2D be kinematic or not?")]
        bool kinematic = true;

        /// Rigidbody2D.
        [Space(24)]
        [SerializeField, Tooltip("Specify the Rigidbody2D.")]
        Rigidbody2D to;

#pragma warning disable 1635
#pragma warning disable 0169
#pragma warning disable 0414
        /// Where the job should be done.
        [Space(8)]
        [SerializeField, Tooltip("Choose where the job should be done.")]
        In @in = In.OnEnable;
#pragma warning restore 0414
#pragma warning restore 0169
#pragma warning restore 1635
#pragma warning restore 0649
        #endregion

        /// Does the job.
        void Do()
        {
            if (to.isKinematic != kinematic)
                to.isKinematic = kinematic;
        }
    }
}
