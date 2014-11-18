Easy State Machine
===

Simple state machine for [Unity3d](http://unity3d.com/) written in C#.

This package is mostly for programmers: only some actions and transitions are implemented, and you still have to implement your own actions and transitions in C#.

##Usage

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

## License

MIT/X11

        Copyright (C) 2014 Vladimir Klubkov
    
        Permission is hereby granted, free of charge, to any person obtaining a copy of this software
        and associated documentation files (the "Software"), to deal in the Software without
        restriction, including without limitation the rights to use, copy, modify, merge, publish,
        distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the
        Software is furnished to do so, subject to the following conditions:
        The above copyright notice and this permission notice shall be included in all copies or
        substantial portions of the Software.
    
        THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING
        BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
        NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
        DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
        OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
