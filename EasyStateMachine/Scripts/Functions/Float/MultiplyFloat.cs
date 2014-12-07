﻿//-----------------------------------------------------------------------
// <copyright file="MultiplyFloat.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Float
{
    using UnityEngine;

    /// Multiplies two float variables.
    [AddComponentMenu("Easy State Machine/Functions/Float/Multiply")]
    public sealed class MultiplyFloat : Function
    {
        #region Input
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("Multiply")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// The name of the variable of type 'float'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of type 'float'.")]
        string @float;

        /// Is the variable below global?
        [Header("by")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool _global;

        /// The name of the variable of type 'float'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of type 'float'.")]
        string _float;

        /// Is the variable below global?
        [Header("and store the result to")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool Global;

        /// The name of the variable of type 'float'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of type 'float'.")]
        string Float;

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
            float a;
            if (!TryGet(global, @float, out a, 0f))
                return;

            float b;
            if (!TryGet(_global, _float, out b, 0f))
                return;

            var result = a * b;
            TrySet(Global, Float, result);
        }
    }
}
