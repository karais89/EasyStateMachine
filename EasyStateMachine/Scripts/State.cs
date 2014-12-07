//-----------------------------------------------------------------------
// <copyright file="State.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine
{
    using UnityEngine;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    #region Editor
#if UNITY_EDITOR
    using UnityEditor;
#endif
    #endregion

    /// Represents the state of the state machine.
    [AddComponentMenu("Easy State Machine/State")]
    public class State : BaseForStates
    {
        #region Private
        /// List of Functions of this state.
        /// Functions are added/removed automatically in the Editor.
        [SerializeField, HideInInspector] 
        List<Function> _functions = new List<Function>();

        /// State machine this state belongs to.
        /// It is set automatically in the Editor.
        [SerializeField, HideInInspector] 
        StateMachine _stateMachine;
        #endregion

        /// Gets the state machine this state belongs to.
        public StateMachine StateMachine { get { return _stateMachine; } }

        /// Adds the specified Function to this state.
        /// The Functions are immediately sorted depending on their priorities.
        public void AddFunction(Function function)
        {
            RemoveNullFunctions();
            if (function == null)
                return;

            if (!_functions.Contains(function))
                _functions.Add(function);

            Sort();
        }

        #region Private
        /// Removes null items from List.
        void RemoveNullFunctions()
        {
            _functions.RemoveAll(function => function == null);
        }
        #endregion

        /// Removes the specified Function from the State.
        public void RemoveFunction(Function function)
        {
            _functions.RemoveAll(item => ReferenceEquals(item, function) || item == null);
        }

        /// Sorts Functions depending on their priority.
        void Sort()
        {
            _functions.Sort((a, b) => b.Priority.CompareTo(a.Priority));
        }

        #region Editor
#if UNITY_EDITOR
        /// Sorts Functions depending on their priority.
        public void SortFunctions()
        {
            RemoveNullFunctions();
            Sort();
        }

        /// Gets the state info.
        public override string Info
        {
            get { return BuildInfo() + "\n" + base.Info; }
        }

        #region Private
        /// Gets the textual info about the specified list of functions.
        private string BuildInfo()
        {
            RemoveNullFunctions();
            if (_functions == null || _functions.Count <= 0)
                return "There are no functions present\n";

            var sb = new StringBuilder("Functions:");
            sb.AppendLine();
            foreach (var function in _functions)
            {
                sb.AppendFormat("{0} {1}", function.Priority, function.Path).AppendLine();
            }

            return sb.ToString();
        }
        #endregion

        /// Sets the specified state machine for this state 
        /// and for all the states the outgoing transitions exist for.
        /// !!! Having a List of processed states is necessary to 
        /// avoid problems with circular dependencies.
        public void SetStateMachine(List<State> processed, StateMachine stateMachine)
        {
            if (processed == null || processed.Contains(this))
                return;

            processed.Add(this);
            _stateMachine = stateMachine;
            EditorUtility.SetDirty(this);

            RemoveNullFunctions();
            foreach (var transition in _functions.OfType<Transition>().Where(transition => transition.To != null))
            {
                transition.To.SetStateMachine(processed, stateMachine);
            }
        }
#endif
        #endregion

        /// Enables the functions of the State.
        public void Enter()
        {
            for (var i = 0; i < _functions.Count; i++)
            {
                var function = _functions[i];
                if (function == null)
                    _functions.RemoveAt(i--);
                else
                    function.Enter();
            }
            Sort();
        }

        /// Disables the functions of the State.
        public void Exit()
        {
            for (var i = 0; i < _functions.Count; i++)
            {
                var function = _functions[i];
                if (function == null)
                    _functions.RemoveAt(i--);
                else
                    function.Exit();
            }
        }

        /// This function is called just after the object is enabled. 
        protected virtual void OnEnable()
        {
            Execute(In.OnEnable);
        }

        /// This function is called when the behaviour becomes disabled or inactive.
        protected virtual void OnDisable()
        {
            Execute(In.OnDisable);
        }

        #region Private
        /// This function is always called before any Start functions and also just after 
        /// a prefab is instantiated. (If a GameObject is inactive during start up Awake 
        /// is not called until it is made active, or a function in any script attached to it is called.)
        void Awake()
        {
            Execute(In.Awake);
        }

        /// Start is called before the first frame update only if the script instance is enabled.
        void Start()
        {
            Execute(In.Start);
        }

        /// This function is called after all frame updates for the last frame of the object’s existence.
        void OnDestroy()
        {
            Execute(In.OnDestroy);
        }

        /// FixedUpdate is called at fixed framerate.
        void FixedUpdate()
        {
            Execute(In.FixedUpdate);
        }

        /// Update is called once per frame.
        void Update()
        {
            Execute(In.Update);
        }

        /// LateUpdate is called once per frame, after Update has finished.
        void LateUpdate()
        {
            Execute(In.LateUpdate);
        }

        /// Executes Functions. If a Function is 'null', removes it from list.
        void Execute(In here)
        {
            for (var i = 0; i < _functions.Count; i++)
            {
                var function = _functions[i];
                if (function == null)
                    _functions.RemoveAt(i--);
                else if (function.enabled && function.Where == here && function.Execute != null)
                    function.Execute();
            }
        }

        /// Sent when an incoming collider makes contact with this object's collider (2D physics only).
        /// Requires the State to be attached to a GameObject with Rigidbody2D.
        void OnCollisionEnter2D(UnityEngine.Collision2D collision2D)
        {
            ExecuteWithCollision2D(In.OnCollisionEnter2D, collision2D);
        }

        /// Sent when a collider on another object stops touching this object's collider (2D physics only).
        /// Requires the State to be attached to a GameObject with Rigidbody2D.
        void OnCollisionStay2D(UnityEngine.Collision2D collision2D)
        {
            ExecuteWithCollision2D(In.OnCollisionStay2D, collision2D);
        }

        /// Sent each frame where a collider on another object is touching this object's collider (2D physics only).
        /// Requires the State to be attached to a GameObject with Rigidbody2D.
        void OnCollisionExit2D(UnityEngine.Collision2D collision2D)
        {
            ExecuteWithCollision2D(In.OnCollisionExit2D, collision2D);
        }

        /// Executes Functions. If a Function is 'null', removes it from list.
        void ExecuteWithCollision2D(In here, UnityEngine.Collision2D collision2D)
        {
            for (var i = 0; i < _functions.Count; i++)
            {
                var function = _functions[i];
                if (function == null)
                    _functions.RemoveAt(i--);
                else if (function.enabled && function.Where == here)
                {
                    if (function.Execute != null)
                        function.Execute();
                    else if (function.ExecuteWithCollision2D != null)
                        function.ExecuteWithCollision2D(collision2D);
                }
            }
        }

        /// OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider.
        /// Requires the State to be attached to a GameObject with Rigidbody.
        void OnCollisionEnter(UnityEngine.Collision collision)
        {
            ExecuteWithCollision(In.OnCollisionEnter, collision);
        }

        /// OnCollisionStay is called once per frame for every collider/rigidbody that is touching rigidbody/collider.
        /// Requires the State to be attached to a GameObject with Rigidbody.
        void OnCollisionStay(UnityEngine.Collision collision)
        {
            ExecuteWithCollision(In.OnCollisionStay, collision);
        }

        /// OnCollisionExit is called when this collider/rigidbody has stopped touching another rigidbody/collider.
        /// Requires the State to be attached to a GameObject with Rigidbody.
        void OnCollisionExit(UnityEngine.Collision collision)
        {
            ExecuteWithCollision(In.OnCollisionExit, collision);
        }

        /// Executes Functions. If a Function is 'null', removes it from list.
        void ExecuteWithCollision(In here, UnityEngine.Collision collision)
        {
            for (var i = 0; i < _functions.Count; i++)
            {
                var function = _functions[i];
                if (function == null)
                    _functions.RemoveAt(i--);
                else if (function.enabled && function.Where == here)
                {
                    if (function.Execute != null)
                        function.Execute();
                    else if (function.ExecuteWithCollision != null)
                        function.ExecuteWithCollision(collision);
                }
            }
        }

        /// Sent when another object enters a trigger collider attached to this object (2D physics only).
        /// Requires the State to be attached to a GameObject with Rigidbody2D.
        void OnTriggerEnter2D(Collider2D collider2D)
        {
            ExecuteWithCollider2D(In.OnTriggerEnter2D, collider2D);
        }

        /// Sent when another object leaves a trigger collider attached to this object (2D physics only).
        /// Requires the State to be attached to a GameObject with Rigidbody2D.
        void OnTriggerStay2D(Collider2D collider2D)
        {
            ExecuteWithCollider2D(In.OnTriggerStay2D, collider2D);
        }

        /// Sent each frame where another object is within a trigger collider attached to this object (2D physics only).
        /// Requires the State to be attached to a GameObject with Rigidbody2D.
        void OnTriggerExit2D(Collider2D collider2D)
        {
            ExecuteWithCollider2D(In.OnTriggerExit2D, collider2D);
        }

        /// Executes Functions. If a Function is 'null', removes it from list.
        void ExecuteWithCollider2D(In here, Collider2D collider2D)
        {
            for (var i = 0; i < _functions.Count; i++)
            {
                var function = _functions[i];
                if (function == null)
                    _functions.RemoveAt(i--);
                else if (function.enabled && function.Where == here)
                {
                    if (function.Execute != null)
                        function.Execute();
                    else if (function.ExecuteWithCollider2D != null)
                        function.ExecuteWithCollider2D(collider2D);
                }
            }
        }

        /// OnTriggerEnter is called when the Collider other enters the trigger.
        /// Requires the State to be attached to a GameObject with Rigidbody.
        void OnTriggerEnter(Collider collider)
        {
            ExecuteWithCollider(In.OnTriggerEnter, collider);
        }

        /// OnTriggerStay is called almost all the frames for every Collider other that is touching the trigger.
        /// Requires the State to be attached to a GameObject with Rigidbody.
        void OnTriggerStay(Collider collider)
        {
            ExecuteWithCollider(In.OnTriggerStay, collider);
        }

        /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
        /// Requires the State to be attached to a GameObject with Rigidbody.
        void OnTriggerExit(Collider collider)
        {
            ExecuteWithCollider(In.OnTriggerExit, collider);
        }

        /// Executes Functions. If a Function is 'null', removes it from list.
        void ExecuteWithCollider(In here, Collider collider)
        {
            for (var i = 0; i < _functions.Count; i++)
            {
                var function = _functions[i];
                if (function == null)
                    _functions.RemoveAt(i--);
                else if (function.enabled && function.Where == here)
                {
                    if (function.Execute != null)
                        function.Execute();
                    else if (function.ExecuteWithCollider != null)
                        function.ExecuteWithCollider(collider);
                }
            }
        }
        #endregion
    }
}