//-----------------------------------------------------------------------
// <copyright file="TimerTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Example
{
	using UnityEngine;
	using System.Collections;

	/// Represents the transition by timer.
	public class TimerTransition : Transition 
	{
		/// Time in seconds.
	   	[SerializeField, Tooltip("Time in seconds.")]
		float time;

		/// Starts timer and resets the NeedTransit property.
		void OnEnable()
		{
			NeedTransit = false;
			StartCoroutine("Timer");
		}

		/// Timer coroutine.
		IEnumerator Timer()
		{
			yield return new WaitForSeconds(time);
			NeedTransit = true;
		}

		/// Stops timer.
		void OnDisable()
		{
			StopCoroutine("Timer");
		}
	}
}