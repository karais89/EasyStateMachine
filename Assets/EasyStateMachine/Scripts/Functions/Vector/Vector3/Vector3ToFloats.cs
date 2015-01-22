//-----------------------------------------------------------------------
// <copyright file="Vector3ToFloats.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Vector.Vector3
{
    using UnityEngine;

    /// Stores the specified Vector3 variable into the specified float variables.
    [AddComponentMenu("Easy State Machine/Functions/Vector/Vector3/To Floats")]
    public sealed class Vector3ToFloats : Function
    {
        [Header("Store the")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string vector3 = null;

        [Header("to the")]
        [SerializeField]
        bool globals = false;

        [SerializeField]
        string x = null;

        [SerializeField]
        string y = null;

        [SerializeField]
        string z = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414

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
