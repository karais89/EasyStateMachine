//-----------------------------------------------------------------------
// <copyright file="Transition.cs" company="https://github.com/marked-one">
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
		public State TargetState;

		/// Set this property to 'true'
	    /// when transition should happen
		/// and to 'false' otherwise.
		public bool NeedTransit
		{
			get;
			protected set;
		}
	}
}
