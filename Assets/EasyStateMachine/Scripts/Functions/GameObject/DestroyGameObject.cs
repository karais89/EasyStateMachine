//-----------------------------------------------------------------------
// <copyright file="DestroyGameObject.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.GameObject
{
    using UnityEngine;

    /// Destroys the specified GameObject.
    [AddComponentMenu("Easy State Machine/Functions/Game Object/Destroy")]
    public class DestroyGameObject : Function
    {
        [Header("Destroy GameObject, identified by")]
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
            if(go != null)
                Destroy(go);
        }

        GameObject GetGameObject()
        {
            if (reference != null)
                return reference;

            var obj = GetByTag();
            return (obj == null) ? GetByName() : obj;
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