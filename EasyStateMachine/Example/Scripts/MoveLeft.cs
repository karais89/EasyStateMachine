//-----------------------------------------------------------------------
// <copyright file="MoveLeft.cs" company="https://github.com/marked-one">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Example
{
	using UnityEngine;

	/// Represents movement to the left.
	public class MoveLeft : State 
	{
		/// GameObject to move.
		public GameObject GameObject;
		
		/// Movement speed in units per second.
		[Tooltip("Movement speed in units per second.")]
		public float MovementSpeed;
		
		/// Moves GameObject to the left.
		void Update () 
		{
			var step = MovementSpeed * Time.deltaTime;
			GameObject.transform.Translate(-step, 0f, 0f);
		}
	}
}
