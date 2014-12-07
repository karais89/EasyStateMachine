//-----------------------------------------------------------------------
// <copyright file="StateMachineEditor.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Editor
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEditor;

    /// Represents the Editor part of StateMachine.
    [CustomEditor(typeof(StateMachine), true)]
    public class StateMachineEditor : EditorBase
    {
        #region Private
        /// Actual StateMachine.
        StateMachine stateMachine;

        /// If it is true, the info is drawn.
        bool needDrawInfo;

        /// Previously set initial state.
        State oldInitialState;

        /// Initialization.
        void OnEnable()
        {
            GetTarget(out stateMachine);
            oldInitialState = stateMachine.InitialState;
        }
        #endregion

        /// Updates the StateMachine Inspector GUI.
        public override void OnInspectorGUI()
        {
            GetTarget(out stateMachine);
            DrawDefaultInspector();
            HandleChanges();
            DrawInfo();
            DrawWarnings();
        }

        #region Private
        /// Handles GUI changes.
        void HandleChanges()
        {
            if (GUI.changed)
                HandleInitialStateChange();
        }

        /// Handles initial state changes.
        void HandleInitialStateChange()
        {
            if (oldInitialState != stateMachine.InitialState)
            {
                ClearStateMachineForState(oldInitialState);
                oldInitialState = stateMachine.InitialState;
                RebuildStateMachine(stateMachine);
            }
        }

        /// Clears the state machine field of the specified state and all connected states.
        static void ClearStateMachineForState(State state)
        {
            if (state != null)
            {
                var processed = new List<State>();
                state.SetStateMachine(processed, null);
            }
        }

        /// Sets the specified state machine reference to all connected states.
        static void RebuildStateMachine(StateMachine stateMachine)
        {
            if (stateMachine != null)
                stateMachine.RebuildStateMachine();
        }

        /// Shows info.
        void DrawInfo()
        {
            needDrawInfo = EditorGUILayout.Foldout(needDrawInfo, "State machine info");
            if (needDrawInfo)
            {
                EditorGUILayout.HelpBox(stateMachine.Info, MessageType.Info);
                Repaint();
            }
        }

        /// Shows warnings.
        void DrawWarnings()
        {
            if (stateMachine.InitialState == null)
                EditorGUILayout.HelpBox("Initial state is not assigned", MessageType.Warning);
        }
        #endregion
    }
}