//-----------------------------------------------------------------------
// <copyright file="DestroyGameObject.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.GameObject
{
    using UnityEngine;

    /// Destroys the specified GameObject.
    [AddComponentMenu("Easy State Machine/Functions/Game Object/Destroy")]
    public class DestroyGameObject : Function
    {
        #region Input
#pragma warning disable 0649
        /// GameObject.
        [Header("Destroy GameObject:")]
        [SerializeField, Tooltip("Specify the GameObject.")]
        GameObject reference;

        /// GameObject tag.
        [SerializeField, Tooltip("Specify the GameObject tag.")]
        string _tag;

        /// GameObject name.
        [SerializeField, Tooltip("Specify the GameObject name.")]
        string orName;

#pragma warning disable 1635
#pragma warning disable 0169
#pragma warning disable 0414
        /// Where the job should be done.
        [Space(8)]
        [SerializeField, Tooltip("Choose where the job should be done.")]
        In @in = In.OnEnable;
#pragma warning restore 0414
#pragma warning restore 0169
#pragma warning restore 1635
#pragma warning restore 0649
        #endregion

        /// Does the job.
        void Do()
        {
            var go = GetGameObject();
            Destroy(go);
        }

        /// Gets the GameObject.
        GameObject GetGameObject()
        {
            if (reference != null)
                return reference;

            var obj = GetByTag();
            return (obj == null) ? GetByName() : obj;
        }

        /// Gets the GameObject by tag.
        GameObject GetByTag()
        {
            return string.IsNullOrEmpty(_tag) ? null : GameObject.FindGameObjectWithTag(_tag);
        }

        /// Gets the GameObject by name.
        GameObject GetByName()
        {
            return string.IsNullOrEmpty(orName) ? null : GameObject.Find(orName);
        }
    }
}