//-----------------------------------------------------------------------
// <copyright file="StateMachine.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine
{
    using UnityEngine;
    using System.Collections.Generic;
    using System.Text;

    #region Editor
#if UNITY_EDITOR
    using UnityEditor;
#endif
    #endregion

    /// Represents the state machine.
    [AddComponentMenu("Easy State Machine/State Machine")]
    public sealed class StateMachine : State
    {
        #region Private
#pragma warning disable 0649
        /// State machine will always start with this state, whenever enabled.
        [SerializeField, Tooltip("State machine will always start with this state, whenever enabled.")]
        State initialState;
#pragma warning restore 0649
        #endregion

        /// Gets the initial state.
        public State InitialState { get { return initialState; } }

        /// Gets the current state.
        public State CurrentState { get; private set; }

        #region Private
        /// Indicates, that the state machine wasn't entered, even if it is already enabled.
        bool _entered;
        #endregion

        /// Starts the state machine.
        protected override void OnEnable()
        {
            if (StateMachine == null && (!enabled || !_entered))
            {
                Enter();
                _entered = true;
            }

            base.OnEnable();
            Transit(InitialState);
        }

        /// Stops the state machine.
        protected override void OnDisable()
        {
            Transit(null);
            base.OnDisable();
            if (StateMachine == null && enabled)
                Exit();
        }

        /// Transits the state machine to te specified state. 
        /// !!! Use this method directly with care and only 
        /// !!! if you know what you are doing.
        /// 
        /// Transition to 'null' stops the state machine 
        /// (but doesn't reset the variables!). Transition to
        /// 'InitialState' will start it again. 
        /// !!! It is better to use 'enabled' property to 
        /// !!! just start/stop the state machine. 
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
                        return; // Another Transition happened in OnDisable, no need to continue anymore.
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

        #region Private
        /// Ensures that the transition to the specified state is possible.
        bool IsPossibleTransitTo(State next)
        {
            if (next == null || next.StateMachine == this)
                return true;

            #region Editor
#if UNITY_EDITOR
            Debug.LogError("State machine " + Path + " is trying to enter the state " + next.Path +
                           ", which does not belong to this state machine. Transition is not possible.");
            Debug.Break();
#endif
            #endregion
            return false;
        }
        #endregion

        #region Editor
#if UNITY_EDITOR
        #region Private
        /// List of states in the StateMachine.
        [SerializeField, HideInInspector]
        List<State> _states = new List<State>();
        #endregion

        /// Gets the state machine info.
        public override string Info
        {
            get { return BuildInfo() + "\n" + base.Info; }
        }

        #region Private
        /// Gets the textual info about the specified list of states.
        private string BuildInfo()
        {
            _states.RemoveAll(state => state == null);
            if (_states == null || _states.Count <= 0)
                return "There are no states present\n";

            var sb = new StringBuilder("States:");
            sb.AppendLine();
            foreach (var state in _states)
            {
                sb.AppendLine(state.Path);
            }

            return sb.ToString();
        }
        #endregion

        /// Sets the state machine reference to all connected states.
        public void RebuildStateMachine()
        {
            _states.Clear();
            if (InitialState != null)
                InitialState.SetStateMachine(_states, this);
        }

        #region Private
        /// This event function is called right before the 
        /// script is attached to the game object in Editor.
        /// This method checks, if game object already has
        /// one StateMachine attached to it and in case it 
        /// has, invokes the destruction of current StateMachine.
        void Reset()
        {
            if (GetComponents<StateMachine>().Length > 1)
                Invoke("DestroyThis", 0);
        }

        /// Destroys current StateMachine and shows the messagebox 
        /// with information why that was done.
        void DestroyThis()
        {
            DestroyImmediate(this);
            UnityEditor.EditorUtility.DisplayDialog("Easy State Machine",
                "This game object already has one state machine attached." +
                "You cannot have more than one state machine per object.",
                "OK");
        }

        /// Draws Gizmos and Handles.
        void OnDrawGizmos()
        {
            var tex = new Texture2D(1, 1);
            tex.SetPixels(new[] { Color.black });
            var style = new GUIStyle { normal = { textColor = enabled ? Color.green : Color.white, background = tex }, alignment = TextAnchor.UpperLeft };
            var message = transform.name;
            if (CurrentState != null)
                message += ":" + CurrentState.name;

            Handles.Label(transform.position, message, style);
            DestroyImmediate(tex);
        }
        #endregion
#endif
        #endregion
    }
}