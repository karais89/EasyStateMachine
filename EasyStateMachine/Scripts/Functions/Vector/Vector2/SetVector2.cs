//-----------------------------------------------------------------------
// <copyright file="SetVector2.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Vector.Vector2
{
    using UnityEngine;

    /// Sets variable of type 'Vector2'.
    [AddComponentMenu("Easy State Machine/Functions/Vector/Vector2/Set")]
    public sealed class SetVector2 : Function
    {
        #region Input
#pragma warning disable 0649
        /// The value of type 'Vector2'.
        [Header("Set")]
        [SerializeField, Tooltip("Specify the value of type 'Vector2'.")]
        Vector2 vector2;

        /// Is the variable below global?
        [Header("to")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// The name of the variable of type 'Vector2'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of type 'Vector2'.")]
        string variable;

#pragma warning disable 1635
#pragma warning disable 0169
#pragma warning disable 0414
        /// Where the job should be done.
        [SerializeField, Tooltip("Choose where the job should be done.")]
        In @in = In.OnEnable;
#pragma warning restore 0414
#pragma warning restore 0169
#pragma warning restore 1635
#pragma warning restore 0649
        #endregion

        /// Does the job.
        void Do()
        {
            TrySet(global, variable, vector2);
        }
    }
}
