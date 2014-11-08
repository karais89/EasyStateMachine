//-----------------------------------------------------------------------
// <copyright file="State.cs" company="https://github.com/marked-one">
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
		[Tooltip("List of transitions from this state.")]
		public List<Transition> Transitions = new List<Transition> ();

		// Returns next state, if a transition should happen, null otherwise.
		public virtual State GetNext()
		{
			foreach (var transition in Transitions) 
			{
				if (transition.NeedTransit )
					return transition.TargetState;
			}

			return null;
		}
	
		/// Exits currenr state.
		public virtual void Exit()
		{
			if(enabled)
			{
				foreach(var transition in Transitions)
				{
					transition.enabled = false;
				}
				
				enabled = false;
			}
		}
		
		/// Enters current state.
		public virtual void Enter()
		{
			if(!enabled)
			{
				enabled = true;
				foreach(var transition in Transitions)
				{
					transition.enabled = true;
				}
			}
		}
	}
}