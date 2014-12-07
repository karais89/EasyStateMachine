//-----------------------------------------------------------------------
// <copyright file="GetContactNormal.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Physics2d
{
    using UnityEngine;

    /// Gets contact normal from Collision2D.
    [AddComponentMenu("Easy State Machine/Functions/Physics2d/Get Contact Normal")]
    public sealed class GetContactNormal : Function
    {
        #region Input
#pragma warning disable 0649
        /// Contact index.
        [Header("Get normal of")]
        [SerializeField, Tooltip("Contact index.")]
        int contact;

        /// Is the variable below global?
        [Header("and store it to")]
        [SerializeField, Tooltip("Is the variable below global?")]
        bool global;

        /// Variable of type Vector2.
        [Space(24)]
        [SerializeField, Tooltip("Specify the variable of type Vector2.")]
        string vector2;

        /// Where the job should be done.
        [Space(8)]
        [SerializeField, Tooltip("Choose where the job should be done.")]
        EasyStateMachine.Collision2D _in = EasyStateMachine.Collision2D.OnCollisionEnter2D;

#pragma warning disable 1635
#pragma warning disable 0169
#pragma warning disable 0414
        /// Where the job should be done.
        [SerializeField, HideInInspector]
        In @in = In.None;
#pragma warning restore 0414
#pragma warning restore 0169
#pragma warning restore 1635
#pragma warning restore 0649
        #endregion

        /// Initialization.
        void Awake()
        {
            switch (_in)
            {
                case EasyStateMachine.Collision2D.OnCollisionEnter2D:
                    @in = In.OnCollisionEnter2D;
                    break;
                case EasyStateMachine.Collision2D.OnCollisionStay2D:
                    @in = In.OnCollisionStay2D;
                    break;
                case EasyStateMachine.Collision2D.OnCollisionExit2D:
                    @in = In.OnCollisionExit2D;
                    break;
            }
        }

        /// Does the job.
        void Do(Collision2D collision2D)
        {
            var contacts = collision2D.contacts;
            if (contact >= 0 && contacts.Length > contact)
                TrySet(global, vector2, contacts[contact].normal);
        }
    }
}
