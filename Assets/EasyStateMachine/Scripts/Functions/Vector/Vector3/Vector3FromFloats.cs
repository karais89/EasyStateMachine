//-----------------------------------------------------------------------
// <copyright file="Vector3FromFloats.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Vector.Vector3
{
    using UnityEngine;

    /// Stores the specified float variables into the specified Vector3 variable.
    [AddComponentMenu("Easy State Machine/Functions/Vector/Vector3/From Floats")]
    public sealed class Vector3FromFloats : Function
    {
        [Header("Store the")]
        [SerializeField]
        bool globals = false;

        [SerializeField]
        string x = null;

        [SerializeField]
        string y = null;

        [SerializeField]
        string z = null;

        [Header("to the")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string vector3 = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414

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
