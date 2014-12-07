//-----------------------------------------------------------------------
// <copyright file="MultiplyVector3.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Vector.Vector3
{
    using UnityEngine;

    /// Multiplies Vector3.
    [AddComponentMenu("Easy State Machine/Functions/Vector/Vector3/Multiply")]
    public sealed class MultiplyVector3 : Function
    {
        #region Input
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("Multiply")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// The name of the variable of type 'Vector3'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of type 'Vector3'.")]
        string vector3;

        /// Is the variable below global?
        [Header("by")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool _global;

        /// The name of the variable of type 'float'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of type 'float'.")]
        string @float;

        /// Is the variable below global?
        [Header("and store the result to")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool Global;

        /// The name of the variable of type 'Vector3'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of type 'Vector3'.")]
        string _vector3;

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
            if (!TryGet(global, vector3, out vector, Vector3.zero))
                return;

            float value;
            if (!TryGet(_global, @float, out value, 0f))
                return;

            var result = vector * value;
            TrySet(Global, _vector3, result);
        }
    }
}
