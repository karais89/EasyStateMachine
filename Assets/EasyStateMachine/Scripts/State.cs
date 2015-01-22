//-----------------------------------------------------------------------
// <copyright file="State.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine
{
    using UnityEngine;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

#if UNITY_EDITOR
    using UnityEditor;
#endif

    /// Represents a state of the StateMachine.
    [AddComponentMenu("Easy State Machine/State")]
    public class State : BaseForStates
    {
        /// List of Functions of this state.
        /// Functions are added/removed automatically by the Editor scripts.
        [SerializeField, HideInInspector] 
        List<Function> functions = new List<Function>();

        /// The StateMachine this state belongs to.
        /// StateMachine is set automatically by the Editor scripts.
        [SerializeField, HideInInspector] 
        StateMachine stateMachine;

        public StateMachine StateMachine { get { return stateMachine; } }

        public void AddFunction(Function function)
        {
            RemoveNullFunctions();
            if (function == null)
                return;

            if (!functions.Contains(function))
                functions.Add(function);

            SortFunctions();
        }

#if UNITY_EDITOR
        public
#endif
        void RemoveNullFunctions()
        {
            functions.RemoveAll(function => function == null);
        }

        public void RemoveFunction(Function function)
        {
            functions.RemoveAll(item => ReferenceEquals(item, function) || item == null);
        }

#if UNITY_EDITOR
        public
#endif
        void SortFunctions()
        {
            functions.Sort((a, b) => b.Priority.CompareTo(a.Priority));
        }

#if UNITY_EDITOR
        /// Returns the StateMachine info.
        /// This info is shown in Inspector.
        public override string Info
        {
            get { return BuildInfo() + "\n" + base.Info; }
        }

        /// Builds the textual info from the specified list of functions.
        string BuildInfo()
        {
            RemoveNullFunctions();
            if (functions == null || functions.Count <= 0)
                return "There are no functions present\n";

            var sb = new StringBuilder("Functions:");
            sb.AppendLine();
            foreach (var function in functions)
                sb.AppendFormat("{0} {1}", function.Priority, function.Path).AppendLine();

            return sb.ToString();
        }

        /// Sets the specified StateMachine to this State 
        /// and to all connected States. The List of 
        /// processed States is necessary to avoid the 
        /// problem of circular dependencies.
        public void SetStateMachine(List<State> processed, StateMachine newStateMachine)
        {
            if (processed == null || processed.Contains(this))
                return;

            processed.Add(this);
            stateMachine = newStateMachine;
            EditorUtility.SetDirty(this);
            RemoveNullFunctions();
            foreach (var transition in functions.OfType<Transition>().Where(transition => transition.To != null))
                transition.To.SetStateMachine(processed, newStateMachine);
        }
#endif

        /// Enables the Functions of the State.
        /// This method is used by the StateMachine.
        public void Enter()
        {
            // TODO: check, whether it is possible to call this and similar methods via reflection to hide it from the users. Or find out the architectural way.
            for (var i = 0; i < functions.Count; i++)
            {
                var function = functions[i];
                if (function == null)
                    functions.RemoveAt(i--);
                else
                    function.Enter();
            }

            SortFunctions();
        }

        /// Disables the Functions of the State.
        /// This method is used by the StateMachine.
        public void Exit()
        {
            for (var i = 0; i < functions.Count; i++)
            {
                var function = functions[i];
                if (function == null)
                    functions.RemoveAt(i--);
                else
                    function.Exit();
            }
        }

        #region Execute
        // TODO: divide Functions List into separate lists depending on the destination event function to increase the execution performance.
        // TODO: add all event functions.

        /// This function is called just after the behaviour is enabled. 
        protected virtual void OnEnable()
        {
            Execute(In.OnEnable);
        }

        /// This function is called when the behaviour becomes disabled or inactive.
        protected virtual void OnDisable()
        {
            Execute(In.OnDisable);
        }

        /// This function is always called before any Start functions and also just after 
        /// a prefab is instantiated. (If a GameObject is inactive during start up Awake 
        /// is not called until it is made active, or a function in any script attached 
        /// to it is called.)
        void Awake()
        {
            Execute(In.Awake);
        }

        /// Start is called before the first frame update 
        /// only if the script instance is enabled.
        void Start()
        {
            Execute(In.Start);
        }

        /// This function is called after all frame updates
        /// for the last frame of the object’s existence.
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

        /// Executes Functions. If a Function is null, removes it from the Functions List.
        void Execute(In here)
        {
            for (var i = 0; i < functions.Count; i++)
            {
                var function = functions[i];
                if (function == null)
                    functions.RemoveAt(i--);
                else if (function.enabled && function.Where == here && function.Execute != null)
                    function.Execute();
            }
        }

        /// Sent when an incoming collider makes contact with 
        /// this object's collider (2D physics only). The State 
        /// should be attached to a GameObject with a Rigidbody2D 
        /// in order to receive it.
        void OnCollisionEnter2D(UnityEngine.Collision2D collision2D)
        {
            ExecuteWithCollision2D(In.OnCollisionEnter2D, collision2D);
        }

        /// Sent when a collider on another object stops touching this 
        /// object's collider (2D physics only). The State should be 
        /// attached to a GameObject with Rigidbody2D in order to receive it.
        void OnCollisionStay2D(UnityEngine.Collision2D collision2D)
        {
            ExecuteWithCollision2D(In.OnCollisionStay2D, collision2D);
        }

        /// Sent each frame where a collider on another object is touching 
        /// this object's collider (2D physics only). The State should be 
        /// attached to a GameObject with Rigidbody2D in order to receive it.
        void OnCollisionExit2D(UnityEngine.Collision2D collision2D)
        {
            ExecuteWithCollision2D(In.OnCollisionExit2D, collision2D);
        }

        /// Executes Functions with Collision2D. If a Function is null, removes it from the Functions List.
        void ExecuteWithCollision2D(In here, UnityEngine.Collision2D collision2D)
        {
            for (var i = 0; i < functions.Count; i++)
            {
                var function = functions[i];
                if (function == null)
                    functions.RemoveAt(i--);
                else if (function.enabled && function.Where == here)
                {
                    if (function.Execute != null)
                        function.Execute();
                    else if (function.ExecuteWithCollision2D != null)
                        function.ExecuteWithCollision2D(collision2D);
                }
            }
        }

        /// OnCollisionEnter is called when this collider/rigidbody has begun 
        /// touching another rigidbody/collider. The State should be 
        /// attached to a GameObject with Rigidbody in order to receive it.
        void OnCollisionEnter(UnityEngine.Collision collision)
        {
            ExecuteWithCollision(In.OnCollisionEnter, collision);
        }

        /// OnCollisionStay is called once per frame for every collider/rigidbody 
        /// that is touching rigidbody/collider. The State should be 
        /// attached to a GameObject with Rigidbody in order to receive it.
        void OnCollisionStay(UnityEngine.Collision collision)
        {
            ExecuteWithCollision(In.OnCollisionStay, collision);
        }

        /// OnCollisionExit is called when this collider/rigidbody has 
        /// stopped touching another rigidbody/collider. The State should be 
        /// attached to a GameObject with Rigidbody in order to receive it.
        void OnCollisionExit(UnityEngine.Collision collision)
        {
            ExecuteWithCollision(In.OnCollisionExit, collision);
        }

        /// Executes Functions with Collision. If a Function is null, removes it from list.
        void ExecuteWithCollision(In here, UnityEngine.Collision collision)
        {
            for (var i = 0; i < functions.Count; i++)
            {
                var function = functions[i];
                if (function == null)
                    functions.RemoveAt(i--);
                else if (function.enabled && function.Where == here)
                {
                    if (function.Execute != null)
                        function.Execute();
                    else if (function.ExecuteWithCollision != null)
                        function.ExecuteWithCollision(collision);
                }
            }
        }

        /// Sent when another object enters a trigger collider attached 
        /// to this object (2D physics only). The State should be 
        /// attached to a GameObject with Rigidbody2D in order to receive it.
        void OnTriggerEnter2D(Collider2D collider2D)
        {
            ExecuteWithCollider2D(In.OnTriggerEnter2D, collider2D);
        }

        /// Sent when another object leaves a trigger collider attached 
        /// to this object (2D physics only). The State should be 
        /// attached to a GameObject with Rigidbody2D in order to receive it.
        void OnTriggerStay2D(Collider2D collider2D)
        {
            ExecuteWithCollider2D(In.OnTriggerStay2D, collider2D);
        }

        /// Sent each frame where another object is within a trigger collider 
        /// attached to this object (2D physics only). The State should be 
        /// attached to a GameObject with Rigidbody2D in order to receive it.
        void OnTriggerExit2D(Collider2D collider2D)
        {
            ExecuteWithCollider2D(In.OnTriggerExit2D, collider2D);
        }

        /// Executes Functions with Collider2D. If a Function is 'null', removes it from the Functions List.
        void ExecuteWithCollider2D(In here, Collider2D collider2D)
        {
            for (var i = 0; i < functions.Count; i++)
            {
                var function = functions[i];
                if (function == null)
                    functions.RemoveAt(i--);
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
        /// The State should be attached to a GameObject with Rigidbody in order to receive it.
        void OnTriggerEnter(Collider collider)
        {
            ExecuteWithCollider(In.OnTriggerEnter, collider);
        }

        /// OnTriggerStay is called almost all the frames for every Collider 
        /// other that is touching the trigger. The State should be attached to a 
        /// GameObject with Rigidbody in order to receive it.
        void OnTriggerStay(Collider collider)
        {
            ExecuteWithCollider(In.OnTriggerStay, collider);
        }

        /// OnTriggerExit is called when the Collider other has stopped
        /// touching the trigger. The State should be attached to a 
        /// GameObject with Rigidbody in order to receive it.
        void OnTriggerExit(Collider collider)
        {
            ExecuteWithCollider(In.OnTriggerExit, collider);
        }

        /// Executes Functions with Collider. If a Function is 'null', removes it from the Functions List.
        void ExecuteWithCollider(In here, Collider collider)
        {
            for (var i = 0; i < functions.Count; i++)
            {
                var function = functions[i];
                if (function == null)
                    functions.RemoveAt(i--);
                else if (function.enabled && function.Where == here)
                {
                    if (function.Execute != null)
                        function.Execute();
                    else if (function.ExecuteWithCollider != null)
                        function.ExecuteWithCollider(collider);
                }
            }
        }

        /// OnControllerColliderHit is called when the controller hits a 
        /// collider while performing a Move. The State should be attached 
        /// to a GameObject with CharacterController in order to receive it.
        void OnControllerColliderHit(ControllerColliderHit hit) 
        {
            ExecuteWithControllerColliderHit(In.OnControllerColliderHit, hit);
        }

        /// Executes Functions with ControllerColliderHit. If a Function is 'null', removes it from the Functions List.
        void ExecuteWithControllerColliderHit(In here, ControllerColliderHit hit)
        {
            for (var i = 0; i < functions.Count; i++)
            {
                var function = functions[i];
                if (function == null)
                    functions.RemoveAt(i--);
                else if (function.enabled && function.Where == here)
                {
                    if (function.Execute != null)
                        function.Execute();
                    else if (function.ExecuteWithControllerColliderHit != null)
                        function.ExecuteWithControllerColliderHit(hit);
                }
            }
        }
        #endregion
    }
}