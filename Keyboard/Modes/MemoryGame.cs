using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Keyboard.SDKHooks;

namespace Keyboard.Modes
{
    public class MemoryGame
    {
        private bool continueGame = true;
        private int roundNum = 1;
        private int difficulty;
        private List<int> currentCombo = new List<int>(); 

        public MemoryGame(int userDifficulty)
        {
            if (userDifficulty < 1 || userDifficulty > 100)
            {
                Console.Write("Error: Value out of range. Switching to default of 4");
                difficulty = 4;
            }
            else
            {
                difficulty = userDifficulty;
            }
            DLLImport.SetControlDevice(DEVICE_INDEX.DEV_MKeys_L_White);
        }

        public MemoryGame()
        {
            difficulty = 4;
            DLLImport.SetControlDevice(DEVICE_INDEX.DEV_MKeys_L_White);
        }

        private bool GameLogic()
        {
            // Show user the combo
            for (int i = 0; i < difficulty; i++)
            {
                // Switch to light the appropriate key
                // For Keyboards with white LED's only the red byte matters
                switch (currentCombo[i])
                {
                    // Up key show, wait, then hide
                    case 0: DLLImport.SetLedColor(4, 16, 255, 255, 255);
                        Thread.Sleep(1000);
                        DLLImport.SetLedColor(4, 16, 0, 0, 0);
                        Thread.Sleep(500);
                        break;

                    // Left key show, wait, then hide
                    case 1: DLLImport.SetLedColor(5, 15, 255, 255, 255);
                        Thread.Sleep(1000);
                        DLLImport.SetLedColor(5, 15, 0, 0, 0);
                        Thread.Sleep(500);
                        break;
                    
                    // Down key show, wait, then hide
                    case 2: DLLImport.SetLedColor(5, 16, 255, 255, 255);
                        Thread.Sleep(1000);
                        DLLImport.SetLedColor(5, 16, 0, 0, 0);
                        Thread.Sleep(500);
                        break;
                    
                    // Right key show, wait, then hide
                    case 3: DLLImport.SetLedColor(5, 17, 255, 255, 255);
                        Thread.Sleep(1000);
                        DLLImport.SetLedColor(5, 17, 0, 0, 0);
                        Thread.Sleep(500);
                        break;
                    default:
                        return true;
                }
            }

            // Read user input from the console
            for (int i = 0; i < difficulty; i++)
            {
                //Match key with first combo in List
                ConsoleKey userGuess = Console.ReadKey().Key;
                if (userGuess == ConsoleKey.UpArrow && currentCombo[0] == 0)
                {
                    Console.Write("\nCorrect!");
                    currentCombo.RemoveAt(0);
                }
                else if (userGuess == ConsoleKey.LeftArrow && currentCombo[0] == 1)
                {
                    Console.Write("\nCorrect!");
                    currentCombo.RemoveAt(0);
                }
                else if (userGuess == ConsoleKey.DownArrow && currentCombo[0] == 2)
                {
                    Console.Write("\nCorrect!");
                    currentCombo.RemoveAt(0);
                }
                else if (userGuess == ConsoleKey.RightArrow && currentCombo[0] == 3)
                {
                    Console.Write("\nCorrect!");
                    currentCombo.RemoveAt(0);
                }

                // Break out of function if the user gets it wrong
                else
                {
                    Console.Write("\nIncorrect!\n");
                    return false;
                }
            }
            return true;
        }

        private void VictoryFlash()
        {
            for (int i = 0; i < 3; i++)
            {
                DLLImport.SetLedColor(5, 17, 255, 255, 255);
                DLLImport.SetLedColor(5, 16, 255, 255, 255);
                DLLImport.SetLedColor(5, 15, 255, 255, 255);
                DLLImport.SetLedColor(4, 16, 255, 255, 255);
                Thread.Sleep(200);
                DLLImport.SetLedColor(5, 17, 0, 0, 0);
                DLLImport.SetLedColor(5, 16, 0, 0, 0);
                DLLImport.SetLedColor(5, 15, 0, 0, 0);
                DLLImport.SetLedColor(4, 16, 0, 0, 0);
                Thread.Sleep(100);
            }
        }

        public void StartGame()
        {
            while (continueGame)
            {
                // Flash the keys to tell user the round is advancing
                VictoryFlash();

                // Main loop for creating new combos and waiting for user input
                Random rand = new Random();
                for (int i = 0; i < difficulty; i++)
                {
                    currentCombo.Add(rand.Next(0, 4));
                }
                continueGame = GameLogic();
                roundNum++;
                Console.Write("\nRound " + roundNum);
                difficulty++;
            }
        } 
    }
}
