﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlLibrary.DrawComponents
{
    public enum DragDirection
    {
        Left, Right, Up, Down
    }

    public enum InputType
    {
        Click,
        Longpress,
        Drag
    }
    
    class MouseGestureRecognizer
    {
        internal delegate void InputRecognized(InputType inputType, MouseEventArgs mouseArgs, object args);
        public event InputRecognized OnInputRecognized;


        private MouseEventArgs _prevArgs;
        private DateTime _timestamp;

        private bool _isMouseDown = false;

        public void OnMouseDown(object sender, MouseEventArgs e)
        {
            _prevArgs = e;
            _timestamp = DateTime.Now;
            _isMouseDown = true;
        }

        public void OnMouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDown = false;

            if (DateTime.Now - _timestamp < new TimeSpan(0, 0, 0, 0, 500))
            {
                OnInputRecognized?.Invoke(InputType.Click, e, null);
                return;
            }
        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            if(!_isMouseDown || OnInputRecognized == null)
                return;

            float xDelta = e.X - _prevArgs.X;
            float yDelta = e.Y - _prevArgs.Y;

            var direction = Math.Abs(xDelta) > Math.Abs(yDelta)
                ? (xDelta > 0 ? DragDirection.Right : DragDirection.Left)
                : (yDelta > 0 ? DragDirection.Down : DragDirection.Up);

            OnInputRecognized?.Invoke(InputType.Drag, e, direction);
        }
    }

    
}
