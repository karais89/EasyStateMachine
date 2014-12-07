//-----------------------------------------------------------------------
// <copyright file="GetPlayerPrefs.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.PlayerPrefs
{
    using UnityEngine;

    /// Reads a value from player preferences.
    [AddComponentMenu("Easy State Machine/Functions/PlayerPrefs/Get")]
    public sealed class GetPlayerPrefs : Function
    {
        #region Input
#pragma warning disable 0649
        /// Key in PlayerPrefs.
        [Header("Read value from PlayerPrefs using")]
        [SerializeField, Tooltip("Key in PlayerPrefs.")]
        string key;

        /// Value type.
        [SerializeField, Tooltip("Value type.")]
        EasyStateMachine.PlayerPrefs type;

        /// Is the variable below global?
        [Header("and default value")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// Variable containing default value.
        [Space(24)]
        [SerializeField, Tooltip("Variable containing default value.")]
        string variable;

        /// Is the variable below global?
        [Header("and store it to")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool _global;

        /// The name of the variable of specified type.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of specified type.")]
        string _variable;

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
            switch (type)
            {
                case EasyStateMachine.PlayerPrefs.Int:
                {
                    int @default;
                    var value = TryGet(global, variable, out @default, 0) ? PlayerPrefs.GetInt(key, @default) : PlayerPrefs.GetInt(key);
                    TrySet(_global, _variable, value);
                    break;
                }
                case EasyStateMachine.PlayerPrefs.Float:
                {
                    float @default;
                    var value = TryGet(global, variable, out @default, 0f) ? PlayerPrefs.GetFloat(key, @default) : PlayerPrefs.GetFloat(key);
                    TrySet(_global, _variable, value);
                    break;
                }
                case EasyStateMachine.PlayerPrefs.String:
                {
                    string @default;
                    var value = TryGet(global, variable, out @default, string.Empty) ? PlayerPrefs.GetString(key, @default) : PlayerPrefs.GetString(key);
                    TrySet(_global, _variable, value);
                    break;
                }
            }
        }
    }
}