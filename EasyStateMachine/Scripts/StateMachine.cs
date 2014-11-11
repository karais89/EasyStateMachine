//-----------------------------------------------------------------------
// <copyright file="StateMachine.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine
{
	using UnityEngine;
	
	/// Represents the state machine.
	public class StateMachine : MonoBehaviour
	{
		/// Starting state.
	    [SerializeField]
        State startingState;
		
		/// Current state.
		State current;
		
		/// Gets current state.
		public State Current 
		{
			get { return current; }
		}
		
		/// Initialization. Starting state is entered.
		void Start()
		{
			Reset();
		}
		
		/// Resets the state machine via transition to starting state.
		public void Reset()
		{
			Transit(startingState);
		}
		
		/// Changes states when necessary.
		void Update ()
		{
			if(current == null)
				return;

			var next = current.GetNext();
			if(next != null)
				Transit(next);
		}

		/// Transition from current state to specified.
		void Transit(State next)
		{
			if(current != null)
				current.Exit();

			current = next;
			if(current != null)
				current.Enter();
		}
	}
}
