//-----------------------------------------------------------------------
// <copyright file="In.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine
{
    /// This enum is intended to indicate the Unity event functions.
    /// For more info on Unity3d events, please see:
    /// http://docs.unity3d.com/Manual/ExecutionOrder.html
    public enum In
    {
        // TODO: add all event functions.

        #region None
        /// No event function.
        None,
        #endregion

        #region Behaviour
        /// When the behaviour gets enabled.
        OnEnable,

        /// When the behaviour gets disabled.
        OnDisable,

        /// When the behaviour awakes.
        Awake,

        /// When the behaviour starts.
        Start,

        /// When the FixedUpdate of a behaviour happens.
        FixedUpdate,

        /// When the Update of a behaviour happens.
        Update, 

        /// When the LateUpdate of a behaviour happens.
        LateUpdate,
        #endregion

        #region GameObject
        /// When the object the behaviour is attached to is destroyed.
        OnDestroy,
        #endregion

        #region Physics
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

        /// When a Rigidbody hits a CharacterController.
        OnControllerColliderHit,
        #endregion
    }
}