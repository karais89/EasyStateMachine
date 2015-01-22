//-----------------------------------------------------------------------
// <copyright file="BaseForFunctions.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine
{
    using UnityEngine;
    using System.Reflection;
    using Delegate = System.Delegate;

    /// Represents the base class for Functions.
    public abstract class BaseForFunctions : Base
    {
        bool initialized;
        In where = In.None;

        /// Where the job should be done.
        /// Initialized on the first use.
        public In Where
        {
            get
            {
                if (initialized)
                    return where;

                // Get the methods "Do "and the field "in" via reflection.
                where = GetWhere();
                Execute = GetDo();
                ExecuteWithCollision2D = GetDoWithParameter<UnityEngine.Collision2D>();
                ExecuteWithCollision = GetDoWithParameter<UnityEngine.Collision>();
                ExecuteWithCollider2D = GetDoWithParameter<Collider2D>();
                ExecuteWithCollider = GetDoWithParameter<Collider>();
                ExecuteWithControllerColliderHit = GetDoWithParameter<ControllerColliderHit>();
                initialized = true;
                return where;
            }
        }

        // TODO: add delegates for all event functions.

        /// Function delegate.
        public System.Action Execute { get; private set; }

        /// Function delegate with Collision2D parameter.
        public System.Action<UnityEngine.Collision2D> ExecuteWithCollision2D { get; private set; }

        /// Function delegate with Collision2D parameter.
        public System.Action<UnityEngine.Collision> ExecuteWithCollision { get; private set; }

        /// Function delegate with Collision2D parameter.
        public System.Action<Collider2D> ExecuteWithCollider2D { get; private set; }

        /// Function delegate with Collision2D parameter.
        public System.Action<Collider> ExecuteWithCollider { get; private set; }
       
        /// Function delegate with ControllerColliderHit parameter.
        public System.Action<ControllerColliderHit> ExecuteWithControllerColliderHit { get; private set; }

        /// Creates a delegate from the method "Do" via reflection.
        System.Action GetDo()
        {
            var method = GetType().GetMethod("Do", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (method == null)
                return null;

            var parameters = method.GetParameters();
            if (parameters.Length != 0)
                return null;

            return (System.Action)Delegate.CreateDelegate(typeof(System.Action), this, method);
        }

        /// Creates a delegate from the method "Do" with parameter via reflection.
        System.Action<T> GetDoWithParameter<T>()
        {
            var method = GetType().GetMethod("Do", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(T) }, null);
            if (method == null)
                return null;

            var parameters = method.GetParameters();
            if (parameters.Length != 1)
                return null;

            var parameter = parameters[0];
            if (!ReferenceEquals(parameter.ParameterType, typeof(T)))
                return null;

            return (System.Action<T>)Delegate.CreateDelegate(typeof(System.Action<T>), this, method);
        }

        /// Gets the value of the field "in" via reflection.
        In GetWhere()
        {
            var field = GetType().GetField("in", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (field == null)
                return In.None;

            if (!ReferenceEquals(field.FieldType, typeof(In)))
                return In.None;

            return (In)field.GetValue(this);
        }

        /// Enters the Function when the State gets entered.
        public virtual void Enter()
        {
            if(!enabled)
                enabled = true;
        }

        /// Exits the Function when the State gets exited.
        public virtual void Exit()
        {
            if(enabled)
                enabled = false;
        }
    }
}