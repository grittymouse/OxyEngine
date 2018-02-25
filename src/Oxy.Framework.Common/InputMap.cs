using System.Collections.Generic;
using OpenTK.Input;

namespace Oxy.Framework
{
  /// <summary>
  /// Class for mapping string to OpenTK Key enum
  /// </summary>
  public class InputMap 
  {
    private Dictionary<string, Key> _keyMap => new Dictionary<string, Key>() 
    {
      { "unknown",        Key.Unknown },
      { "lshift",         Key.ShiftLeft },
      { "rshift",         Key.ShiftRight },
      { "lcontrol",       Key.LControl },
      { "rcontrol",       Key.RControl },
      { "lalt",           Key.LAlt },
      { "ralt",           Key.RAlt },
      { "lwin",           Key.LWin },
      { "rwin",           Key.Unknown },
      { "menu",           Key.Menu },

      { "f1",             Key.F1 },
      { "f2",             Key.F2 },
      { "f3",             Key.F3 },
      { "f4",             Key.F4 },
      { "f5",             Key.F5 },
      { "f6",             Key.F6 },
      { "f7",             Key.F7 },
      { "f8",             Key.F8 },
      { "f9",             Key.F9 },
      { "f10",            Key.F10 },
      { "f11",            Key.F11 },
      { "f12",            Key.F12 },
      { "f13",            Key.F13 },
      { "f14",            Key.F14 },
      { "f15",            Key.F15 },
      { "f16",            Key.F16 },
      { "f17",            Key.F17 },
      { "f18",            Key.F18 },
      { "f19",            Key.F19 },
      { "f20",            Key.F20 },
      { "f21",            Key.F21 },
      { "f22",            Key.F22 },
      { "f23",            Key.F23 },
      { "f24",            Key.F24 },
      { "f25",            Key.F25 },
      { "f26",            Key.F26 },
      { "f27",            Key.F27 },
      { "f28",            Key.F28 },
      { "f29",            Key.F29 },
      { "f30",            Key.F30 },
      { "f31",            Key.F31 },
      { "f32",            Key.F32 },
      { "f33",            Key.F33 },
      { "f34",            Key.F34 },
      { "f35",            Key.F35 },

      { "up",             Key.Up },
      { "down",           Key.Down },
      { "left",           Key.Left },
      { "right",          Key.Right },
      { "enter",          Key.Enter },
      { "escape",         Key.Escape },
      { "space",          Key.Space },
      { "tab",            Key.Tab },
      { "backspace",      Key.BackSpace },
      { "insert",         Key.Insert },
      { "pageup",         Key.PageUp },
      { "pagedown",       Key.PageDown },
      { "home",           Key.Home },
      { "end",            Key.End },
      { "capslock",       Key.CapsLock },
      { "scrolllock",     Key.ScrollLock },
      { "printscreen",    Key.PrintScreen },
      { "pause",          Key.CapsLock },
      { "numlock",        Key.CapsLock },
      { "clear",          Key.CapsLock },
      { "sleep",          Key.CapsLock },
      { "keypad0",        Key.Keypad0 },
      { "keypad1",        Key.Keypad1 },
      { "keypad2",        Key.Keypad2 },
      { "keypad3",        Key.Keypad3 },
      { "keypad4",        Key.Keypad4 },
      { "keypad5",        Key.Keypad5 },
      { "keypad6",        Key.Keypad6 },
      { "keypad7",        Key.Keypad7 },
      { "keypad8",        Key.Keypad8 },
      { "keypad9",        Key.Keypad9 },
      { "keypaddivide",   Key.KeypadDivide },
      { "keypadmultiply", Key.KeypadMultiply },
      { "keypadminus",    Key.KeypadMinus },
      { "keypaddecimal",  Key.KeypadDecimal },
      { "keypadenter",    Key.KeypadEnter },
      { "a",              Key.A },
      { "b",              Key.B },
      { "c",              Key.C },
      { "d",              Key.D },
      { "e",              Key.E },
      { "f",              Key.F },
      { "g",              Key.G },
      { "h",              Key.H },
      { "i",              Key.I },
      { "j",              Key.J },
      { "k",              Key.K },
      { "l",              Key.L },
      { "m",              Key.M },
      { "n",              Key.N },
      { "o",              Key.O },
      { "p",              Key.P },
      { "q",              Key.Q },
      { "r",              Key.R },
      { "s",              Key.S },
      { "t",              Key.T },
      { "u",              Key.U },
      { "v",              Key.V },
      { "w",              Key.W },
      { "x",              Key.X },
      { "y",              Key.Y },
      { "z",              Key.Z },
      { "0",              Key.Number0 },
      { "1",              Key.Number1 },
      { "2",              Key.Number2 },
      { "3",              Key.Number3 },
      { "4",              Key.Number4 },
      { "5",              Key.Number5 },
      { "6",              Key.Number6 },
      { "7",              Key.Number7 },
      { "8",              Key.Number8 },
      { "9",              Key.Number9 },
      { "~",              Key.Tilde },
      { "-",              Key.Minus },
      { "+",              Key.Plus },
      { "[",              Key.LBracket },
      { "]",              Key.RBracket },
      { ";",              Key.Semicolon },
      { "'",              Key.Quote },
      { ",",              Key.Comma },
      { ".",              Key.Period },
      { "/",              Key.Slash },
      {@"\",              Key.BackSlash },
      { "last",           Key.LastKey },
    };

    private Dictionary<string, MouseButton> _mouseMap => new Dictionary<string, MouseButton>() 
    {
      { "left",           MouseButton.Left },
      { "middle",         MouseButton.Middle },
      { "right",          MouseButton.Right },
      { "button1",        MouseButton.Button1 },
      { "button2",        MouseButton.Button2 },
      { "button3",        MouseButton.Button3 },
      { "button4",        MouseButton.Button4 },
      { "button5",        MouseButton.Button5 },
      { "button6",        MouseButton.Button6 },
      { "button7",        MouseButton.Button7 },
      { "button8",        MouseButton.Button8 },
      { "button9",        MouseButton.Button9 },
      { "last",           MouseButton.LastButton },
    };

    public Dictionary<string, Key> KeyMap => _keyMap;
    public Dictionary<string, MouseButton> MouseMap => _mouseMap;
  }
}