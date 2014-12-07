//-----------------------------------------------------------------------
// <copyright file="In.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine
{
    /// This enum is used to indicate in wchich event function 
    /// the calculations of a Function should happen.
    /// For more info on Unity events, please see http://docs.unity3d.com/Manual/ExecutionOrder.html
    public enum In
    {
        #region None
        /// Never (handled by someone else).
        None,
        #endregion

        #region CurrentStateTransition
        /// When the CurrentStateTransition gets enabled.
        OnEnable,

        /// When the CurrentStateTransition gets disabled.
        OnDisable,

        /// When the CurrentStateTransition awakes.
        Awake,

        /// When the CurrentStateTransition starts.
        Start,

        /// When the object the CurrentStateTransition is attached to is destroyed.
        OnDestroy,

        /// When the FixedUpdate of a CurrentStateTransition happens.
        FixedUpdate,

        /// When the Update of a CurrentStateTransition happens.
        Update, 

        /// When the LateUpdate of a CurrentStateTransition happens.
        LateUpdate,
        #endregion

        #region Function
        /// When a 2D physics trigger gets entered.
        OnTriggerEnter2D,

        /// When the collider is inside 2D physics trigger.
        OnTriggerStay2D,

        /// When a 2D physics trigger gets exited.
        OnTriggerExit2D,

        /// When a 2D physics collision gets entered.
        OnCollisionEnter2D,

        /// When the collider is inside 2D physics collision.
        OnCollisionStay2D,

        /// When a 2D physics collision gets exited.
        OnCollisionExit2D,

        /// When a 3D physics trigger gets entered.
        OnTriggerEnter,

        /// When the collider is inside 3D physics trigger.
        OnTriggerStay,

        /// When a 3D physics trigger gets exited.
        OnTriggerExit,

        /// When a 3D physics collision gets entered.
        OnCollisionEnter,

        /// When the collider is inside 3D physics collision.
        OnCollisionStay,

        /// When a 3D physics collision gets exited.
        OnCollisionExit,
        #endregion
    }
}