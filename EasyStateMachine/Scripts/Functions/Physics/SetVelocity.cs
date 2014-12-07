//-----------------------------------------------------------------------
// <copyright file="SetVelocity.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Physics
{
    using UnityEngine;

    /// Sets velocity to Rigidbody.
    [AddComponentMenu("Easy State Machine/Functions/Physics/Set Velocity")]
    public sealed class SetVelocity : Function
    {
        #region Input
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("Set")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// Variable of type Vector3.
        [Space(24)]
        [SerializeField, Tooltip("Specify the variable of type Vector3.")]
        string vector3;

        /// Rigidbody.
        [Header("as velocity")]
        [SerializeField, Tooltip("Specify the Rigidbody.")]
        Rigidbody to;

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
            Vector3 velocity;
            if (TryGet(global, vector3, out velocity, Vector3.zero))
                to.velocity = velocity;
        }
    }
}
