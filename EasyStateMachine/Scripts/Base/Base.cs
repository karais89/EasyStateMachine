//-----------------------------------------------------------------------
// <copyright file="Base.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine
{
    using UnityEngine;
    using System.Collections.Generic;
    using System.Text;

    /// Represent base class for state machine components.
    public abstract class Base : MonoBehaviour 
    {
#if UNITY_EDITOR
        /// Gets the component info.
        public string Info
        {
            get
            {
                var sceneHierarchyPath = GetSceneHierarchyPath ();
                var typeName = GetType ().Name;
                return sceneHierarchyPath + ":" + typeName;
            }
        }

        /// Gets the path of the game object in the scene hierarchy.
        string GetSceneHierarchyPath()
        {
            var obj = gameObject;
            var path = "/" + obj.name;
            while (obj.transform.parent != null)
            {
                obj = obj.transform.parent.gameObject;
                if(obj != null)
                    path = "/" + obj.name + path;
            }
            
            return path;
        }

        /// Gets the textual info about the specified 
        /// list of objects derived from Base.
        public string GetInfo<Type>(List<Type> lst)
            where Type : Base
        {
            lst.RemoveAll (item => item == null);
            var sb = new StringBuilder ();
            foreach (var item in lst) 
            {
                sb.AppendLine (item.Info);
            }
            
            return sb.ToString ();
        }
#endif
    }
}
