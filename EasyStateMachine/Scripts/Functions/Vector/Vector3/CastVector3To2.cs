//-----------------------------------------------------------------------
// <copyright file="CastVector3To2.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Vector.Vector2
{
    using UnityEngine;

    /// Casts Vector3 to Vector2.
    [AddComponentMenu("Easy State Machine/Functions/Vector/Vector3/Cast To Vector2")]
    public sealed class CastVector3To2 : Function
    {
        #region Input
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("Cast")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// The name of the variable of type 'Vector3'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of type 'Vector3'.")]
        string vector3;

        /// Is the variable below global?
        [Header("to Vector2 and store the result to")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool _global;

        /// The name of the variable of type 'Vector2'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of type 'Vector2'.")]
        string vector2;

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
            Vector3 vector;
            if (TryGet(global, vector3, out vector, Vector3.zero))
                TrySet(_global, vector2, new Vector2(vector.x, vector.y));
        }
    }
}
