//-----------------------------------------------------------------------
// <copyright file="StateMachine.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine
{
    using UnityEngine;
    using System.Collections.Generic;
    using System.Text;

#if UNITY_EDITOR
    using UnityEditor;
#endif

    /// Represents a state machine.
    [AddComponentMenu("Easy State Machine/State Machine")]
    public sealed class StateMachine : State
    {
        [SerializeField, Tooltip("State machine will always start in this state, whenever enabled.")]
        State initialState = null;

        public State InitialState { get { return initialState; } }
        public State CurrentState { get; private set; }

        /// Indicates that the StateMachine wasn't 
        /// entered, even if it is already enabled.
        bool entered;

        /// Starts the StateMachine.
        protected override void OnEnable()
        {
            if (StateMachine == null && (!enabled || !entered))
            {
                Enter();
                entered = true;
            }

            base.OnEnable();
            Transit(InitialState);
        }

        /// Stops the StateMachine.
        protected override void OnDisable()
        {
            Transit(null);
            base.OnDisable();
            if (StateMachine == null && enabled)
                Exit();
        }

        /// Transits the StateMachine to the specified State. 
        /// Transition to null stops the StateMachine (but 
        /// does not reset it). Transition to InitialState will 
        /// start it again. It is better to use the enabled 
        /// property of MonoBehaviour to just start/stop the StateMachine. 
        /// IMPORTANT: Use this method with care and only if you know what you are doing.
        public void Transit(State next)
        {
            if (!IsPossibleTransitTo(next))
                return;

            if (CurrentState != null)
            {
                if (CurrentState.enabled)
                {
                    var temp = CurrentState;
                    CurrentState.enabled = false; 
                    if (!ReferenceEquals(temp, CurrentState))
                        return; // Another Transition already happened in OnDisable, no need to continue.
                }

                CurrentState.Exit();
            }

            CurrentState = next;
            if (CurrentState != null && !CurrentState.enabled)
            {
                CurrentState.Enter();
                CurrentState.enabled = true;
            }
        }

        /// Ensures that the transition to the specified State is possible.
        bool IsPossibleTransitTo(State next)
        {
            // TODO: remove this method, when TODOs in the TransitionEditor class will be implemented.
            if (next == null || next.StateMachine == this)
                return true;

#if UNITY_EDITOR
            Debug.LogError("State machine " + Path + " is trying to enter the state " + next.Path +
                           ", which does not belong to this state machine. Transition is not possible.");
            Debug.Break();
#endif
            return false;
        }

#if UNITY_EDITOR
        /// List of States of the current StateMachine.
        /// instance. Only necessary in Editor.
        [SerializeField, HideInInspector]
        List<State> states = new List<State>();

        /// Returns the StateMachine info.
        /// This info is shown in Inspector.
        public override string Info
        {
            get { return BuildInfo() + "\n" + base.Info; }
        }

        /// Builds the textual info from the specified list of States.
        private string BuildInfo()
        {
            states.RemoveAll(state => state == null);
            if (states == null || states.Count <= 0)
                return "There are no states present\n";

            var sb = new StringBuilder("States:");
            sb.AppendLine();
            foreach (var state in states)
            {
                sb.AppendLine(state.Path);
            }

            return sb.ToString();
        }

        /// Walks the states and stores them to the States
        /// List starting from InitialState and sets the 
        /// reference to the current StateMachine instance 
        /// to all connected States. 
        public void RebuildStateMachine()
        {
            states.Clear();
            if (InitialState != null)
                InitialState.SetStateMachine(states, this);
        }

        /// This event function is called in the Editor right 
        /// before the script is attached to the game object.
        /// This method checks, if that game object already has
        /// one StateMachine attached to it, and in case it 
        /// has, invokes the destruction of current StateMachine.
        void Reset()
        {
            if (GetComponents<StateMachine>().Length > 1)
                Invoke("DestroyThis", 0);
        }

        /// Destroys current StateMachine and shows messagebox with information.
        void DestroyThis()
        {
            DestroyImmediate(this);
            UnityEditor.EditorUtility.DisplayDialog("Easy State Machine",
                "You cannot have more than one StateMachine per game object.",
                "OK");
        }

        /// Draws Gizmos and Handles.
        /// Draws the name of the game object with StateMachine attached 
        /// and the name of the game object with current State attached.
        void OnDrawGizmos()
        {
            var tex = new Texture2D(1, 1);
            tex.SetPixels(new[] { Color.black });
            var style = new GUIStyle { normal = { textColor = enabled ? Color.green : Color.white, background = tex }, alignment = TextAnchor.UpperLeft };
            var message = name;
            if (CurrentState != null)
                message += ":" + CurrentState.name;

            Handles.Label(transform.position, message, style);
            DestroyImmediate(tex);
        }
#endif
    }
}