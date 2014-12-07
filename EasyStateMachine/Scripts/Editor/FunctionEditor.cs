//-----------------------------------------------------------------------
// <copyright file="FunctionEditor.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Editor
{
    using UnityEngine;
    using UnityEditor;

    /// Represents the Editor part of Function.
    [CustomEditor(typeof(Function), true)]
    public class FunctionEditor : EditorBase
    {
        #region Private
        /// Actual Function component.
        Function function;

        /// Previously set State.
        State previousState;

        /// Previously set pripority.
        int previousPriority;

        /// Initialization.
        void OnEnable()
        {
            GetTarget(out function);
            previousState = function.State;
            previousPriority = function.Priority;
        }
        #endregion

        /// Updates the Function Inspector GUI.
        public override void OnInspectorGUI()
        {
            GetTarget(out function);
            DisableWhenNotPlaying(function);
            DrawDefaultInspector();
            HandleChanges();
            DrawWarnings();
        }

        #region Private
        /// Handles GUI changes.
        void HandleChanges()
        {
            if (GUI.changed)
            {
                HandleStateChange();
                HandlePriorityChange();
            }
        }

        /// Handles State change.
        void HandleStateChange()
        {
            if (previousState == function.State)
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

        /// Handles priority change.
        void HandlePriorityChange()
        {
            if (previousPriority == function.Priority)
                return;

            var state = function.State;
            if (state != null)
            {
                state.SortFunctions();
                EditorUtility.SetDirty(state);
            }
        }

        /// Shows Function warnings.
        void DrawWarnings()
        {
            if (function.State == null)
                EditorGUILayout.HelpBox("State is not assigned.", MessageType.Warning);
        }
        #endregion
    }
}