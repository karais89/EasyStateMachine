//-----------------------------------------------------------------------
// <copyright file="EditorBase.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Editor
{
    using UnityEngine;
    using UnityEditor;

    /// Represents the base class for Easy State Machine Editor classes.
    public abstract class EditorBase : Editor
    {
        /// Gets the target Easy State Machine component.
        protected void GetTarget<TComponent>(out TComponent component)
            where TComponent : Base
        {
            component = (TComponent)target;
        }

        /// Disables the specified Easy State Machine 
        /// component when the application isn't playing.
        protected void DisableWhenNotPlaying<TComponent>(TComponent component)
            where TComponent : Base
        {
            if (Application.isPlaying)
                return;

            if (!component.enabled)
                return;

            component.enabled = false;
            EditorUtility.SetDirty(component);
        }
    }
}