//-----------------------------------------------------------------------
// <copyright file="Vector3FromFloats.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Vector.Vector3
{
    using UnityEngine;

    /// Stores 3 float values into Vector3.
    [AddComponentMenu("Easy State Machine/Functions/Vector/Vector3/From Floats")]
    public sealed class Vector3FromFloats : Function
    {
        #region Input
#pragma warning disable 0649
        /// Are the variables below global?
        [Header("Store")]
        [SerializeField, Tooltip("Are the variables below global?")]
        bool globals;

        /// Name of the variable of type 'float', which represents the X component of 'Vector3'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of type 'float', which represents the X component of 'Vector3'.")]
        string x;

        /// Name of the variable of type 'float', which represents the Y component of 'Vector3'.
        [SerializeField, Tooltip("Specify the name of the variable of type 'float', which represents the Y component of 'Vector3'.")]
        string y;

        /// Name of the variable of type 'float', which represents the Z component of 'Vector3'.
        [SerializeField, Tooltip("Specify the name of the variable of type 'float', which represents the Z component of 'Vector3'.")]
        string z;

        /// Is the variable below global?
        [Header("into")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// Name of a variable of type 'Vector3'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of a variable of type 'Vector3'.")]
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
            if (string.IsNullOrEmpty(vector3))
                return;

            if (string.IsNullOrEmpty(x) &&
                string.IsNullOrEmpty(y) &&
                string.IsNullOrEmpty(z))
                return;

            Vector3 value;
            TryGet(global, vector3, out value, Vector3.zero);

            float xValue;
            if (TryGet(globals, x, out xValue, 0f))
                value.x = xValue;

            float yValue;
            if (TryGet(globals, y, out yValue, 0f))
                value.y = yValue;

            float zValue;
            if (TryGet(globals, z, out zValue, 0f))
                value.z = zValue;

            TrySet(global, vector3, value);
        }
    }
}
