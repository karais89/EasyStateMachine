//-----------------------------------------------------------------------
// <copyright file="AddVector3.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Vector.Vector3
{
    using UnityEngine;

    /// Adds two Vector3 variables and stores the result to another Vector3 variable..
    [AddComponentMenu("Easy State Machine/Functions/Vector/Vector3/Add")]
    public sealed class AddVector3 : Function
    {
        [Header("Add the")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string vector3 = null;
        [Header("to the")]
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
            UnityEngine.Vector3 a;
            if (!TryGet(global, vector3, out a, UnityEngine.Vector3.zero))
                return;

            UnityEngine.Vector3 b;
            if (!TryGet(_global, _vector3, out b, UnityEngine.Vector3.zero))
                return;

            var result = b + a;
            TrySet(Global, Vector3, result);
        }
    }
}
