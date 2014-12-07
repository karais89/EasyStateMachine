//-----------------------------------------------------------------------
// <copyright file="IncrementInt.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Int
{
    using UnityEngine;

    /// Increments the variable of type 'int'.
    [AddComponentMenu("Easy State Machine/Functions/Int/Increment")]
    public sealed class IncrementInt : Function
    {
        #region Input
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("Increment")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// The name of the variable of type 'int'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of type 'int'.")]
        string @int;

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
            int value;
            if (!TryGet(global, @int, out value, 0))
                return;

            value++;
            TrySet(global, @int, value);
        }
    }
}
