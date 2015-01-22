//-----------------------------------------------------------------------
// <copyright file="GetTransformDirection.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Transform
{
    using UnityEngine;

    /// Gets the direction of the specified Transform.
    [AddComponentMenu("Easy State Machine/Functions/Transform/Get Direction")]
    public sealed class GetTransformDirection : Function
    {
        [Space(8)]
        [SerializeField]
        Direction getThe = Direction.Forward;

        [Header("direction")]
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
            var direction = Vector3.zero;
            switch (getThe)
            {
                case Direction.Forward:
                    direction = ofThe.forward;
                    break;
                case Direction.Right:
                    direction = ofThe.right;
                    break;
                case Direction.Up:
                    direction = ofThe.up;
                    break;
            }

            TrySet(global, vector3, direction);
        }
    }
}
