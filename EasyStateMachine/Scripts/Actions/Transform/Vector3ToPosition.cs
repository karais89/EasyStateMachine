//-----------------------------------------------------------------------
// <copyright file="Vector3ToPosition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Actions.Transform
{
    using UnityEngine;

    /// Represents the action, which sets the specified Vector3 to Transform.position.
    public class Vector3ToPosition : Action
    {
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("Set")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// Name of a variable of type 'Vector3'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of a variable of type 'Vector3'.")]
        string vector;

        /// Transform to set the position to.
        [Header("as position")]
        [SerializeField, Tooltip("Specify a Transform. If this field is left blank, the Transform of the GameObject this script is attached to will be used.")]
        Transform to;

        /// Where the action should happen.
        [SerializeField, Tooltip("Choose where the action should happen.")]
        Where @in;
#pragma warning restore 0649

        /// Where the action should happen. This property is used in the base class.
        protected override Where In { get { return @in; } }

        /// Sets the specified Vector3 as position to the specified transform.
        protected override void Do()
        {
            Vector3 position;
            if (!TryGet(vector, global, out position))
                return;

            (to != null ? to : transform).position = position;
        }
    }
}