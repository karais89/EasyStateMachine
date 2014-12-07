//-----------------------------------------------------------------------
// <copyright file="GetDeltaTime.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Time
{
    using UnityEngine;

    /// Represents the action, which gets teh screen size in screen coordinates as Vector3.
    [AddComponentMenu("Easy State Machine/Functions/Time/Get Delta Time")]
    public sealed class GetDeltaTime : Function
    {
        #region Input
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("Store delta time to")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// Name of the variable of type 'float'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of type 'float'.")]
        string @float;

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
            TrySet(global, @float, Time.deltaTime);
        }
    }
}
