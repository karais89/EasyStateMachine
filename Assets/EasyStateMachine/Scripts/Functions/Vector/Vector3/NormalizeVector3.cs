//-----------------------------------------------------------------------
// <copyright file="NormalizeVector3.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Vector.Vector3
{
    using UnityEngine;

    /// Normalizes the specified Vector3.
    [AddComponentMenu("Easy State Machine/Functions/Vector/Vector3/Normalize")]
    public sealed class NormalizeVector3 : Function
    {
        [Header("Normalize the")]
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
            Vector3 vector;
            if (!TryGet(global, vector3, out vector, Vector3.zero))
                return;
                
            vector.Normalize();
            TrySet(global, vector3, vector);
        }
    }
}
