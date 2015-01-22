//-----------------------------------------------------------------------
// <copyright file="SetTransformPosition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Transform
{
    using UnityEngine;

    /// Sets the position to the specified Transform.
    [AddComponentMenu("Easy State Machine/Functions/Transform/Set Position")]
    public sealed class SetTransformPosition : Function
    {
        [Header("Set the")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string vector3 = null;

        [Header("as position")]
        [SerializeField]
        Transform toThe = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414

        void Do()
        {
            Vector3 vector;
            if (TryGet(global, vector3, out vector, Vector3.zero))
                toThe.position = vector;
        }
    }
}
