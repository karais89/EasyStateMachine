//-----------------------------------------------------------------------
// <copyright file="Base.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine
{
    using UnityEngine;

    /// Represent the very base class for all Easy State Machine components.
    public abstract class Base : MonoBehaviour
    {
#if UNITY_EDITOR
        /// Gets the component path. It consists of the path to the game 
        /// object in the scene hierarchy and the type of the component.
        public string Path
        {
            get
            {
                var path = GetPathInSceneHierarchy();
                var component = GetType().Name;
                return path + ":" + component;
            }
        }

        string GetPathInSceneHierarchy()
        {
            var temp = gameObject.transform;
            if (temp == null)
                return "/" + gameObject.name;

            var path = string.Empty;
            while (temp != null)
            {
                path = "/" + temp.name + path;
                temp = temp.parent;
            }

            return path;
        }
#endif

        /// Gets the component T of a GameObject, identified either by reference, by tag or by name.
        public static T Get<T>(T byReference, string orTag, string orName)
            where T : Base
        {
            if (byReference != null)
                return byReference;
            
            var result = GetByTag<T>(orTag);
            return (result != null) ? result : GetByName<T>(orName);
            
        }
        
        /// Gets the component T of a GameObject, identified by tag.
        static T GetByTag<T>(string tag)
            where T : Base
        {
            if (string.IsNullOrEmpty(tag))
                return null;
            
            var go = GameObject.FindGameObjectWithTag(tag);
            if (go == null)
                return null;
            
            return go.GetComponent<T>();
        }
        
        /// Gets the component T of a GameObject, identified by name.
        static T GetByName<T>(string name)
            where T : Base
        {
            if (string.IsNullOrEmpty(name))
                return null; 
            
            var go = GameObject.Find(name);
            if (go == null)
                return null;
            
            return go.GetComponent<T>();
        }
    }
}
