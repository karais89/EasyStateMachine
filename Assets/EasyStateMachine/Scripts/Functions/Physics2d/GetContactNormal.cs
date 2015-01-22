//-----------------------------------------------------------------------
// <copyright file="GetContactNormal.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.Physics2d
{
    using UnityEngine;

    /// Gets the normal of a contact from Collision2D.
    [AddComponentMenu("Easy State Machine/Functions/Physics2d/Get Contact Normal")]
    public sealed class GetContactNormal : Function
    {
        [Header("Get the normal of")]
        [SerializeField]
        int aContact = 0;

        [Header("and store it to")]
        [SerializeField]
        bool global = false;

        [SerializeField]
        string vector2 = null;

        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        EasyStateMachine.Collision2D _in = EasyStateMachine.Collision2D.OnCollisionEnter2D;

#pragma warning disable 0414
        /// Where the job should be done.
        [SerializeField, HideInInspector]
        In @in = In.None;
#pragma warning restore 0414

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

        void Do(Collision2D collision2D)
        {
            var contacts = collision2D.contacts;
            if (aContact >= 0 && contacts.Length > aContact)
                TrySet(global, vector2, contacts[aContact].normal);
        }
    }
}
