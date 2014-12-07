//-----------------------------------------------------------------------
// <copyright file="Base.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine
{
    using UnityEngine;

    /// Represent the very base class for all Easy CurrentStateTransition Machine components.
    public abstract class Base : MonoBehaviour
    {
        #region Editor
#if UNITY_EDITOR
        /// Gets the component path. The path consists of the path 
        /// of the game object the component is attached to in 
        /// the scene hierarchy and the type of the component.
        public string Path
        {
            get
            {
                var sceneHierarchyPath = GetPathInSceneHierarchy();
                var typeName = GetType().Name;
                return sceneHierarchyPath + ":" + typeName;
            }
        }

        #region Private
        /// Gets the path of the game object the 
        /// component is attached to in scene hierarchy.
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
        #endregion
#endif
        #endregion
    }
}
