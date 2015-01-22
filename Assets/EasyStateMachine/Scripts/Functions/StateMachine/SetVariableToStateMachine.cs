//-----------------------------------------------------------------------
// <copyright file="SetVariableToStateMachine.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.StateMachine
{
    using UnityEngine;

    /// Sets the specified variable to the variable of some StateMachine.
    [AddComponentMenu("Easy State Machine/Functions/State Machine/Set Variable")]
    public sealed class SetVariableToStateMachine : Function
    {
        [Header("Set")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string variable = null;

        [Header("to")]
        [SerializeField]
        string _variable = null;

        [Header("of a StateMachine, identified by")]
        [SerializeField]
        EasyStateMachine.StateMachine reference = null;
        
        [SerializeField]
        string orTag = null;
        
        [SerializeField]
        string orName = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.OnEnable;
#pragma warning restore 0414

        void Do()
        {
            if (string.IsNullOrEmpty(variable) || string.IsNullOrEmpty(_variable))
                return;

            var stateMachine = Get<EasyStateMachine.StateMachine> (reference, orTag, orName);
            if(stateMachine == null)
                return;

            var storage = GetStorage(global);
            if (storage == null)
                return;

            var obj = storage.Get(variable);
            if (obj == null)
                return;

            stateMachine.Set(_variable, obj);
        }
    }
}
