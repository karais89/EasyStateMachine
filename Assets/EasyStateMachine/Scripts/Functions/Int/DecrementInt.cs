//-----------------------------------------------------------------------
// <copyright file="DecrementInt.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Int
{
    using UnityEngine;

    /// Decrements the variable of type int.
    [AddComponentMenu("Easy State Machine/Functions/Int/Decrement")]
    public sealed class DecrementInt : Function
    {
        [Header("Decrement")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string intVariable = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414

        void Do()
        {
            int value;
            if (!TryGet(global, intVariable, out value, 0))
                return;

            value--;
            TrySet(global, intVariable, value);
        }
    }
}
