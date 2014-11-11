Easy State Machine
===

Simple state machine for [Unity3d](http://unity3d.com/) written in C#.

This package is for programmers: you have to implement your own states and transitions in C#.

##Usage

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
