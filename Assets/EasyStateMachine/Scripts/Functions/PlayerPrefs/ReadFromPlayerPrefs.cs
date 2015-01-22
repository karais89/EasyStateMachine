//-----------------------------------------------------------------------
// <copyright file="ReadFromPlayerPrefs.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.PlayerPrefs
{
    using UnityEngine;

    /// Reads the value from PlayerPrefs to a variable.
    [AddComponentMenu("Easy State Machine/Functions/PlayerPrefs/Read")]
    public sealed class ReadFromPlayerPrefs : Function
    {
        [Header("Read from PlayerPrefs")]
        [SerializeField]
        string theValueWithKey = null;

        [SerializeField]
        EasyStateMachine.PlayerPrefs type = EasyStateMachine.PlayerPrefs.Int;

        [Header("and default value")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string variable = null;

        [Header("and store it to")]
        [SerializeField]
        bool _global = false;

        [SerializeField]
        string _variable = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.OnEnable;
#pragma warning restore 0414

        void Do()
        {
            switch (type)
            {
                case EasyStateMachine.PlayerPrefs.Int:
                {
                    int @default;
                    var value = TryGet(global, variable, out @default, 0) ? PlayerPrefs.GetInt(theValueWithKey, @default) : PlayerPrefs.GetInt(theValueWithKey);
                    TrySet(_global, _variable, value);
                    break;
                }
                case EasyStateMachine.PlayerPrefs.Float:
                {
                    float @default;
                    var value = TryGet(global, variable, out @default, 0f) ? PlayerPrefs.GetFloat(theValueWithKey, @default) : PlayerPrefs.GetFloat(theValueWithKey);
                    TrySet(_global, _variable, value);
                    break;
                }
                case EasyStateMachine.PlayerPrefs.String:
                {
                    string @default;
                    var value = TryGet(global, variable, out @default, string.Empty) ? PlayerPrefs.GetString(theValueWithKey, @default) : PlayerPrefs.GetString(theValueWithKey);
                    TrySet(_global, _variable, value);
                    break;
                }
            }
        }
    }
}