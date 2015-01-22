//-----------------------------------------------------------------------
// <copyright file="AddForce.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Physics2d
{
    using UnityEngine;

    /// Adds force to the specified Rigidbody2D.
    [AddComponentMenu("Easy State Machine/Functions/Physics2d/Add Force")]
    public sealed class AddForce : Function
    {
        [Header("Add")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string force = null;

        [SerializeField]
        Rigidbody2D to = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        In @in = In.FixedUpdate;
#pragma warning restore 0414

        void Do()
        {
            Vector2 vector;
            if (TryGet(global, force, out vector, Vector2.zero))
                to.AddForce(vector);
        }
    }
}
