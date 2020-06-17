using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bbuu20_s_Recoil_Handler_V2
{
    class InputHandler
    {
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern ushort GetAsyncKeyState(int vKey);

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags,
            int dwExtraInfo);

        public static void KeyPress(byte vKeyCode)
        {
            keybd_event(vKeyCode, 0x45, 0x1, 0);
            Thread.Sleep(15);
            keybd_event(vKeyCode, 0x45, 0x1 | 0x2, 0);
        }

        public static void RelativeMove(int relx, int rely)
        {
            mouse_event(0x0001, relx, rely, 0, 0);
        }

        public static bool IsKeyDown()
        {
            if (IsKeyDown(Keys.OemOpenBrackets) || IsKeyDown(Keys.OemCloseBrackets) || IsKeyDown(Keys.Insert) || IsKeyDown(Keys.Home) || IsKeyDown(Keys.PageUp) || IsKeyDown(Keys.Delete) || IsKeyDown(Keys.End) || IsKeyDown(Keys.PageDown) || IsKeyDown(Keys.LControlKey) || IsKeyDown(Keys.RControlKey) || IsKeyDown(Keys.Alt) || IsKeyDown(Keys.Tab) || IsKeyDown(Keys.CapsLock) || IsKeyDown(Keys.LShiftKey) || IsKeyDown(Keys.RShiftKey) || IsKeyDown(Keys.LButton) || IsKeyDown(Keys.RButton) || IsKeyDown(Keys.MButton) || IsKeyDown(Keys.XButton1) || IsKeyDown(Keys.XButton2) || IsKeyDown(Keys.Oemtilde) || IsKeyDown(Keys.D0) || IsKeyDown(Keys.D1) || IsKeyDown(Keys.D2) || IsKeyDown(Keys.D3) || IsKeyDown(Keys.D4) || IsKeyDown(Keys.D5) || IsKeyDown(Keys.D6) || IsKeyDown(Keys.D7) || IsKeyDown(Keys.D8) || IsKeyDown(Keys.D9) || IsKeyDown(Keys.A) || IsKeyDown(Keys.B) || IsKeyDown(Keys.C) || IsKeyDown(Keys.D) || IsKeyDown(Keys.E) || IsKeyDown(Keys.F) || IsKeyDown(Keys.G) || IsKeyDown(Keys.H) || IsKeyDown(Keys.I) || IsKeyDown(Keys.J) || IsKeyDown(Keys.K) || IsKeyDown(Keys.L) || IsKeyDown(Keys.M) || IsKeyDown(Keys.N) || IsKeyDown(Keys.O) || IsKeyDown(Keys.P) || IsKeyDown(Keys.Q) || IsKeyDown(Keys.R) || IsKeyDown(Keys.S) || IsKeyDown(Keys.T) || IsKeyDown(Keys.U) || IsKeyDown(Keys.V) || IsKeyDown(Keys.W) || IsKeyDown(Keys.X) || IsKeyDown(Keys.Y) || IsKeyDown(Keys.Z) || IsKeyDown(Keys.Escape) || IsKeyDown(Keys.F1) || IsKeyDown(Keys.F2) || IsKeyDown(Keys.F3) || IsKeyDown(Keys.F4) || IsKeyDown(Keys.F5) || IsKeyDown(Keys.F6) || IsKeyDown(Keys.F7) || IsKeyDown(Keys.F8) || IsKeyDown(Keys.F9) || IsKeyDown(Keys.F10) || IsKeyDown(Keys.F11) || IsKeyDown(Keys.F12) || IsKeyDown(Keys.F13) || IsKeyDown(Keys.F14) || IsKeyDown(Keys.F15) || IsKeyDown(Keys.F16) || IsKeyDown(Keys.F17) || IsKeyDown(Keys.F18) || IsKeyDown(Keys.F19) || IsKeyDown(Keys.F20) || IsKeyDown(Keys.F21) || IsKeyDown(Keys.F22) || IsKeyDown(Keys.F23) || IsKeyDown(Keys.F24))
            {
                return true;
            }
            return false;
        }

        public static bool IsKeyDown(Keys key)
        {
            return 0 != (GetAsyncKeyState((int)key) & 0x8000);
        }

        public static Keys GetKeyDown()
        {
            if (IsKeyDown(Keys.OemOpenBrackets))
                return Keys.OemOpenBrackets;
            if (IsKeyDown(Keys.OemCloseBrackets))
                return Keys.OemCloseBrackets;
            if (IsKeyDown(Keys.Insert))
                return Keys.Insert;
            if (IsKeyDown(Keys.Home))
                return Keys.Home;
            if (IsKeyDown(Keys.PageUp))
                return Keys.PageUp;
            if (IsKeyDown(Keys.Delete))
                return Keys.Delete;
            if (IsKeyDown(Keys.End))
                return Keys.End;
            if (IsKeyDown(Keys.PageDown))
                return Keys.PageDown;
            if (IsKeyDown(Keys.LControlKey))
                return Keys.LControlKey;
            if (IsKeyDown(Keys.RControlKey))
                return Keys.RControlKey;
            if (IsKeyDown(Keys.Alt))
                return Keys.Alt;
            if (IsKeyDown(Keys.Tab))
                return Keys.Tab;
            if (IsKeyDown(Keys.CapsLock))
                return Keys.CapsLock;
            if (IsKeyDown(Keys.LShiftKey))
                return Keys.LShiftKey;
            if (IsKeyDown(Keys.RShiftKey))
                return Keys.RShiftKey;
            if (IsKeyDown(Keys.LButton))
                return Keys.LButton;
            if (IsKeyDown(Keys.RButton))
                return Keys.RButton;
            if (IsKeyDown(Keys.MButton))
                return Keys.MButton;
            if (IsKeyDown(Keys.XButton1))
                return Keys.XButton1;
            if (IsKeyDown(Keys.XButton2))
                return Keys.XButton2;
            if (IsKeyDown(Keys.Oemtilde))
                return Keys.Oemtilde;
            if (IsKeyDown(Keys.D0))
                return Keys.D0;
            if (IsKeyDown(Keys.D1))
                return Keys.D1;
            if (IsKeyDown(Keys.D2))
                return Keys.D2;
            if (IsKeyDown(Keys.D3))
                return Keys.D3;
            if (IsKeyDown(Keys.D4))
                return Keys.D4;
            if (IsKeyDown(Keys.D5))
                return Keys.D5;
            if (IsKeyDown(Keys.D6))
                return Keys.D6;
            if (IsKeyDown(Keys.D7))
                return Keys.D7;
            if (IsKeyDown(Keys.D8))
                return Keys.D8;
            if (IsKeyDown(Keys.D9))
                return Keys.D9;
            if (IsKeyDown(Keys.A))
                return Keys.A;
            if (IsKeyDown(Keys.B))
                return Keys.B;
            if (IsKeyDown(Keys.C))
                return Keys.C;
            if (IsKeyDown(Keys.D))
                return Keys.D;
            if (IsKeyDown(Keys.E))
                return Keys.E;
            if (IsKeyDown(Keys.F))
                return Keys.F;
            if (IsKeyDown(Keys.G))
                return Keys.G;
            if (IsKeyDown(Keys.H))
                return Keys.H;
            if (IsKeyDown(Keys.I))
                return Keys.I;
            if (IsKeyDown(Keys.J))
                return Keys.J;
            if (IsKeyDown(Keys.K))
                return Keys.K;
            if (IsKeyDown(Keys.L))
                return Keys.L;
            if (IsKeyDown(Keys.M))
                return Keys.M;
            if (IsKeyDown(Keys.N))
                return Keys.N;
            if (IsKeyDown(Keys.O))
                return Keys.O;
            if (IsKeyDown(Keys.P))
                return Keys.P;
            if (IsKeyDown(Keys.Q))
                return Keys.Q;
            if (IsKeyDown(Keys.R))
                return Keys.R;
            if (IsKeyDown(Keys.S))
                return Keys.S;
            if (IsKeyDown(Keys.T))
                return Keys.T;
            if (IsKeyDown(Keys.U))
                return Keys.U;
            if (IsKeyDown(Keys.V))
                return Keys.V;
            if (IsKeyDown(Keys.W))
                return Keys.W;
            if (IsKeyDown(Keys.X))
                return Keys.X;
            if (IsKeyDown(Keys.Y))
                return Keys.Y;
            if (IsKeyDown(Keys.Z))
                return Keys.Z;
            if (IsKeyDown(Keys.Escape))
                return Keys.Escape;
            if (IsKeyDown(Keys.F1))
                return Keys.F1;
            if (IsKeyDown(Keys.F2))
                return Keys.F2;
            if (IsKeyDown(Keys.F3))
                return Keys.F3;
            if (IsKeyDown(Keys.F4))
                return Keys.F4;
            if (IsKeyDown(Keys.F5))
                return Keys.F5;
            if (IsKeyDown(Keys.F6))
                return Keys.F6;
            if (IsKeyDown(Keys.F7))
                return Keys.F7;
            if (IsKeyDown(Keys.F8))
                return Keys.F8;
            if (IsKeyDown(Keys.F9))
                return Keys.F9;
            if (IsKeyDown(Keys.F10))
                return Keys.F10;
            if (IsKeyDown(Keys.F11))
                return Keys.F11;
            if (IsKeyDown(Keys.F12))
                return Keys.F12;
            if (IsKeyDown(Keys.F13))
                return Keys.F13;
            if (IsKeyDown(Keys.F14))
                return Keys.F14;
            if (IsKeyDown(Keys.F15))
                return Keys.F15;
            if (IsKeyDown(Keys.F16))
                return Keys.F16;
            if (IsKeyDown(Keys.F17))
                return Keys.F17;
            if (IsKeyDown(Keys.F18))
                return Keys.F18;
            if (IsKeyDown(Keys.F19))
                return Keys.F19;
            if (IsKeyDown(Keys.F20))
                return Keys.F20;
            if (IsKeyDown(Keys.F21))
                return Keys.F21;
            if (IsKeyDown(Keys.F22))
                return Keys.F22;
            if (IsKeyDown(Keys.F23))
                return Keys.F23;
            if (IsKeyDown(Keys.F24))
                return Keys.F24;
            return Keys.Apps;
        }
    }
}
