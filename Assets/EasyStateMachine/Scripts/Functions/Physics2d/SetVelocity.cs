//-----------------------------------------------------------------------
// <copyright file="SetVelocity.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Physics2d
{
    using UnityEngine;

    /// Sets velocity to Rigidbody2D.
    [AddComponentMenu("Easy State Machine/Functions/Physics2d/Set Velocity")]
    public sealed class SetVelocity : Function
    {
        [Header("Set")]
        [SerializeField]
        bool global = false;

        [SerializeField,]
        string vector2 = null;

        [Header("as velocity")]
        [SerializeField]
        Rigidbody2D to = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.FixedUpdate;
#pragma warning restore 0414

        void Do()
        {
            Vector2 velocity;
            if (TryGet(global, vector2, out velocity, Vector2.zero))
                to.velocity = velocity;
        }
    }
}
