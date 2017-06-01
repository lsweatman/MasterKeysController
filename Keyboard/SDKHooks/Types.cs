using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This file is necessary as the included SDK header has no namespace
namespace Keyboard.SDKHooks
{
    // Detailed in the SDK header file
    
    // Keyboard Region Layout
    public enum LAYOUT_KEYBOARD {
        LAYOUT_UNINIT = 0,
        LAYOUT_US = 1,
        LAYOUT_EU = 2 };

    // Compatible Devices
    public enum DEVICE_INDEX
    {
        DEV_MKeys_L = 0, DEV_MKeys_S = 1, DEV_MKeys_L_White = 2, DEV_MKeys_M_White = 3, DEV_MMouse_L = 4
                    , DEV_MMouse_S = 5, DEV_MKeys_M = 6, DEV_MKeys_S_White = 7,
    };

    // Current Effect
    public enum EFF_INDEX
    {
        EFF_FULL_ON = 0, EFF_BREATH = 1, EFF_BREATH_CYCLE = 2, EFF_SINGLE = 3, EFF_WAVE = 4, EFF_RIPPLE = 5,
        EFF_CROSS = 6, EFF_RAIN = 7, EFF_STAR = 8, EFF_SNAKE = 9, EFF_REC = 10,

        EFF_SPECTRUM = 11, EFF_RAPID_FIRE = 12, EFF_INDICATOR = 13, //mouse Eff

        EFF_MULTI_1 = 0xE0, EFF_MULTI_2 = 0xE1, EFF_MULTI_3 = 0xE2, EFF_MULTI_4 = 0xE3,
        EFF_OFF = 0xFE
    };
}
