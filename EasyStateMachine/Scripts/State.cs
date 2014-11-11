//-----------------------------------------------------------------------
// <copyright file="State.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine
{
	using UnityEngine;
	using System.Collections.Generic;
	
	/// Represents the base class for states.
	/// NOTE: derived classes should be disabled in Inspector.
	public abstract class State : MonoBehaviour
	{
		/// List of transitions from this state.
		[SerializeField, Tooltip("List of transitions from this state.")]
	    List<Transition> transitions = new List<Transition> ();

		/// Returns next state if transition is necessary, 'null' otherwise.
		public virtual State GetNext()
		{
			foreach (var transition in transitions) 
			{
				if (transition.NeedTransit )
					return transition.TargetState;
			}

			return null;
		}
	
		/// Disables state and its transitions.
		public virtual void Exit()
		{
			if(enabled)
			{
				foreach(var transition in transitions)
				{
					transition.enabled = false;
				}
				
				enabled = false;
			}
		}
		
		/// Enables state and its transitions.
		public virtual void Enter()
		{
			if(!enabled)
			{
				enabled = true;
				foreach(var transition in transitions)
				{
					transition.enabled = true;
				}
			}
		}

        /// This method is implemented only to show the 
        /// enabled/disabled checkbox in Inspector for each state.
        protected virtual void FixedUpdate()
        {
        }
	}
}