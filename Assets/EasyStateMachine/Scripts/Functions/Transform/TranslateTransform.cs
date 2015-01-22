//-----------------------------------------------------------------------
// <copyright file="TranslateTransform.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Transform
{
    using UnityEngine;

    /// Translates the specified Transform.
    [AddComponentMenu("Easy State Machine/Functions/Transform/Translate")]
    public sealed class TranslateTransform : Function
    {
        [Header("Translate")]
        [SerializeField]
        Transform the = null;

        [Header("to the value of")]
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
            Vector3 step;
            TryGet(global, vector3, out step, Vector3.zero);
            the.Translate(step.x, step.y, step.z);
        }
    }
}
