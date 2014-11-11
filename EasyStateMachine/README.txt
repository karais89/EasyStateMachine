Easy State Machine

Simple state machine for Unity3d (http://unity3d.com/) written in C#.

This package is for programmers: you have to implement your own states and transitions in C#.

Usage

1. Import EasyStateMachine package.
2. Add StateMachine as a Component to a GameObject.
3. Implement your states by inheriting them from the State class.
4. Implement your transitions by inheriting them from the Transition class.
5. Add your states and transitions as Components to GameObejcts.
6. Drag the initial state to the StartingState field of StateMachine.
7. Drag the appropriate states to the TargetState fields of each Transition.
8. Add transitions to the Transitions lists of proper states.
9. Disable all States and Transitions in Inspector.
10. The state machine is ready to run.
11. Use Inspector to visually debug the state machine.
