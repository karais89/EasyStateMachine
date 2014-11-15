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

    /// Represents the editor part of StateMachine.
    [CustomEditor(typeof(StateMachine), true)]
    public class StateMachineEditor : EditorBase
    {
        /// Actual StateMachine component.
        StateMachine stateMachine;

        /// If is true, the info is drawn.
        bool needDrawInfo;

        /// Previously set starting state.
        State oldStartingState;

        /// Initialization.
        void OnEnable()
        {
            GetTarget (out stateMachine);
            oldStartingState = stateMachine.StartingState;
        }

        /// Updates the StateMachine Inspector.
        public override void OnInspectorGUI()
        {
            GetTarget (out stateMachine);
            DrawDefaultInspector ();
            HandleChanges();
            DrawInfo();
            DrawWarnings();
        }

        /// Handles GUI changes.
        void HandleChanges()
        {
            if(GUI.changed)
                HandleStartingStateChange();
        }

        /// Handles starting state changes.
        void HandleStartingStateChange()
        {
            if(oldStartingState != stateMachine.StartingState)
            {
                UpdateStateMachine(oldStartingState, null);
                oldStartingState = stateMachine.StartingState;
                UpdateStateMachine(oldStartingState, stateMachine);
            }
        }

        /// Sets the specified state machine to all connected states.
        public static void UpdateStateMachine(State startingState, StateMachine stateMachine)
        {
            if(stateMachine != null)
                stateMachine.SetStateMachineToStates();
            else if(startingState != null)
            {
                var processed = new List<State> ();
                startingState.SetStateMachine(processed, null);
            }
        }

        /// Shows info.
        void DrawInfo()
        {
            needDrawInfo = EditorGUILayout.Foldout(needDrawInfo, "State machine info");
            if (needDrawInfo) 
                EditorGUILayout.HelpBox (stateMachine.StatesInfo, MessageType.Info);
        }

        /// Shows warnings.
        void DrawWarnings()
        {
            if(stateMachine.StartingState == null)
                EditorGUILayout.HelpBox("Starting state is not assigned", MessageType.Warning);
        }
    }
}
