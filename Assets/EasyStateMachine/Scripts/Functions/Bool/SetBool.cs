//-----------------------------------------------------------------------
// <copyright file="SetBool.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Bool
{
    using UnityEngine;

    /// Sets the specified bool value to a bool variable.
    [AddComponentMenu("Easy State Machine/Functions/Bool/Set")]
    public sealed class SetBool : Function
    {
        [Header("Set")]
        [SerializeField]
        Boolean boolValue = Boolean.False;

        [Header("to")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string boolVariable = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.OnEnable;
#pragma warning restore 0414

        void Do()
        {
            var value = (boolValue == Boolean.True);
            TrySet(global, boolVariable, value);
        }
    }
}
