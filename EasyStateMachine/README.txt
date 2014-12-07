Easy State Machine

Simple state machine for Unity3d (http://unity3d.com/) written in C#.

This package is still mostly for programmers: only some Functions and Transitions are currently implemented.

Usage

1. Import the EasyStateMachine package.
2. Add StateMachine as a Component to any GameObject.
3. Add States as Components to any GameObjects.
4. Add Functions as Components to any GameObjects.
5. Add Transitions as Components to any GameObjects.
6. Drag the initial State to the InitialState field of StateMachine.
7. Drag the appropriate States to the State and To fields of each Transition.
8. Drag the appropriate States to the State field of each Function.
9. Fill other necessary fields of Functions and Transitions.
10. Ensure that all States, Functions and Transitions are disabled in the Inspector (note: collapsed components aren't disabled automatically).
11. Use Inspector and Gizmos to visually debug the StateMachines.
12. Implement your own Functions and Transitions, if necessary.