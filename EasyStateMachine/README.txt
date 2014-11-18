Easy State Machine

Simple state machine for Unity3d (http://unity3d.com/) written in C#.

This package is mostly for programmers: only some actions and transitions are implemented, and you still have to implement your own actions and transitions in C#.

Usage

1. Import the EasyStateMachine package.
2. Add StateMachine as a Component to a GameObject.
3. Implement your states by inheriting them from the State class. Usually you do this by creating empty classes to only rename your states.
4. Implement your actions by inheriting them from the Action class or use included actions.
5. Implement your transitions by inheriting them from the Transition class or use included transitions.
6. Add your states, actions and transitions as Components to GameObejcts.
7. Drag the initial state to the StartingState field of StateMachine.
8. Drag the appropriate states to the State and Next fields of each Transition.
9. Drag the appropriate states to the State field of each Action.
10. Fill other necessary fields of used actions and transitions.
11. Ensure, that all states, actions and transitions are disabled in the Inspector (because collapsed components are not disabled automatically).
12. The state machine is ready to run.
13. Use Inspector to visually debug the state machine.