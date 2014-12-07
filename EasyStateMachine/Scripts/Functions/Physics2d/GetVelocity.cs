//-----------------------------------------------------------------------
// <copyright file="GetVelocity.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Physics2d
{
    using UnityEngine;

    /// Gets velocity from Rigidbody2D.
    [AddComponentMenu("Easy State Machine/Functions/Physics2d/Get Velocity")]
    public sealed class GetVelocity : Function
    {
        #region Input
#pragma warning disable 0649
        /// Rigidbody2D.
        [Header("Get velocity ")]
        [SerializeField, Tooltip("Specify the Rigidbody2D.")]
        Rigidbody2D from;

        /// Is the variable below global?
        [Header("and store it to")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// Variable of type Vector2.
        [Space(24)]
        [SerializeField, Tooltip("Specify the variable of type Vector2.")]
        string vector2;

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
            TrySet(global, vector2, from.velocity);
        }
    }
}
