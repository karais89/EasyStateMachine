﻿//-----------------------------------------------------------------------
// <copyright file="SetVelocity.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Physics2d
{
    using UnityEngine;

    /// Sets velocity to Rigidbody2D.
    [AddComponentMenu("Easy State Machine/Functions/Physics2d/Set Velocity")]
    public sealed class SetVelocity : Function
    {
        #region Input
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("Set")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// Variable of type Vector2.
        [Space(24)]
        [SerializeField, Tooltip("Specify the variable of type Vector2.")]
        string vector2;

        /// Rigidbody2D.
        [Header("as velocity")]
        [SerializeField, Tooltip("Specify the Rigidbody2D.")]
        Rigidbody2D to;

#pragma warning disable 1635
#pragma warning disable 0169
#pragma warning disable 0414
        /// Where the job should be done.
        [Space(8)]
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
            Vector2 velocity;
            if (TryGet(global, vector2, out velocity, Vector2.zero))
                to.velocity = velocity;
        }
    }
}
