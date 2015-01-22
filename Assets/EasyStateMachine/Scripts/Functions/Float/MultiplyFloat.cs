//-----------------------------------------------------------------------
// <copyright file="MultiplyFloat.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Float
{
    using UnityEngine;

    /// Multiplies two float variables and store the result to another float variable.
    [AddComponentMenu("Easy State Machine/Functions/Float/Multiply")]
    public sealed class MultiplyFloat : Function
    {
        // TODO: implement other float ariphmetic operations.

        [Header("Multiply")]
        [SerializeField] 
        bool global = false;
        
        [SerializeField] 
        string @float = null;

        [Header("by")]
        [SerializeField] 
        bool _global = false;

        [SerializeField]
        string _float = null;

        [Header("and store the result to")]
        [SerializeField] 
        bool Global = false;

        [SerializeField]
        string Float = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414

        void Do()
        {
            float a;
            if (!TryGet(global, @float, out a, 0f))
                return;

            float b;
            if (!TryGet(_global, _float, out b, 0f))
                return;

            var result = a * b;
            TrySet(Global, Float, result);
        }
    }
}
