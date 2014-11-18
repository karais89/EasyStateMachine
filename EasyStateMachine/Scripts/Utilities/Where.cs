//-----------------------------------------------------------------------
// <copyright file="Where.cs" company="https://github.com/marked-one/EasyStateMachine">
//     Copyright © 2014 Vladimir Klubkov. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace EasyStateMachine
{
    /// This enum is used as a type for Inspector fields in actions and 
    /// transitions to indicate, where the calculations should happen.
    public enum Where
    {
        Update = 0,
        FixedUpdate = 1,
        LateUpdate = 2, 
        OnEnable = 3,
        OnDisable = 4
    }
}