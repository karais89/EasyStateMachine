//-----------------------------------------------------------------------
// <copyright file="Collision.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014-2015 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine
{
    /// This enum represents all possible collision events.
    public enum Collision
    {
        OnCollisionEnter,
        OnCollisionStay,
        OnCollisionExit,
    }
}