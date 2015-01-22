//-----------------------------------------------------------------------
// <copyright file="SetAngularVelocity.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Physics2d
{
    using UnityEngine;

    /// Sets the angular velocity to Rigidbody2D. 
    [AddComponentMenu("Easy State Machine/Functions/Physics2d/Set Angular Velocity")]
    public sealed class SetAngularVelocity : Function
    {
        [Header("Set")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string floatVariable = null;

        [Header("as angular velocity")]
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
            float velocity;
            if (TryGet(global, @floatVariable, out velocity, 0f))
                to.angularVelocity = velocity;
        }
    }
}
