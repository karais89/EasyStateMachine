Easy State Machine

Simple state machine for Unity3d written in C#.

The goal of this package is to create the visual scripting solution (think of Playmaker).
Currently it is still under development and could be successfully used by the programmers only.

Usage

0. Download the EasyStateMachine package.
1. Import the EasyStateMachine package.
2. Add the StateMachine component to any GameObject.
3. Add State components to any GameObject.
4. Add Function components to any GameObject.
5. Add Transition components to any GameObject.
6. Drag the initial State to the InitialState field of StateMachine.
7. Drag the appropriate State to the State field of each Function (and each Transition too).
8. Drag the appropriate State to the To field of each Transition.
9. Fill other necessary fields of each Function and each Transition.
10. Ensure that all states, functions and transitions are disabled in the Inspector (note: collapsed components couldn't be disabled automatically).
11. Use Inspector and Gizmos to visually debug the StateMachine.
12. Implement your own functions and transitions, if necessary.