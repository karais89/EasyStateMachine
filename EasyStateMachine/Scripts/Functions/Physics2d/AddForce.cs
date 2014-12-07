//-----------------------------------------------------------------------
// <copyright file="AddForce.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Physics2d
{
    using UnityEngine;

    /// Adds force to the specified 2d rigidbody.
    [AddComponentMenu("Easy State Machine/Functions/Physics2d/Add Force")]
    public sealed class AddForce : Function
    {
        #region Input
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("Add")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// Name of the variable of type 'Vector2'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of type 'Vector2'.")]
        string force;

        /// Rigidbody2D.
        [SerializeField, Tooltip("Specify Rigidbody2D.")]
        Rigidbody2D to;

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
            Vector2 vector;
            if (TryGet(global, force, out vector, Vector2.zero))
                to.AddForce(vector);
        }
    }
}
