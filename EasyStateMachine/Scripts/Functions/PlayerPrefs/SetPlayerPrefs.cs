//-----------------------------------------------------------------------
// <copyright file="SetPlayerPrefs.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.PlayerPrefs
{
    using UnityEngine;

    /// Stores a variable into player preferences.
    [AddComponentMenu("Easy State Machine/Functions/PlayerPrefs/Set")]
    public sealed class SetPlayerPrefs : Function
    {
        #region Input
#pragma warning disable 0649
        /// Is the variable below global?
        [Header("Store")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// The name of the variable of specified type.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of specified type.")]
        string variable;

        /// Value type.
        [SerializeField, Tooltip("Value type")]
        EasyStateMachine.PlayerPrefs ofType;

        /// Key in player preferences.
        [Header("to PlaerPrefs with")]
        [SerializeField, Tooltip("Key in player preferences.")]
        string key;

#pragma warning disable 1635
#pragma warning disable 0169
#pragma warning disable 0414
        /// Where the job should be done.
        [SerializeField, Tooltip("Choose where the job should be done.")]
        In @in = In.OnEnable;
#pragma warning restore 0414
#pragma warning restore 0169
#pragma warning restore 1635
#pragma warning restore 0649
        #endregion

        /// Does the job.
        void Do()
        {
            switch (ofType)
            {
                case EasyStateMachine.PlayerPrefs.Int:
                {
                    int @int;
                    if (TryGet(global, variable, out @int, 0))
                        PlayerPrefs.SetInt(key, @int);
                    break;
                }
                case EasyStateMachine.PlayerPrefs.Float:
                {
                    float @float;
                    if (TryGet(global, variable, out @float, 0f))
                        PlayerPrefs.SetFloat(key, @float);
                    break;
                }
                case EasyStateMachine.PlayerPrefs.String:
                {
                    string @string;
                    if (TryGet(global, variable, out @string, string.Empty))
                        PlayerPrefs.SetString(key, @string);
                    break;
                }
            }
        }
    }
}