//-----------------------------------------------------------------------
// <copyright file="LegacyAnimationFinishedTransition.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine.Functions.LegacyAnimation.Transitions
{
	using UnityEngine;
    
	/// Transits when teh specified legacy animation is finished.
    [AddComponentMenu("Easy State Machine/Functions/Legacy Animation/Transitions/Animation Clip Finished")]
	public sealed class LegacyAnimationFinishedTransition : Transition 
	{
		[Header("if")] 
        [SerializeField] 
		string clipWithName = null;

		[Header("is finished")]
        [SerializeField]
	    Animation inAnimation = null;
	
#pragma warning disable 0414
        [Space(8)]
        [SerializeField]
        [Tooltip("Choose where the job should be done.")]
        In @in = In.Update;
#pragma warning restore 0414

	    void Do()
	    {
			if (!inAnimation.IsPlaying(clipWithName))
	            NeedTransit = true;
	    }
	}
}