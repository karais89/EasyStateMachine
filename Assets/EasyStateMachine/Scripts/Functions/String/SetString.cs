//-----------------------------------------------------------------------
// <copyright file="SetString.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.String
{
    using UnityEngine;

    /// Sets the specified value to the string variable.
    [AddComponentMenu("Easy State Machine/Functions/String/Set")]
    public sealed class SetString : Function
    {
        [Header("Set")]
        [SerializeField]
        string @string = string.Empty;

        [Header("to")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string stringVariable = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.OnEnable;
#pragma warning restore 0414

        void Do()
        {
            TrySet(global, stringVariable, @string);
        }
    }
}
