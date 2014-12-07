﻿//-----------------------------------------------------------------------
// <copyright file="Collision.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine
{
    /// This enum represents the list of possible collision callbacks.
    public enum Collision
    {
        OnCollisionEnter,
        OnCollisionStay,
        OnCollisionExit,
    }
}