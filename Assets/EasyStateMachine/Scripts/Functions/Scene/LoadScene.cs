//-----------------------------------------------------------------------
// <copyright file="LoadScene.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Scene
{
    using UnityEngine;

    /// Loads the specified scene.
    [AddComponentMenu("Easy State Machine/Functions/Scene/Load")]
    public sealed class LoadScene : Function
    {
        [SerializeField]
        bool additively = false;

        [Header("load the scene, identified by")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string variable = null;

        [SerializeField]
        string orSceneName = null;

        [SerializeField]
        int orSceneIndex = 0;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.OnEnable;
#pragma warning restore 0414

        [Header("Unity Pro feature:")]
        [SerializeField]
        bool async = false;

        [SerializeField]
        bool _global = false;

        [SerializeField,]
        string asyncOperation = null;

        void Do()
        {
            string sceneName;
            if (!TryGet(global, variable, out sceneName, null))
                sceneName = orSceneName;

            int sceneIndex;
            if (!TryGet(global, variable, out sceneIndex, -1))
                sceneIndex = orSceneIndex;

            if (async)
            {
                AsyncOperation asyncOp;
                if (string.IsNullOrEmpty(sceneName))
                    asyncOp = additively ? Application.LoadLevelAdditiveAsync(sceneIndex) : Application.LoadLevelAsync(sceneIndex);
                else
                    asyncOp = additively ? Application.LoadLevelAdditiveAsync(sceneName) : Application.LoadLevelAsync(sceneName);

                if(asyncOp != null && !string.IsNullOrEmpty(asyncOperation))
                    TrySet(_global, asyncOperation, asyncOp);
            }
            else
            {
                if (string.IsNullOrEmpty(sceneName))
                {
                    if (additively)
                        Application.LoadLevelAdditive(sceneIndex);
                    else
                        Application.LoadLevel(sceneIndex);
                }
                else
                {
                    if (additively)
                        Application.LoadLevelAdditive(sceneName);
                    else
                        Application.LoadLevel(sceneName);
                }
            }
        }
    }
}