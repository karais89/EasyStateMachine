//-----------------------------------------------------------------------
// <copyright file="TranslateState.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Example
{
	using UnityEngine;
	
	/// Represents the translation of a transform.
	public class TranslateState : State 
	{
		/// Transform to move.
		[SerializeField]
		Transform transformToMove;
		
		/// Speed in units per second.
		[SerializeField, Tooltip("Speed in units per second.")]
		Vector3 speed;
		
		/// Translate transform.
		void Update () 
		{
			var step = speed * Time.deltaTime;
			transformToMove.Translate(step.x, step.y, step.z);
		}
	}
}

