//-----------------------------------------------------------------------
// <copyright file="StateEditor.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Editor
{
    using UnityEditor;

    /// Represents the Editor part of the State class.
    [CustomEditor(typeof(State), true)]
    public class StateEditor : EditorBase
    {
        State state;
        bool needDrawInfo;

        /// Is called when the user changes something in the UI.
        public override void OnInspectorGUI()
        {
            GetTarget(out state);
            DisableWhenNotPlaying(state);
            DrawDefaultInspector();
            DrawInfo();
            DrawWarnings();
        }

        void DrawInfo()
        {
            needDrawInfo = EditorGUILayout.Foldout(needDrawInfo, "State info");
            if (!needDrawInfo)
                return;

            if (state.StateMachine != null)
                 EditorGUILayout.HelpBox("State machine:\n" + state.StateMachine.Path, MessageType.Info);

            EditorGUILayout.HelpBox(state.Info, MessageType.Info);
            Repaint();
        }

        void DrawWarnings()
        {
            if (state.StateMachine == null)
                EditorGUILayout.HelpBox("State does not belong to any state machine", MessageType.Warning);
        }
    }
}