//-----------------------------------------------------------------------
// <copyright file="SetKinematic.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Physics2d
{
    using UnityEngine;

    /// Sets kinematic flag to Rigidbody2D.
    [AddComponentMenu("Easy State Machine/Functions/Physics2d/Set Kinematic")]
    public sealed class SetKinematic : Function
    {
        [Header("Set")]
        [SerializeField]
        bool kinematic = true;

        [SerializeField]
        Rigidbody2D to = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.OnEnable;
#pragma warning restore 0414

        void Do()
        {
            if (to.isKinematic != kinematic)
                to.isKinematic = kinematic;
        }
    }
}
