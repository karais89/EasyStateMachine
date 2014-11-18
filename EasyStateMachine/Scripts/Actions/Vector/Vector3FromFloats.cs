//-----------------------------------------------------------------------
// <copyright file="Vector3FromFloats.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Actions.Vector
{
    using UnityEngine;

    /// Represents the action, which stores 3 float values into Vector3.
    public class Vector3FromFloats : Action
    {
#pragma warning disable 0649
        /// Are the variables below global?
        [Header("Store")]
        [SerializeField, Tooltip("Are the variables below global?")]
        bool globals;

        /// Name of a variable of type 'float', which represents the X component of 'Vector3'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of a variable of type 'float', which represents the X component of 'Vector3'.")]
        string x;

        /// Name of a variable of type 'float', which represents the Y component of 'Vector3'.
        [SerializeField, Tooltip("Specify the name of a variable of type 'float', which represents the Y component of 'Vector3'.")]
        string y;

        /// Name of a variable of type 'float', which represents the Z component of 'Vector3'.
        [SerializeField, Tooltip("Specify the name of a variable of type 'float', which represents the Z component of 'Vector3'.")]
        string z;

        /// Is the variable below global?
        [Header("into")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// Name of a variable of type 'Vector3'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of a variable of type 'Vector3'.")]
        string vector;

        /// Where the action should happen.
        [SerializeField, Tooltip("Choose where the action should happen.")]
        Where @in;
#pragma warning restore 0649

        /// Where the action should happen. This property is used in the base class.
        protected override Where In { get { return @in; } }

        /// Stores separate variables into vector.
        protected override void Do()
        {
            if (string.IsNullOrEmpty(vector))
                return;

            if (string.IsNullOrEmpty(x) && 
                string.IsNullOrEmpty(y) && 
                string.IsNullOrEmpty(z))
                return;

            Vector3 value;
            if (!TryGet(vector, global, out value))
                value = Vector3.zero;

            float xValue;
            if (TryGet(x, globals, out xValue))
                value.x = xValue;

            float yValue;
            if (TryGet(y, globals, out yValue))
                value.y = yValue;

            float zValue;
            if (TryGet(z, globals, out zValue))
                value.z = zValue;

            TrySet(vector, global, value);
        }
    }
}
