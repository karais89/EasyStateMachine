//-----------------------------------------------------------------------
// <copyright file="StateEditor.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Editor
{
    using UnityEditor;

    /// Represents the Editor part of State.
    [CustomEditor(typeof(State), true)]
    public class StateEditor : EditorBase
    {
        #region Private
        /// Actual State component.
        State state;

        /// If is true, the info is drawn.
        bool needDrawInfo;
        #endregion

        /// Updates the State Inspector GUI.
        public override void OnInspectorGUI()
        {
            GetTarget(out state);
            DisableWhenNotPlaying(state);
            DrawDefaultInspector();
            DrawInfo();
            DrawWarnings();
        }

        #region Private
        /// Shows info.
        void DrawInfo()
        {
            needDrawInfo = EditorGUILayout.Foldout(needDrawInfo, "State info");
            if (needDrawInfo)
            {
                if (state.StateMachine != null)
                    EditorGUILayout.HelpBox("State machine:\n" + state.StateMachine.Path, MessageType.Info);

                EditorGUILayout.HelpBox(state.Info, MessageType.Info);
                Repaint();
            }
        }

        /// Shows warnings.
        void DrawWarnings()
        {
            if (state.StateMachine == null)
                EditorGUILayout.HelpBox("State does not belong to any state machine", MessageType.Warning);
        }
        #endregion
    }
}