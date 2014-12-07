//-----------------------------------------------------------------------
// <copyright file="LoadScene.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Scene
{
    using UnityEngine;

    /// Loads scene.
    [AddComponentMenu("Easy State Machine/Functions/Scene/Load")]
    public sealed class LoadScene : Function
    {
        #region Input
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("Load scene using")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// Variable containing scene name (string) or index (int).
        [Space(24)]
        [SerializeField, Tooltip("Variable containing scene name (string) or index (int).")]
        string variable;

        /// Scene name.
        [SerializeField, Tooltip("Scene name.")]
        string sceneName;

        /// Scene index.
        [SerializeField, Tooltip("Scene index.")]
        int orIndex;

        /// Additive loading.
        [SerializeField, Tooltip("If true, currently loaded scene will remain loaded.")]
        bool additive;

#pragma warning disable 1635
#pragma warning disable 0169
#pragma warning disable 0414
        /// Where the job should be done.
        [SerializeField, Tooltip("Choose where the job should be done.")]
        In @in = In.OnEnable;
#pragma warning restore 0414
#pragma warning restore 0169
#pragma warning restore 1635

        /// Asynchronous loading.
        [Header("Unity Pro")]
        [SerializeField, Tooltip("If true, will load the scene asynchronously. Pro-only feature")]
        bool async;

        /// Is the variable below global?
        [Space(24)]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool _global;

        /// The name of the variable of type 'AsyncOperation'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of type 'AsyncOperation'.")]
        string _asyncOperation;
#pragma warning restore 0649
        #endregion

        // Does the job.
        void Do()
        {
            string name;
            if (!TryGet(global, variable, out name, null))
                name = sceneName;

            int index;
            if (!TryGet(global, variable, out index, -1))
                index = orIndex;

            if (async)
            {
                AsyncOperation asyncOperation;
                if (string.IsNullOrEmpty(name))
                    asyncOperation = additive ? Application.LoadLevelAdditiveAsync(index) : Application.LoadLevelAsync(index);
                else
                    asyncOperation = additive ? Application.LoadLevelAdditiveAsync(name) : Application.LoadLevelAsync(name);

                if(asyncOperation != null && !string.IsNullOrEmpty(_asyncOperation))
                    TrySet(_global, _asyncOperation, asyncOperation);
            }
            else
            {
                if (string.IsNullOrEmpty(name))
                {
                    if (additive)
                        Application.LoadLevelAdditive(index);
                    else
                        Application.LoadLevel(index);
                }
                else
                {
                    if (additive)
                        Application.LoadLevelAdditive(name);
                    else
                        Application.LoadLevel(name);
                }
            }
        }
    }
}