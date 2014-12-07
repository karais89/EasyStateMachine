//-----------------------------------------------------------------------
// <copyright file="SetStateMachineVariable.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.StateMachine
{
    using UnityEngine;

    /// Sets variable to other state machine.
    [AddComponentMenu("Easy State Machine/Functions/State Machine/Set Variable")]
    public sealed class SetStateMachineVariable : Function
    {
        #region Input
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("Store")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// The name of the variable of specified type.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of specified type.")]
        string variable;

        /// The name of the variable of specified type.
        [Header("to")]
        [SerializeField, Tooltip("Specify the name of the variable of specified type.")]
        string _variable;

        /// CurrentStateTransition machine.
        [SerializeField, Tooltip("Specify the state machine.")]
        EasyStateMachine.StateMachine of;

#pragma warning disable 1635
#pragma warning disable 0169
#pragma warning disable 0414
        /// Where the job should be done.
        [SerializeField, Tooltip("Choose where the job should be done.")]
        In @in = In.OnEnable;
#pragma warning restore 0414
#pragma warning restore 0169
#pragma warning restore 1635
#pragma warning restore 0649
        #endregion

        /// Does the job.
        void Do()
        {
            if (string.IsNullOrEmpty(variable) || string.IsNullOrEmpty(_variable))
                return;

            var storage = GetStorage(global);
            if (storage == null)
                return;

            var obj = storage.Get(variable);
            if (obj == null)
                return;

            of.Set(_variable, obj);
        }
    }
}
