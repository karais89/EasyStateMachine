//-----------------------------------------------------------------------
// <copyright file="TranslateAction.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Example
{
    using UnityEngine;

    /// Represents the action, which translates the object.
    public class TranslateAction : Action 
    {
        /// Transform to move to the right.
        [SerializeField, Tooltip("If this field is left blank, action will be applied to GameObject it is attached to.")]
        Transform transformToMove;
        
        /// Movement speed in units per second.
        [SerializeField, Tooltip("Movement speed in units per second.")]
        Vector3 speed;

        /// Initalization.
        void Awake()
        {
            if (transformToMove == null)
                transformToMove = transform;
        }
        
        /// Updates game object position.
        void Update () 
        {
            var step = speed * Time.deltaTime;
            transformToMove.Translate (step.x, step.y, step.z);
        }
    }
}
