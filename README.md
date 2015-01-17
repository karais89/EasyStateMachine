Easy State Machine
===

Simple state machine for [Unity3d](http://unity3d.com/) written in C#.

The goal of this package is to create the visual scripting solution, just like Playmaker, but it is still mostly for programmers: only some Functions and Transitions are currently implemented.

##Online example

[Try here](http://marked-one.github.io/EasyStateMachine/).

Contains 3 scenes made with Easy State Machine without programming:
- Menu, 
- 2d game (`Space` to start, `←` and `→` to play),
- 3d game (`w`, `a`, `s`, `d` to move, mouse to rotate).

Use `Settings` button in the menu to switch between 2d and 3d games.
Refresh the page to return to the menu.

##Usage

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
