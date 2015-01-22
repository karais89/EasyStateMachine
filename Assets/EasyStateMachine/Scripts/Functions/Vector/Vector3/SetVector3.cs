//-----------------------------------------------------------------------
// <copyright file="SetVector3.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Vector.Vector3
{
    using UnityEngine;

    /// Sets the specified Vector3 to the variable of type Vector3.
    [AddComponentMenu("Easy State Machine/Functions/Vector/Vector3/Set")]
    public sealed class SetVector3 : Function
    {
        [Header("Set")]
        [SerializeField]
        Vector3 vector3 = Vector3.zero;

        [Header("to the")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string variable = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.OnEnable;
#pragma warning restore 0414

        void Do()
        {
            TrySet(global, variable, vector3);
        }
    }
}
