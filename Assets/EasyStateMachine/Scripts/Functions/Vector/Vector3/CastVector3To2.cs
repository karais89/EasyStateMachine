//-----------------------------------------------------------------------
// <copyright file="CastVector3To2.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Vector.Vector2
{
    using UnityEngine;

    /// Casts Vector3 to Vector2.
    [AddComponentMenu("Easy State Machine/Functions/Vector/Vector3/Cast To Vector2")]
    public sealed class CastVector3To2 : Function
    {
        [Header("Cast to Vector2 the")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string vector3 = null;

        [Header("and store the result to the")]
        [SerializeField]
        bool _global = false;

        [SerializeField]
        string vector2 = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414

        void Do()
        {
            Vector3 vector;
            if (TryGet(global, vector3, out vector, Vector3.zero))
                TrySet(_global, vector2, new Vector2(vector.x, vector.y));
        }
    }
}
