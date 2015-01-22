//-----------------------------------------------------------------------
// <copyright file="FunctionEditor.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Editor
{
    using UnityEngine;
    using UnityEditor;

    /// Represents the Editor part of the Function class.
    [CustomEditor(typeof(Function), true)]
    public class FunctionEditor : EditorBase
    {
        Function function;
        State previousState;
        int previousPriority;

        void OnEnable()
        {
            GetTarget(out function);
            previousState = function.State;
            previousPriority = function.Priority;
        }

        /// Is called when the user changes something in the UI.
        public override void OnInspectorGUI()
        {
            GetTarget(out function);
            DisableWhenNotPlaying(function);
            DrawDefaultInspector();
            HandleChanges();
            DrawWarnings();
        }

        void HandleChanges()
        {
            if (!GUI.changed)
                return;

            HandleStateChange();
            HandlePriorityChange();
        }

        void HandleStateChange()
        {
            if (ReferenceEquals(previousState, function.State))
                return;

            if (previousState != null)
            {
                previousState.RemoveFunction(function);
                EditorUtility.SetDirty(previousState);
            }

            previousState = function.State;
            if (previousState != null)
            {
                previousState.AddFunction(function);
                EditorUtility.SetDirty(previousState);
            }
        }

        void HandlePriorityChange()
        {
            if (previousPriority == function.Priority)
                return;

            var state = function.State;
            if (state == null)
                return;

            state.RemoveNullFunctions ();
            state.SortFunctions();
            EditorUtility.SetDirty(state);
        }

        void DrawWarnings()
        {
            if (function.State == null)
                EditorGUILayout.HelpBox("State is not assigned.", MessageType.Warning);
        }
    }
}