//-----------------------------------------------------------------------
// <copyright file="TranslateTransform.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Transform
{
    using UnityEngine;

    /// Translates the Transform of an object.
    [AddComponentMenu("Easy State Machine/Functions/Transform/Translate")]
    public sealed class TranslateTransform : Function
    {
        #region Input
#pragma warning disable 0649
        /// Transform to translate.
        [Header("Translate")]
        [SerializeField, Tooltip("Specify Transform.")]
        Transform the;

#pragma warning disable 1635
#pragma warning disable 0169
#pragma warning disable 0414
        /// Where the job should be done.
        [SerializeField, Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414
#pragma warning restore 0169
#pragma warning restore 1635

        /// Is the variable below global?
        [Header("using the")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// Name of the variable of type 'Vector3'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of type 'Vector3'.")]
        string vector3;
#pragma warning restore 0649
        #endregion

        /// Does the job.
        void Do()
        {
            Vector3 step;
            TryGet(global, vector3, out step, Vector3.zero);
            the.Translate(step.x, step.y, step.z);
        }
    }
}
