//-----------------------------------------------------------------------
// <copyright file="PositionToVector3.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Actions.Transform
{
    using UnityEngine;

    /// Represents the action, which stores the value of 
    /// Transform.position to the specified variable.
    public class PositionToVector3 : Action
    {
#pragma warning disable 0649
        /// Transform to read the position from.
        [Header("Store position")]
        [SerializeField, Tooltip("Specify a Transform. If this field is left blank, the Transform of the GameObject the script is attached to will be used.")] 
        Transform of;

        /// Is the variable below global?
        [Header("to")]
        [SerializeField, Tooltip("Is the variable below global?")] 
        bool global;

        /// Name of a variable of type 'Vector3'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of a variable of type 'Vector3', which will take the position of the transform.")]
        string vector;

        /// Where the action should happen.
        [SerializeField, Tooltip("Choose where the action should happen.")]
        Where @in;
#pragma warning restore 0649

        /// Where the action should happen. This property is used in the base class.
        protected override Where In { get { return @in; } }

        /// Stores the position of the specified transform to the specified Vector3.
        protected override void Do()
        {
            var position = (of != null ? of : transform).position;
            TrySet(vector, global, position);
        }
    }
}
