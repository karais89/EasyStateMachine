//-----------------------------------------------------------------------
// <copyright file="SetFloat.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Float
{
    using UnityEngine;

    /// Sets the specified float value to a float variable.
    [AddComponentMenu("Easy State Machine/Functions/Float/Set")]
    public sealed class SetFloat : Function
    {
        [Header("Set")]
        [SerializeField]
        float floatValue = 0f;

        [Header("to")]
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
            TrySet(global, variable, floatValue);
        }
    }
}
