//-----------------------------------------------------------------------
// <copyright file="MoveRight.cs" company="https://github.com/marked-one">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Example
{
	using UnityEngine;

	/// Represents movement to the right.
	public class MoveRight : State 
	{
		/// GameObject to move.
		public GameObject GameObject;

		/// Movement speed in units per second.
		[Tooltip("Movement speed in units per second.")]
		public float MovementSpeed;
		
		/// Moves GameObject to the right.
		void Update () 
		{
			var step = MovementSpeed * Time.deltaTime;
			GameObject.transform.Translate(step, 0f, 0f);
		}
	}
}
