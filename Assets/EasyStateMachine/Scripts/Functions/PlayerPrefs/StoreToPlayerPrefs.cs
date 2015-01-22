//-----------------------------------------------------------------------
// <copyright file="StoreToPlayerPrefs.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.PlayerPrefs
{
    using UnityEngine;

    /// Stores the value of a variable to PlayerPrefs.
    [AddComponentMenu("Easy State Machine/Functions/PlayerPrefs/Store")]
    public sealed class StoreToPlayerPrefs : Function
    {
        [Header("Store the")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string variable = null;

        [SerializeField]
        EasyStateMachine.PlayerPrefs ofType = EasyStateMachine.PlayerPrefs.Int;

        [Header("to PlaerPrefs using")]
        [SerializeField]
        string theKey = null;
       
#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.OnEnable;
#pragma warning restore 0414

        void Do()
        {
            switch (ofType)
            {
                case EasyStateMachine.PlayerPrefs.Int:
                {
                    int @int;
                    if (TryGet(global, variable, out @int, 0))
                        PlayerPrefs.SetInt(theKey, @int);
                    break;
                }
                case EasyStateMachine.PlayerPrefs.Float:
                {
                    float @float;
                    if (TryGet(global, variable, out @float, 0f))
                        PlayerPrefs.SetFloat(theKey, @float);
                    break;
                }
                case EasyStateMachine.PlayerPrefs.String:
                {
                    string @string;
                    if (TryGet(global, variable, out @string, string.Empty))
                        PlayerPrefs.SetString(theKey, @string);
                    break;
                }
            }
        }
    }
}