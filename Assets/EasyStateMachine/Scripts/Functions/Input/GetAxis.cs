//-----------------------------------------------------------------------
// <copyright file="GetAxis.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Input
{
    using UnityEngine;

    /// Gets the desired input axis and stores its value to a float variable.
    [AddComponentMenu("Easy State Machine/Functions/Input/Get Axis")]
    public sealed class GetAxis : Function
    {
        [Header("Store")]
        [SerializeField]
        bool raw = false;

        [SerializeField]
        Axis axis = Axis.Vertical;

        [Header("to")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string floatVariable = null;

#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414

        void Do()
        {
            var axisName = string.Empty;
            switch (axis)
            {
                case Axis.Horizontal:
                case Axis.Vertical:
                    axisName = axis.ToString();
                    break;
                case Axis.MouseX:
                    axisName = "Mouse X";
                    break;
                case Axis.MouseY:
                    axisName = "Mouse Y";
                    break;
            }

            var value = raw ? Input.GetAxisRaw(axisName) : Input.GetAxis(axisName);
            TrySet(global, floatVariable, value);
        }
    }
}
