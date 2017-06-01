using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keyboard.SDKHooks
{
    public static class DLLImport
    {
        private const string dllPath = @"..\..\SDK\SDKDLL.dll";

        // DllImport needed before each function declaration
        [DllImport(dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool EnableLedControl(bool bEnable);

        [DllImport(dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetControlDevice(DEVICE_INDEX deviceIndex);

        [DllImport(dllPath)]
        public static extern bool IsDevicePlug();

        [DllImport(dllPath)]
        public static extern LAYOUT_KEYBOARD GetDeviceLayout();

        [DllImport(dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SwitchLedEffect(EFF_INDEX iEffectIndex);

        [DllImport(dllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetLedColor(int iRow, int iColumn, byte r, byte g, byte b);
    }
}
