//-----------------------------------------------------------------------
// <copyright file="GetVelocity.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Physics2d
{
    using UnityEngine;

    /// Gets the velocity of a Rigidbody2D.
    [AddComponentMenu("Easy State Machine/Functions/Physics2d/Get Velocity")]
    public sealed class GetVelocity : Function
    {
        [Header("Get the velocity ")]
        [SerializeField]
        Rigidbody2D of = null;

        [Header("and store it to")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string vector2 = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.FixedUpdate;
#pragma warning restore 0414

        void Do()
        {
            TrySet(global, vector2, of.velocity);
        }
    }
}
