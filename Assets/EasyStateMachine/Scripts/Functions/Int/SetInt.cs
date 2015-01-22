//-----------------------------------------------------------------------
// <copyright file="SetInt.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Int
{
    using UnityEngine;

    /// Sets the specified int value to an int variable.
    [AddComponentMenu("Easy State Machine/Functions/Int/Set")]
    public sealed class SetInt : Function
    {
        [Header("Set")]
        [SerializeField]
        int intValue = 0;

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
            TrySet(global, variable, intValue);
        }
    }
}
