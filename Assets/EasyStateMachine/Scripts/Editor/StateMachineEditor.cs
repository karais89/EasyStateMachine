//-----------------------------------------------------------------------
// <copyright file="StateMachineEditor.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Editor
{
    using UnityEngine;
    using UnityEditor;
    using System.Collections.Generic;

    /// Represents the Editor part of the StateMachine class.
    [CustomEditor(typeof(StateMachine), true)]
    public class StateMachineEditor : EditorBase
    {
        StateMachine stateMachine;
        bool needDrawInfo;
        State previousInitialState;

        void OnEnable()
        {
            GetTarget(out stateMachine);
            previousInitialState = stateMachine.InitialState;
        }

        /// Is called when the user changes something in the UI.
        public override void OnInspectorGUI()
        {
            GetTarget(out stateMachine);
            DrawDefaultInspector();
            HandleChanges();
            DrawInfo();
            DrawWarnings();
        }

        void HandleChanges()
        {
            if (GUI.changed)
                HandleInitialStateChange();
        }

        void HandleInitialStateChange()
        {
            if (previousInitialState != stateMachine.InitialState)
            {
                ClearStateMachineForState(previousInitialState);
                previousInitialState = stateMachine.InitialState;
                RebuildStateMachine(stateMachine);
            }
        }

        static void ClearStateMachineForState(State state)
        {
            if (state == null)
                return;
           
            // Clear the state machine field of the 
            // specified state and of all subsequent states.
            var processed = new List<State>();
            state.SetStateMachine(processed, null);
        }

        static void RebuildStateMachine(StateMachine stateMachine)
        {
            // If state machine exists, set the specified state 
            // machine reference to all connected states.
            if (stateMachine != null)
                stateMachine.RebuildStateMachine();
        }

        void DrawInfo()
        {
            needDrawInfo = EditorGUILayout.Foldout(needDrawInfo, "State machine info");
            if (!needDrawInfo)
                return;

            EditorGUILayout.HelpBox(stateMachine.Info, MessageType.Info);
            Repaint();
        }

        void DrawWarnings()
        {
            if (stateMachine.InitialState == null)
                EditorGUILayout.HelpBox("Initial state is not assigned", MessageType.Warning);
        }
    }
}