//-----------------------------------------------------------------------
// <copyright file="GetPosition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Transform
{
    using UnityEngine;

    /// Stores the value of Transform.position to Vector3.
    [AddComponentMenu("Easy State Machine/Functions/Transform/Get Position")]
    public sealed class GetTransformPosition : Function
    {
        #region Input
#pragma warning disable 0649
        /// Transform to read the position from.
        [Header("Store position")]
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
            TrySet(global, vector3, of.position);
        }
    }
}
