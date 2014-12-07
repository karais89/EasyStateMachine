//-----------------------------------------------------------------------
// <copyright file="GetAxis.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Input
{
    using UnityEngine;

    ///Gets input axis and stores the value to float variable.
    [AddComponentMenu("Easy State Machine/Functions/Input/Get Axis")]
    public sealed class GetAxis : Function
    {
        #region Input
#pragma warning disable 0649
        /// Should axis value be raw or smooth?
        [Header("Store")]
        [SerializeField, Tooltip("Should axis value be raw or smooth?")]
        bool raw;

        /// Axis type.
        [Space(24)]
        [SerializeField, Tooltip("Choose axis.")]
        Axis axis;

        /// Is the variable below global?
        [Header("to")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// Name of the variable of type 'float'.
        [Space(24)]
        [SerializeField, Tooltip("Specify the name of the variable of type 'float'.")]
        string @float;

#pragma warning disable 1635
#pragma warning disable 0169
#pragma warning disable 0414
        /// Where the job should be done.
        [SerializeField, Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414
#pragma warning restore 0169
#pragma warning restore 1635
#pragma warning restore 0649
        #endregion

        /// Does the job.
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
            TrySet(global, @float, value);
        }
    }
}
