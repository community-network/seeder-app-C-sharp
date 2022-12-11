using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace seeder_app_C_sharp;

internal class SendKeys
{

        static Input[] CreateInput(ushort key_code, ushort wvk, KeyEventF flags)
        {
		Input[] inputs =
		{
			new Input
			{
				type = (int)SendInputEventType.InputKeyboard,
				u = new InputUnion
				{
					ki = new KeyboardInput
					{
						wVk = wvk,
						wScan = (ushort) key_code,
						dwFlags = (uint)flags,
						dwExtraInfo = IntPtr.Zero
					}
				}
			}
		};
		return inputs;
    }

	static void KeyDown(ushort key_code)
	{
		Input[] input = CreateInput(key_code, 0, KeyEventF.KeyDown | KeyEventF.Scancode);
		SendInput((uint)input.Length, input, Marshal.SizeOf(typeof(Input)));
	}

	static void KeyUp(ushort key_code)
	{
		Input[] input = CreateInput(key_code, 0, KeyEventF.KeyUp | KeyEventF.Scancode);
		SendInput((uint)input.Length, input, Marshal.SizeOf(typeof(Input)));
	}

	static void SpecialDown(ushort key_code)
	{
		Input[] input = CreateInput(0, key_code, KeyEventF.ExtendedKey);
		SendInput((uint)input.Length, input, Marshal.SizeOf(typeof(Input)));
	}

        static void SpecialUp(ushort key_code)
        {
		Input[] input = CreateInput(0, key_code, KeyEventF.ExtendedKey | KeyEventF.KeyUp);
		SendInput((uint)input.Length, input, Marshal.SizeOf(typeof(Input)));
	}

        public static void KeyEnter(ushort key_code, UInt64 timeout)
        {
            KeyDown(key_code);
            Thread.Sleep((int)timeout);
            KeyUp(key_code);
        }

        public static void SendString(List<Tuple<Chars.DXCode, ushort>> keys)
	{
		foreach (var key in keys)
		{
			if (key.Item1 == Chars.DXCode.Shifted)
                {
				Thread.Sleep(10);
                    SpecialDown(0x10);
				Thread.Sleep(10);
                    KeyEnter(key.Item2, 8);
				Thread.Sleep(10);
                    SpecialUp(0x10);
				Thread.Sleep(10);
                }
                else
                {
                    KeyEnter(key.Item2, 8);
                }
            }
        }

	[Flags]
	public enum SendInputEventType : int
	{
		InputMouse,
		InputKeyboard,
		InputHardware
	}

	[Flags]
	enum KeyEventF
        {
		KeyDown = 0x0000,
		ExtendedKey = 0x0001,
		KeyUp = 0x0002,
		Unicode = 0x0004,
		Scancode = 0x0008,
	}

	[Flags]
	enum MouseEventFlags : uint
	{
		MOUSEEVENTF_MOVE = 0x0001,
		MOUSEEVENTF_LEFTDOWN = 0x0002,
		MOUSEEVENTF_LEFTUP = 0x0004,
		MOUSEEVENTF_RIGHTDOWN = 0x0008,
		MOUSEEVENTF_RIGHTUP = 0x0010,
		MOUSEEVENTF_MIDDLEDOWN = 0x0020,
		MOUSEEVENTF_MIDDLEUP = 0x0040,
		MOUSEEVENTF_XDOWN = 0x0080,
		MOUSEEVENTF_XUP = 0x0100,
		MOUSEEVENTF_WHEEL = 0x0800,
		MOUSEEVENTF_VIRTUALDESK = 0x4000,
		MOUSEEVENTF_ABSOLUTE = 0x8000
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct KeyboardInput
	{
		public ushort wVk;
		public ushort wScan;
		public uint dwFlags;
		public uint time;
		public IntPtr dwExtraInfo;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct HardwareInput
	{
		public int uMsg;
		public short wParamL;
		public short wParamH;
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct InputUnion
	{
		[FieldOffset(0)] public readonly MouseInput mi;
		[FieldOffset(0)] public KeyboardInput ki;
		[FieldOffset(0)] public readonly HardwareInput hi;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct MouseInput
	{
		public readonly int dx;
		public readonly int dy;
		public readonly uint mouseData;
		public readonly uint dwFlags;
		public readonly uint time;
		public readonly IntPtr dwExtraInfo;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct Input
	{
		public int type;
		public InputUnion u;
	}

	[DllImport("user32.dll", SetLastError = true)]
	public static extern uint SendInput(uint numberOfInputs, Input[] inputs, int sizeOfInputStructure);
}
