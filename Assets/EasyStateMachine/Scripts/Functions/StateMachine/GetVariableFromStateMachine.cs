//-----------------------------------------------------------------------
// <copyright file="GetVariableFromStateMachine.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.StateMachine
{
    using UnityEngine;

    /// Gets a variable from some StateMachine.
    [AddComponentMenu("Easy State Machine/Functions/State Machine/Get Variable")]
    public sealed class GetVariableFromStateMachine : Function
    {
        [Header("Get")]
        [SerializeField]
        string theVariable = null;

        [Header("from the StateMachine, identified by")]
        [SerializeField]
        EasyStateMachine.StateMachine reference = null;

        [SerializeField]
        string orTag = null;

        [SerializeField]
        string orName = null;

        [Header("and store it to")]
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
            if (string.IsNullOrEmpty(theVariable) || string.IsNullOrEmpty(variable))
                return;

            var stateMachine = Get<EasyStateMachine.StateMachine> (reference, orTag, orName);
            if (stateMachine == null)
                return;

            var obj = stateMachine.Get(theVariable);
            if (obj == null)
                return;

            var storage = GetStorage(global);
            if (storage == null)
                return;

            storage.Set(variable, obj);
        }
    }
}
