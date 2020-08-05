using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Bbuu20_s_Recoil_Handler_V2
{
    static class MainApp
    {
        public static GUI gui;
        public static Keys[] keys;
        public static Keys[] settingsKeys;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Run();
        }

        static void Run()
        {
            gui = new GUI();
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                InteractiveUIThread();
            }).Start();
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                RecoilHandler.Run();
            }).Start();
            Application.Run(gui);
        }

        static void InteractiveUIThread()
        {
            if (!gui.Visible)
            {
                while (!gui.Visible)
                {
                    Thread.Sleep(20);
                }
            }
            UpdateControls();
            short i = 0;
            IEnumerable<string> keysFile = File.ReadAllLines(Application.StartupPath + "\\res\\Profile Settings\\Keys.txt");
            IEnumerable<string> settingsFile = File.ReadAllLines(Application.StartupPath + "\\res\\Profile Settings\\Settings.txt");
            foreach (Button button in GUI.bindButtons)
            {
                GUI.selectedBind = i;
                GUI.newBindText = keysFile.Skip(i).First();
                gui.Invoke(new MethodInvoker(gui.UpdateSelectedBind));
                ++i;
            }
            GUI.newBindText = settingsFile.Skip(0).First();
            gui.Invoke(new MethodInvoker(gui.UpdateTriggerBind));
            GUI.newBindText = settingsFile.Skip(1).First();
            gui.Invoke(new MethodInvoker(gui.UpdateTrackLabel));
        }

        public static void UpdateControls()
        {
            RecoilHandler.triggerKey = MainApp.KeyToHex(MainApp.SearchControls(0, "\\res\\Profile Settings\\Settings.txt"));
            RecoilHandler.sensitivity = Double.Parse(File.ReadAllLines(Application.StartupPath + "\\res\\Profile Settings\\Settings.txt").Skip(1).First());
            keys = new Keys[] { SearchControls(0, "\\res\\Profile Settings\\Keys.txt"), SearchControls(1, "\\res\\Profile Settings\\Keys.txt"), SearchControls(2, "\\res\\Profile Settings\\Keys.txt"), SearchControls(3, "\\res\\Profile Settings\\Keys.txt"), SearchControls(4, "\\res\\Profile Settings\\Keys.txt"), SearchControls(5, "\\res\\Profile Settings\\Keys.txt"), SearchControls(6, "\\res\\Profile Settings\\Keys.txt"), SearchControls(7, "\\res\\Profile Settings\\Keys.txt"), SearchControls(8, "\\res\\Profile Settings\\Keys.txt"), SearchControls(9, "\\res\\Profile Settings\\Keys.txt"), SearchControls(10, "\\res\\Profile Settings\\Keys.txt"), SearchControls(11, "\\res\\Profile Settings\\Keys.txt"), SearchControls(12, "\\res\\Profile Settings\\Keys.txt") };
            settingsKeys = new Keys[] { SearchControls(0, "\\res\\Profile Settings\\Settings.txt"), Keys.None };
        }

        public static Keys SearchControls(int lineNumber, string path)
        {
            switch (File.ReadLines(Application.StartupPath + path).Skip(lineNumber).First())
            {
                case "OemOpenBrackets":
                    return Keys.OemOpenBrackets;
                case "OemCloseBrackets":
                    return Keys.OemCloseBrackets;
                case "Insert":
                    return Keys.Insert;
                case "Home":
                    return Keys.Home;
                case "PageUp":
                    return Keys.PageUp;
                case "Delete":
                    return Keys.Delete;
                case "End":
                    return Keys.End;
                case "PageDown":
                    return Keys.PageDown;
                case "LControlKey":
                    return Keys.LControlKey;
                case "RControlKey":
                    return Keys.RControlKey;
                case "Alt":
                    return Keys.Alt;
                case "Tab":
                    return Keys.Tab;
                case "CapsLock":
                    return Keys.CapsLock;
                case "LShiftKey":
                    return Keys.LShiftKey;
                case "RShiftKey":
                    return Keys.RShiftKey;
                case "LButton":
                    return Keys.LButton;
                case "RButton":
                    return Keys.RButton;
                case "MButton":
                    return Keys.MButton;
                case "XButton1":
                    return Keys.XButton1;
                case "XButton2":
                    return Keys.XButton2;
                case "F1":
                    return Keys.F1;
                case "F2":
                    return Keys.F2;
                case "F3":
                    return Keys.F3;
                case "F4":
                    return Keys.F4;
                case "F5":
                    return Keys.F5;
                case "F6":
                    return Keys.F6;
                case "F7":
                    return Keys.F7;
                case "F8":
                    return Keys.F8;
                case "F9":
                    return Keys.F9;
                case "F10":
                    return Keys.F10;
                case "F11":
                    return Keys.F11;
                case "F12":
                    return Keys.F12;
                case "F13":
                    return Keys.F13;
                case "F14":
                    return Keys.F14;
                case "F15":
                    return Keys.F15;
                case "F16":
                    return Keys.F16;
                case "F17":
                    return Keys.F17;
                case "F18":
                    return Keys.F18;
                case "F19":
                    return Keys.F19;
                case "F20":
                    return Keys.F20;
                case "F21":
                    return Keys.F21;
                case "F22":
                    return Keys.F22;
                case "F23":
                    return Keys.F23;
                case "F24":
                    return Keys.F24;
                case "Oemtilde":
                    return Keys.Oemtilde;
                case "Oem1":
                    return Keys.Oem1;
                case "A":
                    return Keys.A;
                case "B":
                    return Keys.B;
                case "C":
                    return Keys.C;
                case "D":
                    return Keys.D;
                case "E":
                    return Keys.E;
                case "F":
                    return Keys.F;
                case "G":
                    return Keys.G;
                case "H":
                    return Keys.H;
                case "I":
                    return Keys.I;
                case "J":
                    return Keys.J;
                case "K":
                    return Keys.K;
                case "L":
                    return Keys.L;
                case "M":
                    return Keys.M;
                case "N":
                    return Keys.N;
                case "O":
                    return Keys.O;
                case "P":
                    return Keys.P;
                case "Q":
                    return Keys.Q;
                case "R":
                    return Keys.R;
                case "S":
                    return Keys.S;
                case "T":
                    return Keys.T;
                case "U":
                    return Keys.U;
                case "V":
                    return Keys.V;
                case "W":
                    return Keys.W;
                case "X":
                    return Keys.X;
                case "Y":
                    return Keys.Y;
                case "Z":
                    return Keys.Z;
                case "D0":
                    return Keys.D0;
                case "D1":
                    return Keys.D1;
                case "D2":
                    return Keys.D2;
                case "D3":
                    return Keys.D3;
                case "D4":
                    return Keys.D4;
                case "D5":
                    return Keys.D5;
                case "D6":
                    return Keys.D6;
                case "D7":
                    return Keys.D7;
                case "D8":
                    return Keys.D8;
                case "D9":
                    return Keys.D9;
                default:
                    return Keys.Escape;
            }
        }

        public static byte KeyToHex(Keys key)
        {
            switch (key)
            {
                case Keys.OemOpenBrackets:
                    return 0x05;
                case Keys.OemCloseBrackets:
                    return 0x05;
                case Keys.Insert:
                    return 0x2D;
                case Keys.Home:
                    return 0x24;
                case Keys.PageUp:
                    return 0x21;
                case Keys.Delete:
                    return 0x2E;
                case Keys.End:
                    return 0x23;
                case Keys.PageDown:
                    return 0x22;
                case Keys.LControlKey:
                    return 0x11;
                case Keys.RControlKey:
                    return 0x11;
                case Keys.Alt:
                    return 0x12;
                case Keys.Tab:
                    return 0x09;
                case Keys.CapsLock:
                    return 0x14;
                case Keys.LShiftKey:
                    return 0xA0;
                case Keys.RShiftKey:
                    return 0xA1;
                case Keys.LButton:
                    return 0x01;
                case Keys.RButton:
                    return 0x02;
                case Keys.MButton:
                    return 0x04;
                case Keys.XButton1:
                    return 0x05;
                case Keys.XButton2:
                    return 0x06;
                case Keys.F1:
                    return 0x70;
                case Keys.F2:
                    return 0x71;
                case Keys.F3:
                    return 0x72;
                case Keys.F4:
                    return 0x73;
                case Keys.F5:
                    return 0x74;
                case Keys.F6:
                    return 0x75;
                case Keys.F7:
                    return 0x76;
                case Keys.F8:
                    return 0x77;
                case Keys.F9:
                    return 0x78;
                case Keys.F10:
                    return 0x79;
                case Keys.F11:
                    return 0x7A;
                case Keys.F12:
                    return 0x7B;
                case Keys.F13:
                    return 0x7C;
                case Keys.F14:
                    return 0x7D;
                case Keys.F15:
                    return 0x7E;
                case Keys.F16:
                    return 0x7F;
                case Keys.F17:
                    return 0x80;
                case Keys.F18:
                    return 0x81;
                case Keys.F19:
                    return 0x82;
                case Keys.F20:
                    return 0x83;
                case Keys.F21:
                    return 0x84;
                case Keys.F22:
                    return 0x85;
                case Keys.F23:
                    return 0x86;
                case Keys.F24:
                    return 0x87;
                case Keys.Oemtilde:
                    return 0xC0;
                case Keys.Oem1:
                    return 0xBA;
                case Keys.A:
                    return 0x41;
                case Keys.B:
                    return 0x42;
                case Keys.C:
                    return 0x43;
                case Keys.D:
                    return 0x44;
                case Keys.E:
                    return 0x45;
                case Keys.F:
                    return 0x46;
                case Keys.G:
                    return 0x47;
                case Keys.H:
                    return 0x48;
                case Keys.I:
                    return 0x49;
                case Keys.J:
                    return 0x4A;
                case Keys.K:
                    return 0x4B;
                case Keys.L:
                    return 0x4C;
                case Keys.M:
                    return 0x4D;
                case Keys.N:
                    return 0x4E;
                case Keys.O:
                    return 0x4F;
                case Keys.P:
                    return 0x50;
                case Keys.Q:
                    return 0x51;
                case Keys.R:
                    return 0x52;
                case Keys.S:
                    return 0x53;
                case Keys.T:
                    return 0x54;
                case Keys.U:
                    return 0x55;
                case Keys.V:
                    return 0x56;
                case Keys.W:
                    return 0x57;
                case Keys.X:
                    return 0x58;
                case Keys.Y:
                    return 0x59;
                case Keys.Z:
                    return 0x5A;
                case Keys.D0:
                    return 0x30;
                case Keys.D1:
                    return 0x31;
                case Keys.D2:
                    return 0x32;
                case Keys.D3:
                    return 0x33;
                case Keys.D4:
                    return 0x34;
                case Keys.D5:
                    return 0x35;
                case Keys.D6:
                    return 0x36;
                case Keys.D7:
                    return 0x37;
                case Keys.D8:
                    return 0x38;
                case Keys.D9:
                    return 0x39;
                default:
                    return 0x1B;
            }
        }
    }
}
