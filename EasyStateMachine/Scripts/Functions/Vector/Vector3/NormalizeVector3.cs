//-----------------------------------------------------------------------
// <copyright file="NormalizeVector3.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Vector.Vector3
{
    using UnityEngine;

    /// Normalizes Vector3.
    [AddComponentMenu("Easy State Machine/Functions/Vector/Vector3/Normalize")]
    public sealed class NormalizeVector3 : Function
    {
        #region Input
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("Normalize")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// The name of the variable of type 'Vector3'.
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
            Vector3 vector;
            if (!TryGet(global, vector3, out vector, Vector3.zero))
                return;
                
            vector.Normalize();
            TrySet(global, vector3, vector);
        }
    }
}
