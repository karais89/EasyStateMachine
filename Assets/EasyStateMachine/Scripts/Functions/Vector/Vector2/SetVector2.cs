//-----------------------------------------------------------------------
// <copyright file="SetVector2.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Vector.Vector2
{
    using UnityEngine;

    /// Sets the specified Vector2 to the variable of type Vector2.
    [AddComponentMenu("Easy State Machine/Functions/Vector/Vector2/Set")]
    public sealed class SetVector2 : Function
    {
        [Header("Set")]
        [SerializeField]
        Vector2 vector2 = Vector2.zero;

        [Header("to the")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string variable = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.OnEnable;
#pragma warning restore 0414

        void Do()
        {
            TrySet(global, variable, vector2);
        }
    }
}
