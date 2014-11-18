//-----------------------------------------------------------------------
// <copyright file="Vector3ToFloats.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Actions.Vector
{
    using UnityEngine;

    /// Represents the action, which stores 
    /// Vector3 into three float variables.
    public class Vector3ToFloats : Action
    {
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("Store")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// Name of a variable of type 'Vector3'
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of a variable of type 'Vector3'.")]
        string vector;

        /// Are the variables below global?
        [Header("into")]
        [SerializeField, Tooltip("Are the variables below global?")]
        bool globals;

        /// Name of a variable of type 'float', which will take the X component of the vector.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of a variable of type 'float', which will take the X component of the vector.")]
        string x;

        /// Name of a variable of type 'float', which will take the Y component of the vector.
        [SerializeField, Tooltip("Specify the name of a variable of type 'float', which will take the Y component of the vector.")]
        string y;

        /// Name of a variable of type 'float', which will take the Z component of the vector.
        [SerializeField, Tooltip("Specify the name of a variable of type 'float', which will take the Z component of the vector.")]
        string z;

        /// Where the action should happen.
        [SerializeField, Tooltip("Choose where the action should happen.")]
        Where @in;
#pragma warning restore 0649

        /// Where the action should happen. This property is used in the base class.
        protected override Where In { get { return @in; } }

        /// Stores the vector into separate variables.
        protected override void Do()
        {
            Vector3 value;
            if (!TryGet(vector, global, out value))
                return;

            TrySet(x, globals, value.x);
            TrySet(y, globals, value.y);
            TrySet(z, globals, value.z);
        }
    }
}
