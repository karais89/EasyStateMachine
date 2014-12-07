//-----------------------------------------------------------------------
// <copyright file="CastVector2To3.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Vector.Vector2
{
    using UnityEngine;

    /// Casts Vector2 to Vector3.
    [AddComponentMenu("Easy State Machine/Functions/Vector/Vector2/Cast To Vector3")]
    public sealed class CastVector2To3 : Function
    {
        #region Input
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("Cast")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// The name of the variable of type 'Vector2'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of type 'Vector2'.")]
        string vector2;

        /// Z value.
        [Header("to Vector3 using")]
        [SerializeField, Tooltip("Specify Z component for Vector3.")]
        float z;

        /// Is the variable below global?
        [Header("and store the result to")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool _global;

        /// The name of the variable of type 'Vector3'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of type 'Vector3'.")]
        string vector3;

#pragma warning disable 1635
#pragma warning disable 0169
#pragma warning disable 0414
        /// Where the job should be done.
        [SerializeField, Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414
#pragma warning restore 0169
#pragma warning restore 1635
#pragma warning restore 0649
        #endregion

        /// Does the job.
        void Do()
        {
            Vector2 vector;
            if (TryGet(global, vector2, out vector, Vector2.zero))
                TrySet(_global, vector3, new Vector3(vector.x, vector.y, z));
        }
    }
}
