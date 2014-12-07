//-----------------------------------------------------------------------
// <copyright file="Vector3ToFloats.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Vector.Vector3
{
    using UnityEngine;

    /// Stores Vector3 into three float variables.
    [AddComponentMenu("Easy State Machine/Functions/Vector/Vector3/To Floats")]
    public sealed class Vector3ToFloats : Function
    {
        #region Input
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("Store")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// Name of the variable of type 'Vector3'
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of type 'Vector3'.")]
        string vector3;

        /// Are the variables below global?
        [Header("into")]
        [SerializeField, Tooltip("Are the variables below global?")]
        bool globals;

        /// Name of the variable of type 'float', which will take the X component of the vector.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of type 'float', which will take the X component of the vector.")]
        string x;

        /// Name of the variable of type 'float', which will take the Y component of the vector.
        [SerializeField, Tooltip("Specify the name of the variable of type 'float', which will take the Y component of the vector.")]
        string y;

        /// Name of the variable of type 'float', which will take the Z component of the vector.
        [SerializeField, Tooltip("Specify the name of the variable of type 'float', which will take the Z component of the vector.")]
        string z;

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
            Vector3 value;
            if (!TryGet(global, vector3, out value, Vector3.zero))
                return;

            TrySet(globals, x, value.x);
            TrySet(globals, y, value.y);
            TrySet(globals, z, value.z);
        }
    }
}
