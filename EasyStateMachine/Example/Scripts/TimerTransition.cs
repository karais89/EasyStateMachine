//-----------------------------------------------------------------------
// <copyright file="TimerTransition.cs" company="https://github.com/marked-one">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Example
{
	using UnityEngine;
	using System.Collections;

	/// Represents transition by timer.
	public class TimerTransition : Transition 
	{
		/// Time to wait until transition happens.
		public float WaitTime;

		/// Starts timer.
		void OnEnable()
		{
			NeedTransit = false;
			StartCoroutine("Timer");
		}

		/// Timer coroutine.
		IEnumerator Timer()
		{
			yield return new WaitForSeconds(WaitTime);
			NeedTransit = true;
		}

		/// Stops timer.
		void OnDisable()
		{
			StopCoroutine("Timer");
		}
	}
}