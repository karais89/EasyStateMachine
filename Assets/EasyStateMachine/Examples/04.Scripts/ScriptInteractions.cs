//-----------------------------------------------------------------------
// <copyright file="ScriptInteractions.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Examples
{
    using UnityEngine;

    /// Easy State Machine example. 
	/// Script <--> StateMachine interactions.
	[AddComponentMenu("Easy State Machine/Examples/Script Interactions")]
    public class ScriptInteractions : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField]
        [Tooltip("Specify the state machine.")] 
        StateMachine stateMachine;
#pragma warning restore 0649

        /// Variable to store the value.
        int counter;

        void Update()
        {
            // Get the current State of the specified StateMachine.
            var state = stateMachine.CurrentState;

            // Get the value of the int variable named "Counter" from the State.
            var obj = state.Get<int>("Counter");
            if (obj != null)
                counter = (int)obj;
        }

        /// Draw counter value.
        void OnGUI()
        {
            var rect = new Rect(Screen.width / 2 - 10, Screen.height / 2 - 10, 20, 20);
            GUI.Label(rect, counter.ToString());
        }
    }
}