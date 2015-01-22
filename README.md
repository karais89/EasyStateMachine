Easy State Machine
===

Simple state machine for Unity3d written in C#.

The goal of this package is to create the visual scripting solution (think of Playmaker).
Currently it is still under development and could be successfully used by the programmers only.

##Example

[Online sample made with Easy State Machine without programming](http://marked-one.github.io/EasyStateMachine/).

Contains 3 scenes:
- Menu, 
- 2d game (`Space` to start, `←` and `→` to play),
- 3d game (`w`, `a`, `s`, `d` to move, mouse to rotate).

Use `Settings` button in the menu to switch between 2d and 3d games.
Refresh the page to return to the menu.

##Usage

0. [Download](https://github.com/marked-one/EasyStateMachine/releases/tag/v0.5) the EasyStateMachine package.
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

## License

MIT/X11

        Copyright © 2014-2015 Vladimir Klubkov
    
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
