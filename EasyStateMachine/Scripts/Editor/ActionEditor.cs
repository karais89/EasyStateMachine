//-----------------------------------------------------------------------
// <copyright file="ActionEditor.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Editor
{
    using UnityEngine;
    using UnityEditor;
    
    /// Represents the editor part of Action.
    [CustomEditor(typeof(Action), true)]
    public class ActionEditor : EditorBase
    {
        /// Actual Action component.
        Action action;

        /// Previously set state.
        State previousState;
        
        /// Initialization.
        void OnEnable()
        {
            GetTarget (out action);
            previousState = action.State;
        }
        
        /// Updates the Action inspector.
        public override void OnInspectorGUI()
        {
            GetTarget (out action);
            DisableWhenNotPlaying (action);
            DrawDefaultInspector ();
            HandleChanges ();
            DrawWarnings ();
        }

        /// Handles GUI changes.
        void HandleChanges()
        {
            if(GUI.changed)
                HandleStateChange();
        }
        
        /// Handles state change.
        void HandleStateChange()
        {
            if (previousState == action.State) 
                return;

            if (previousState != null) 
            {   
                previousState.RemoveAction (action);
                EditorUtility.SetDirty(previousState);
            }

            previousState = action.State;
            if (previousState != null)
            {
                previousState.AddAction(action);
                EditorUtility.SetDirty(previousState);
            }
        }

        /// Shows action warnings.
        void DrawWarnings()
        {
            if(action.State == null)
                EditorGUILayout.HelpBox("State is not assigned.", MessageType.Warning);   
        }
    }
}