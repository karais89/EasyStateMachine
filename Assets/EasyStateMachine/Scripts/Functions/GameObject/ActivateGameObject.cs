//-----------------------------------------------------------------------
// <copyright file="ActivateGameObject.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.GameObject
{
    using UnityEngine;

    /// Activates/deactivates the specified GameObject.
    [AddComponentMenu("Easy State Machine/Functions/Game Object/Activate")]
    public sealed class ActivateGameObject : Function
    {
        [SerializeField]
        bool activate = true;

        [Header("GameObject, identified by")]
        [SerializeField]
        GameObject reference = null;

        [SerializeField]
        string orTag = null;

        [SerializeField]
        string orName = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.OnEnable;
#pragma warning restore 0414

        void Do()
        {
            var go = GetGameObject();
            if (go == null)
                return;

            if (go.gameObject.activeSelf != activate)
                go.gameObject.SetActive(activate);
        }

        GameObject GetGameObject()
        {
            if (reference != null)
                return reference;

            var go = GetByTag();
            return (go == null) ? GetByName() : go;
        }

        GameObject GetByTag()
        {
            return string.IsNullOrEmpty(orTag) ? null : GameObject.FindGameObjectWithTag(orTag);
        }

        GameObject GetByName()
        {
            return string.IsNullOrEmpty(orName) ? null : GameObject.Find(orName);
        }
    }
}
