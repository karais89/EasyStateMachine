//-----------------------------------------------------------------------
// <copyright file="MultiplyVector3.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Vector.Vector3
{
    using UnityEngine;

    /// Multiplies Vector3 variable by float variable and stores the result to another Vector3.
    [AddComponentMenu("Easy State Machine/Functions/Vector/Vector3/Multiply")]
    public sealed class MultiplyVector3 : Function
    {
        [Header("Multiply the")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string vector3 = null;

        [Header("by the")]
        [SerializeField]
        bool _global = false;

        [SerializeField]
        string _float = null;

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

            float value;
            if (!TryGet(_global, _float, out value, 0f))
                return;

            var result = vector * value;
            TrySet(Global, Vector3, result);
        }
    }
}
