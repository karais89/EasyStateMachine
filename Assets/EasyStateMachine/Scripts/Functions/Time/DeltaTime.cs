//-----------------------------------------------------------------------
// <copyright file="DeltaTime.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Time
{
    using UnityEngine;

    /// Gets the value of Time.deltaTime and stores it to a variable.
    [AddComponentMenu("Easy State Machine/Functions/Time/Delta Time")]
    public sealed class DeltaTime : Function
    {
        // TODO: implement other Functions to work with Time.
        [Header("Store delta time to")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string floatVariable = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414

        void Do()
        {
            TrySet(global, floatVariable, Time.deltaTime);
        }
    }
}
