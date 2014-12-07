//-----------------------------------------------------------------------
// <copyright file="GetStateMachineVariable.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.StateMachine
{
    using UnityEngine;

    /// Gets variable from other state machine.
    [AddComponentMenu("Easy State Machine/Functions/State Machine/Get Variable")]
    public sealed class GetStateMachineVariable : Function
    {
        #region Input
#pragma warning disable 0649
        /// The name of the variable of specified type.
        [Header("Get")]
        [SerializeField, Tooltip("Specify the name of the variable of specified type.")]
        string variable;

        /// State machine.
        [Header("from state machine using")]
        [SerializeField, Tooltip("Specify the state machine.")]
        EasyStateMachine.StateMachine reference;

        /// State machine tag.
        [SerializeField, Tooltip("Specify the state machine tag.")]
        string _tag;

        /// State machine name.
        [SerializeField, Tooltip("Specify the state machine name.")]
        string orName;

        /// Is the variable below global?
        [Header("and store to")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// The name of the variable of specified type.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of specified type.")]
        string _variable;

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

            var stateMachine = GetStateMachine();
            if (stateMachine == null)
                return;

            var obj = stateMachine.Get(variable);
            if (obj == null)
                return;

            var storage = GetStorage(global);
            if (storage == null)
                return;

            storage.Set(_variable, obj);
        }

        /// Gets the state machine.
        EasyStateMachine.StateMachine GetStateMachine()
        {
            if (reference != null)
                return reference;

            var stateMachine = GetByTag();
            return (stateMachine == null) ? GetByName() : stateMachine;
        }

        /// Gets the state machine by tag.
        EasyStateMachine.StateMachine GetByTag()
        {
            if (string.IsNullOrEmpty(_tag))
                return null;

            var go = GameObject.FindGameObjectWithTag(_tag);
            if (go == null)
                return null;

            var stateMachine = go.GetComponent<EasyStateMachine.StateMachine>();
            return (stateMachine != null) ? stateMachine : null;
        }

        /// Gets the state machine by name.
        EasyStateMachine.StateMachine GetByName()
        {
            if (string.IsNullOrEmpty(orName))
                return null;

            var go = GameObject.Find(orName);
            if (go == null)
                return null;

            var stateMachine = go.GetComponent<EasyStateMachine.StateMachine>();
            return (stateMachine != null) ? stateMachine : null;
        }
    }
}
