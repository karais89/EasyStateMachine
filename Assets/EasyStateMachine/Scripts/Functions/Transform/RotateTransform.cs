//-----------------------------------------------------------------------
// <copyright file="RotateTransform.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Transform
{
    using UnityEngine;

    /// Rotates the specified  Transform.
    [AddComponentMenu("Easy State Machine/Functions/Transform/Rotate")]
    public sealed class RotateTransform : Function
    {
        [Header("Rotate")]
        [SerializeField]
        Transform the = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414

        [Header("using as angles the")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string vector3 = null;

        void Do()
        {
            Vector3 angles;
            if (!TryGet(global, vector3, out angles, Vector3.zero))
                return;

            the.Rotate(angles.x, angles.y, angles.z);
        }
    }
}
