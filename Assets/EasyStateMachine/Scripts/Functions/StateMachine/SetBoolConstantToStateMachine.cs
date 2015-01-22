//-----------------------------------------------------------------------
// <copyright file="SetBoolConstantToStateMachine.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.StateMachine
{
    using UnityEngine;

    /// Sets the bool constant to a variable of some StateMachine.
    [AddComponentMenu("Easy State Machine/Functions/State Machine/Set Bool Constant")]
    public sealed class SetBoolConstantToStateMachine : Function
    {
        // TODO: implement constant setter for other simple types.

        [Header("Set")]
        [SerializeField]
        Boolean boolConstant = Boolean.False;

        [Header("to the")]
        [SerializeField]
        string variable = null;

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
            var stateMachine = Get<EasyStateMachine.StateMachine> (reference, orTag, orName);
            if (stateMachine == null)
                return;

            var value = (boolConstant == Boolean.True);
            stateMachine.Set(variable, value);
        }
    }
}
