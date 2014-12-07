//-----------------------------------------------------------------------
// <copyright file="ScriptInteractions.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Examples
{
    using UnityEngine;
    using EasyStateMachine;

    /// Simple example of interaction with Easy State Machine from scripts.
    public class ScriptInteractions : MonoBehaviour
    {
#pragma warning disable 0649
        /// State machine.
        [SerializeField, Tooltip("Specify the state machine.")] 
        StateMachine _stateMachine;
#pragma warning restore 0649

        /// Variable to store the value obtained from states.
        int _counter;

        /// Update is called once per frame.
        void Update()
        {
            // Get the current state of the specified state machine.
            var state = _stateMachine.CurrentState;

            // Get the value of the "Counter" variable from the state.
            var obj = state.Get<int>("Counter");
            if (obj != null)
                _counter = (int)obj;
        }

        /// Draw GUI.
        void OnGUI()
        {
            var rect = new Rect(Screen.width / 2 - 10, Screen.height / 2 - 10, 20, 20);
            GUI.Label(rect, _counter.ToString());
        }
    }
}