using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keyboard.SDKHooks;
using Keyboard.Modes;

namespace Keyboard
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool deviceStatus = DLLImport.IsDevicePlug();
            LAYOUT_KEYBOARD currentLayout = DLLImport.GetDeviceLayout();

            // Set the device type to control
            DLLImport.SetControlDevice(DEVICE_INDEX.DEV_MKeys_L_White);

            // Set the LED to control to software
            // Returns true if successful
            bool swLedControl = DLLImport.EnableLedControl(true);

            // Memory Game
            Console.Write("Start the Memory Game? (Y/N)");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.Write("Memory Game Starting\n");
                MemoryGame testGame = new MemoryGame();
                testGame.StartGame();
            }

            // Give control back to the device firmware
            bool fwLedControl = DLLImport.EnableLedControl(false);
        }
    }
}
