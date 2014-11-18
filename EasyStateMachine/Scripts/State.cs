//-----------------------------------------------------------------------
// <copyright file="State.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine
{
    using UnityEngine;
    using System.Collections.Generic;

#if UNITY_EDITOR
    using UnityEditor;
#endif

    /// Represents the base class for states.
    public abstract class State : VariablesStorage
    {
        /// State belongs to this state machine.
        /// It is set automatically in the editor.
        [SerializeField, HideInInspector]
        StateMachine stateMachine;

        /// Gets the state machine.
        public StateMachine StateMachine { get { return stateMachine; } }

        /// List of actions for this state.
        /// Actions are added/removed automatically in the editor.
        [SerializeField, HideInInspector]
        List<Action> actions = new List<Action> ();

        /// Adds the specified action to state.
        public void AddAction(Action action)
        {
            if (action != null && !actions.Contains (action))
                actions.Add (action);
        }

        /// Removes the specified  action from state.
        public void RemoveAction(Action action)
        {
            actions.RemoveAll (item => item == action || item == null);
        }

        /// Enables the state, its actions and transitions.
        public virtual void Enter()
        {
            if (!enabled) 
            {
                enabled = true;
                RemoveAction (null);
                foreach (var action in actions) 
                {
                    action.Enter ();
                }
            }
        }

        /// Disables the state, its actions and transitions.
        public virtual void Exit()
        {
            if (enabled) 
            {
                RemoveAction (null);
                foreach (var action in actions) 
                {
                    action.Exit ();
                }
            
                enabled = false;
            }
        }

        /// This method is only implemented to show 
        /// the enabled/disabled checkbox in Inspector
        /// for any State components.
        protected virtual void FixedUpdate()
        {
        }

#if UNITY_EDITOR
        /// Gets the actions info.
        public string ActionsInfo
        {
            get 
            {
                if(actions == null || actions.Count <= 0)
                    return "State has no actions";

                return "Actions:\n" + GetInfo(actions);
            }
        }

        /// Sets the state machine for this state and for all the states it could transit to.
        /// List of processed states is necessary to avoid the problem with circular dependencies.
        public void SetStateMachine(List<State> processed, StateMachine stateMachine)
        {
            if(processed == null || processed.Contains(this))
               return;

            processed.Add (this);
            this.stateMachine = stateMachine;
            EditorUtility.SetDirty (this);

            RemoveAction(null);
            foreach (var action in actions)
            {
                var transition = action as Transition;
                if (transition != null && transition.Next != null)
                    transition.Next.SetStateMachine(processed, stateMachine);
            }
        }
#endif
    }
}