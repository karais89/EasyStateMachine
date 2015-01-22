//-----------------------------------------------------------------------
// <copyright file="CastVector2To3.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Vector.Vector2
{
    using UnityEngine;

    /// Casts Vector2 to Vector3.
    [AddComponentMenu("Easy State Machine/Functions/Vector/Vector2/Cast To Vector3")]
    public sealed class CastVector2To3 : Function
    {
        [Header("Cast")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string vector2 = null;

        [Header("to Vector3 using")]
        [SerializeField]
        float z = 0f;

        [Header("and store the result to")]
        [SerializeField]
        bool _global = false;

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
            Vector2 vector;
            if (TryGet(global, vector2, out vector, Vector2.zero))
                TrySet(_global, vector3, new Vector3(vector.x, vector.y, z));
        }
    }
}
