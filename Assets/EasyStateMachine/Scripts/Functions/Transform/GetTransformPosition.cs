//-----------------------------------------------------------------------
// <copyright file="GetTransformPosition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Transform
{
    using UnityEngine;

    /// Gets the position of the specified Transform.
    [AddComponentMenu("Easy State Machine/Functions/Transform/Get Position")]
    public sealed class GetTransformPosition : Function
    {
        // TODO: implement other Functions to work with Transform.

        [Header("Get the position")]
        [SerializeField]
        Transform ofThe = null;

        [Header("to")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string vector3 = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414

        void Do()
        {
            TrySet(global, vector3, ofThe.position);
        }
    }
}
