//-----------------------------------------------------------------------
// <copyright file="Translate.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Actions.Transform
{
    using UnityEngine;

    /// Represents the action, which translates the Transform of an object.
    public sealed class Translate : Action
    {
#pragma warning disable 0649
        /// Transform to translate.
        [Header("Translate")] 
        [SerializeField, Tooltip("Specify a Transform. If this field is left blank, the Transform of the GameObject the script is attached to will be used.")] 
        Transform the;

        /// Is the variable below global?
        [Header("using")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// Name of a variable of type 'Vector3'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of a variable of type 'Vector3'. Or leave this field blank to use the constant speed below.")]
        string variable;

        /// Where the action should happen.
        [Header("as speed")]
        [SerializeField, Tooltip("Choose where the action should happen.")]
        Where @in;

        // Constant speed in units per second.
        [Header("If speed is not specified, use")]
        [SerializeField, Tooltip("Specify the speed in units per second. Is used when the variable name above is left blank.")]
        Vector3 constantSpeed;
#pragma warning restore 0649

        /// Where the action should happen. This property is used in the base class.
        protected override Where In { get { return @in; } }

        /// Translates the specified transform.
        protected override void Do()
        {
            Vector3 speed;
            if (!TryGet(variable, global, out speed))
                speed = constantSpeed;

            var step = speed * Time.deltaTime;
            (the != null ? the : transform).Translate(step.x, step.y, step.z);
        }
    }
}
