//-----------------------------------------------------------------------
// <copyright file="SetStateMachineBool.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.StateMachine
{
    using UnityEngine;

    /// Sets variable to other state machine.
    [AddComponentMenu("Easy State Machine/Functions/State Machine/Set Bool")]
    public sealed class SetStateMachineBool : Function
    {
        #region Input
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("Set")]
        [SerializeField, Tooltip("Specify the name of the variable of specified type.")]
        Boolean boolValue;

        /// The name of the variable of type 'bool'.
        [Header("to")]
        [SerializeField, Tooltip("Specify the name of the variable of type 'bool'.")]
        string variable;

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
            if (string.IsNullOrEmpty(variable))
                return;

            var value = (boolValue == Boolean.True);
            of.Set(variable, value);
        }
    }
}
