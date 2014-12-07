//-----------------------------------------------------------------------
// <copyright file="GetTransformDirection.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Transform
{
    using UnityEngine;

    /// Gets the transform direction.
    [AddComponentMenu("Easy State Machine/Functions/Transform/Get Direction")]
    public sealed class GetTransformDirection : Function
    {
        #region Input
#pragma warning disable 0649
        [Space(8)]
        [SerializeField, Tooltip("Specify Transform.")]
        Direction store = Direction.Forward;

        /// Transform to read the position from.
        [Header("direction")]
        [SerializeField, Tooltip("Specify Transform.")]
        Transform of;

        /// Is the variable below global?
        [Header("to")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// Name of the variable of type 'Vector3'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of type 'Vector3'.")]
        string vector3;

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
            var direction = Vector3.zero;
            switch (store)
            {
                case Direction.Forward:
                    direction = of.forward;
                    break;
                case Direction.Right:
                    direction = of.right;
                    break;
                case Direction.Up:
                    direction = of.up;
                    break;
            }

            TrySet(global, vector3, direction);
        }
    }
}
