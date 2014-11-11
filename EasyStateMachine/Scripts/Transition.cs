//-----------------------------------------------------------------------
// <copyright file="Transition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine
{
	using UnityEngine;
	
	/// Represents the base class for transitions.
	/// NOTE: Derived classes should be disabled in Inspector.
	public abstract class Transition : MonoBehaviour
	{
        /// Target state.
        [SerializeField]
        State targetState;

        /// Gets target state.
		public State TargetState
        {
            get { return targetState; }
        }

		/// Set this property to 'true' when transition should happen.
		public bool NeedTransit
		{
			get;
			protected set;
		}
	}
}
