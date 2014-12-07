//-----------------------------------------------------------------------
// <copyright file="BaseForFunctions.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
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
        #region Private
        /// True, if the object is initialized.
        bool @initialized;

        /// Where the job should be done.
        In _where = In.None;
        #endregion

        /// Gets where the job should be done. 
        /// Is initialized on first use: it gets the value 
        /// of the field 'in' and method 'Do' as a delegate
        /// via reflection.
        public In Where
        {
            get
            {
                if (@initialized)
                    return _where;

                _where = GetWhere();
                Execute = GetDo();
                ExecuteWithCollision2D = GetDoWithCollision2D<UnityEngine.Collision2D>();
                ExecuteWithCollision = GetDoWithCollision2D<UnityEngine.Collision>();
                ExecuteWithCollider2D = GetDoWithCollision2D<Collider2D>();
                ExecuteWithCollider = GetDoWithCollision2D<Collider>();
                    
                @initialized = true;
                return _where;
            }
        }

        /// Function delegate.
        public System.Action Execute { get; private set; }

        /// Function delegate with Collision2D.
        public System.Action<UnityEngine.Collision2D> ExecuteWithCollision2D { get; private set; }

        /// Function delegate with Collision2D.
        public System.Action<UnityEngine.Collision> ExecuteWithCollision { get; private set; }

        /// Function delegate with Collision2D.
        public System.Action<Collider2D> ExecuteWithCollider2D { get; private set; }

        /// Function delegate with Collision2D.
        public System.Action<Collider> ExecuteWithCollider { get; private set; }

        #region Private
        /// Creates the delegate from the 'Do' method, if it exists.
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

        /// Creates the delegate from the 'Do' method with parameter, if it exists.
        System.Action<T> GetDoWithCollision2D<T>()
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

        /// Gets the value of the 'in' field, if it exists.
        In GetWhere()
        {
            var field = GetType().GetField("in", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (field == null)
                return In.None;

            if (!ReferenceEquals(field.FieldType, typeof(In)))
                return In.None;

            return (In)field.GetValue(this);
        }
        #endregion

        
        /// Enters the Function when the CurrentStateTransition gets entered.
        public virtual void Enter()
        {
            if(!enabled)
                enabled = true;
        }

        /// Exists the Function, when the CurrentStateTransition gets exited.
        public virtual void Exit()
        {
            if(enabled)
                enabled = false;
        }
    }
}