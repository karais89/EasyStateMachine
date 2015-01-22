//-----------------------------------------------------------------------
// <copyright file="ReflectVector3.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Vector.Vector3
{
    using UnityEngine;

    /// Reflects the specified Vector3.
    [AddComponentMenu("Easy State Machine/Functions/Vector/Vector3/Reflect")]
    public sealed class ReflectVector3 : Function
    {
        [Header("Reflect the")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string vector3 = null;

        [Header("using the normal, stored in")]
        [SerializeField]
        bool _global = false;

        [SerializeField]
        string _vector3 = null;

        [Header("and store the result to the")]
        [SerializeField]
        bool Global = false;

        [SerializeField]
        string Vector3 = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414

        void Do()
        {
            Vector3 vector;
            if (!TryGet(global, vector3, out vector, UnityEngine.Vector3.zero))
                return;

            Vector3 normal;
            if (!TryGet(_global, _vector3, out normal, UnityEngine.Vector3.zero))
                return;

            var result = UnityEngine.Vector3.Reflect(vector, normal);
            TrySet(Global, Vector3, result);
        }
    }
}
