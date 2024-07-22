using System.Runtime.InteropServices;

namespace CopilotKey
{
    internal class Program
    {
        [StructLayout(LayoutKind.Sequential)]
        struct INPUT
        {
            public int type;
            public InputUnion u;
        }

        [StructLayout(LayoutKind.Explicit)]
        struct InputUnion
        {
            [FieldOffset(0)] public MOUSEINPUT mi;
            [FieldOffset(0)] public KEYBDINPUT ki;
            [FieldOffset(0)] public HARDWAREINPUT hi;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct KEYBDINPUT
        {
            public short wVk;
            public short wScan;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct HARDWAREINPUT
        {
            public int uMsg;
            public short wParamL;
            public short wParamH;
        }

        const int INPUT_MOUSE = 0;
        const int INPUT_KEYBOARD = 1;
        const int INPUT_HARDWARE = 2;

        const int KEYEVENTF_EXTENDEDKEY = 0x0001;
        const int KEYEVENTF_KEYUP = 0x0002;
        const short VK_SHIFT = 0x10;
        const short VK_LSHIFT = 0xA0;
        const short VK_LWIN = 0x5B;
        const short VK_F23 = 0x86;  // F23-Taste

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        static void Main(string[] args)
        {
            INPUT[] inputs = new INPUT[6];

            // Left-Shift down
            inputs[0] = new INPUT
            {
                type = INPUT_KEYBOARD,
                u = new InputUnion
                {
                    ki = new KEYBDINPUT
                    {
                        wVk = VK_LSHIFT
                    }
                }
            };

            // Windows down
            inputs[1] = new INPUT
            {
                type = INPUT_KEYBOARD,
                u = new InputUnion
                {
                    ki = new KEYBDINPUT
                    {
                        wVk = VK_LWIN
                    }
                }
            };

            // F23 down
            inputs[2] = new INPUT
            {
                type = INPUT_KEYBOARD,
                u = new InputUnion
                {
                    ki = new KEYBDINPUT
                    {
                        wVk = VK_F23
                    }
                }
            };

            // F23 up
            inputs[3] = new INPUT
            {
                type = INPUT_KEYBOARD,
                u = new InputUnion
                {
                    ki = new KEYBDINPUT
                    {
                        wVk = VK_F23,
                        dwFlags = KEYEVENTF_KEYUP
                    }
                }
            };

            // Windows up
            inputs[4] = new INPUT
            {
                type = INPUT_KEYBOARD,
                u = new InputUnion
                {
                    ki = new KEYBDINPUT
                    {
                        wVk = VK_LWIN,
                        dwFlags = KEYEVENTF_KEYUP
                    }
                }
            };

            // Left-Shift up
            inputs[5] = new INPUT
            {
                type = INPUT_KEYBOARD,
                u = new InputUnion
                {
                    ki = new KEYBDINPUT
                    {
                        wVk = VK_LSHIFT,
                        dwFlags = KEYEVENTF_KEYUP
                    }
                }
            };

            Console.Write("Pressing Copilot Key in 3..");
            Thread.Sleep(1000);
            Console.Write(" 2..");
            Thread.Sleep(1000);
            Console.Write(" 1..");
            Thread.Sleep(1000);
            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
            Console.Write(" PRESSED!");
        }
    }
}
