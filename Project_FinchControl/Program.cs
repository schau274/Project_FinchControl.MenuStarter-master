using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control - Menu Starter
    // Description: Starter solution with the helper methods,
    //              opening and closing screens, and the menu
    // Application Type: Console
    // Author: Velis, John
    // Dated Created: 1/22/2020
    // Last Modified: 1/25/2020
    //
    // **************************************************

    class Program
    {
        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch finchRobot = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        DisplayTalentShowMenuScreen(finchRobot);
                        break;

                    case "c":
                        DataRecorderDisplayMenuScreen(finchRobot);
                        break;

                    case "d":

                        break;

                    case "e":

                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(finchRobot);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
        static void DisplayTalentShowMenuScreen(Finch myFinch)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) Dance");
                Console.WriteLine("\tc) Mixing It Up");
                Console.WriteLine("\td) ");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayLightAndSound(myFinch);
                        break;

                    case "b":
                        DisplayDance(myFinch);
                        break;

                    case "c":
                        MixingItUp(myFinch);
                        break;

                    case "d":

                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayLightAndSound(Finch finchRobot)

        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Light and Sound");

            Console.WriteLine("\tThe Finch robot will not show off its glowing talent!");
            DisplayContinuePrompt();

            for (int lightSoundLevel = 0; lightSoundLevel < 210; lightSoundLevel++)
            {
                finchRobot.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                finchRobot.noteOn(lightSoundLevel * 75);
            }
        ColorSelecton:
            Console.WriteLine("What color would you like to see red , blue or green?");
            string userColorResponse = Console.ReadLine();

            if (userColorResponse == "red")
            {
                finchRobot.setLED(255, 0, 0);
            }
            else if (userColorResponse == "green")
            {
                finchRobot.setLED(0, 255, 0);
            }
            else if (userColorResponse == "blue")
            {
                finchRobot.setLED(0, 0, 255);
            }
            else
            {
                Console.WriteLine("You did not select one of those colors");
                goto ColorSelecton;
            }
        LowOrHigh:
            Console.WriteLine("Would you like to hear high or low noise?");
            string userNoiseResponse = Console.ReadLine();

            if (userNoiseResponse == "high")
            {
                finchRobot.noteOn(3000);
            }
            else if (userNoiseResponse == "low")
            {
                finchRobot.noteOn(500);
            }
            else
            {
                Console.WriteLine("Please select a low or high frequency");
                goto LowOrHigh;
            }
            Console.WriteLine("Those are my light and sound talents.");
            DisplayMenuPrompt("Talent Show Menu");
            finchRobot.noteOff();
        }

        static void DisplayDance(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Dance");

            Console.WriteLine("Be prepared to be impressed");
            DisplayContinuePrompt();

            Console.WriteLine("The Lost Finch");
            finchRobot.setLED(0, 0, 255);
            finchRobot.setMotors(-100, 0);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 0);
            finchRobot.setMotors(0, -100);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 0);
            finchRobot.setMotors(100, 100);
            finchRobot.wait(2000);
            finchRobot.setMotors(0, 0);
            finchRobot.setMotors(100, 0);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 0);
            finchRobot.setMotors(0, -100);
            finchRobot.wait(2000);
            finchRobot.setMotors(0, 0);
            finchRobot.setMotors(100, 100);
            finchRobot.wait(2000);
            finchRobot.setMotors(0, 0);

        WhatShape:
            Console.WriteLine("I can go drive in the shape of squares and triangles. What one would you like to see?");
            string userShapeResponse = Console.ReadLine();

            if (userShapeResponse == "triangle")
            {
                Console.WriteLine("Triangle it is!");
                finchRobot.setLED(50, 45, 0);
                finchRobot.setMotors(35, 100);
                finchRobot.wait(4000);
                finchRobot.setMotors(0, 0);
                finchRobot.setMotors(0, 100);
                finchRobot.wait(2300);
                finchRobot.setMotors(0, 0);
                finchRobot.setMotors(100, 80);
                finchRobot.wait(2500);
                finchRobot.setMotors(0, 0);
                finchRobot.setMotors(0, 100);
                finchRobot.wait(2300);
                finchRobot.setMotors(0, 0);
                finchRobot.setMotors(100, 80);
                finchRobot.wait(2500);
                finchRobot.setMotors(0, 0);
            }
            else if (userShapeResponse == " square")
            {
                Console.WriteLine("Well isn't that sqaure of you!");
                finchRobot.setLED(50, 45, 0);
                finchRobot.setMotors(100, 100);
                finchRobot.wait(3000);
                finchRobot.setMotors(0, 0);
                finchRobot.setMotors(100, 0);
                finchRobot.wait(1500);
                finchRobot.setMotors(0, 0);
                finchRobot.setMotors(100, 100);
                finchRobot.wait(3000);
                finchRobot.setMotors(0, 0);
                finchRobot.setMotors(100, 0);
                finchRobot.wait(1500);
                finchRobot.setMotors(0, 0);
                finchRobot.setMotors(100, 100);
                finchRobot.wait(3000);
                finchRobot.setMotors(0, 0);
                finchRobot.setMotors(100, 0);
                finchRobot.wait(1500);
                finchRobot.setMotors(0, 0);
                finchRobot.setMotors(100, 100);
                finchRobot.wait(3000);
                finchRobot.setMotors(0, 0);
            }
            else
            {
                Console.WriteLine("Sorry please choose between triangle or square.");
                goto WhatShape;
            }

            DisplayMenuPrompt("Talent Show Menu");
        }
        static void MixingItUp(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("#MIXINGITUP");

            Console.WriteLine("Watch me!");
            finchRobot.setLED(255, 10, 0);
            finchRobot.noteOn(500);
            finchRobot.setMotors(100, 80);
            finchRobot.wait(1500);
            finchRobot.setMotors(0, 0);
            finchRobot.setLED(235, 30, 0);
            finchRobot.noteOn(1000);
            finchRobot.setMotors(100, 80);
            finchRobot.wait(1500);
            finchRobot.setMotors(0, 0);
            finchRobot.setLED(215, 50, 0);
            finchRobot.noteOn(1500);
            finchRobot.setMotors(100, 80);
            finchRobot.wait(1500);
            finchRobot.setMotors(0, 0);
            finchRobot.setLED(195, 70, 0);
            finchRobot.noteOn(2000);
            finchRobot.setMotors(100, 80);
            finchRobot.wait(1500);
            finchRobot.setMotors(0, 0);
            finchRobot.setLED(175, 90, 0);
            finchRobot.noteOn(2500);
            finchRobot.setMotors(100, 80);
            finchRobot.wait(1500);
            finchRobot.setMotors(0, 0);
            finchRobot.setLED(155, 110, 0);
            finchRobot.noteOn(3000);
            finchRobot.setMotors(100, 80);
            finchRobot.wait(1500);
            finchRobot.setMotors(0, 0);
            finchRobot.setLED(135, 130, 0);
            finchRobot.noteOn(3500);
            finchRobot.setMotors(100, 80);
            finchRobot.wait(1500);
            finchRobot.setMotors(0, 0);
            finchRobot.setLED(115, 150, 0);
            finchRobot.noteOn(4000);
            finchRobot.setMotors(100, 80);
            finchRobot.wait(1500);
            finchRobot.setMotors(0, 0);
            finchRobot.setLED(95, 170, 0);
            finchRobot.noteOn(4500);
            finchRobot.setMotors(100, 80);
            finchRobot.wait(1500);
            finchRobot.setMotors(0, 0);
            finchRobot.setLED(75, 190, 0);
            finchRobot.noteOn(5000);
            finchRobot.setMotors(100, 80);
            finchRobot.wait(1500);
            finchRobot.setMotors(0, 0);
            finchRobot.noteOff();

            Console.WriteLine("That is all folks");

            DisplayMenuPrompt("Talent Show Menu");
        }

        #endregion

        #region DATA RECORDER

        static void DataRecorderDisplayMenuScreen(Finch finchRobot)
        {
            int numberOfDataPoints = 0;
            double dataPointFrequency = 0;
            double[]temperature = null;
            int fahrenhiet = (numberOfDataPoints * 9) /5 + 32;
            double averageTemperature = (fahrenhiet / dataPointFrequency);
            Console.CursorVisible = true;

            bool quitMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Data Recorder Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Number of Data Points");
                Console.WriteLine("\tb) Frequency of Data Points");
                Console.WriteLine("\tc) Get Data");
                Console.WriteLine("\td) Show Data");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        numberOfDataPoints = DataRecorderDisplayGetNumberOfDataPoints();
                        break;

                    case "b":
                        dataPointFrequency = DataRecorderDisplayGetDataFrequency();
                        break;

                    case "c":
                        temperature = DataRecorderDisplayGetData(numberOfDataPoints, dataPointFrequency, finchRobot);
                        break;

                    case "d":
                        DataRecorderDisplayData(temperature);
                        break;
                        
                    case "q":
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);
        }

        static void DataRecorderDisplayData(double[] temperature)
        {
            DisplayScreenHeader("Show Data");
            //
            // display table headers
            //
            Console.WriteLine(
                "Recording #".PadLeft(15) +
                "Temp".PadLeft(15)
                );
            Console.WriteLine(
                "-----------".PadLeft(15) +
                "-----------".PadLeft(15)
                );
            //
            // display table data
            //
            for (int index = 0; index < temperature.Length; index++)
            {
                Console.WriteLine(
                    (index + 1).ToString().PadLeft(15) +
                    temperature[index].ToString("n2").PadLeft(15)
                     );
            }
            DisplayContinuePrompt();
        }

        static double[] DataRecorderDisplayGetData(int numberOfDataPoints, double dataPointFrequency, Finch finchRobot)
        {
            double[] temperature  = new double[numberOfDataPoints];

            DisplayScreenHeader("Get Data");

            Console.WriteLine($"\tNumber of Data Points: {numberOfDataPoints}");
            Console.WriteLine($"\tData point frequency: {dataPointFrequency}");
            Console.WriteLine();
            Console.WriteLine("The finch robot is ready to begin the temperature data");
            DisplayContinuePrompt();

            for (int index = 0; index < numberOfDataPoints; index++)
            {
                temperature[index] = finchRobot.getTemperature();
                Console.WriteLine($"\tReading {index + 1}: {temperature[index].ToString("n2")}");
                int waitInSeconds = (int)(dataPointFrequency * 1000);
                finchRobot.wait(waitInSeconds);
            }

            DisplayContinuePrompt();

            return temperature;
        }


        /// <summary>
        /// Get the frequency of data points
        /// </summary>
        /// <returns>frequency of data</returns>
        static double DataRecorderDisplayGetDataFrequency()
        {
            double dataPointFrequency;

            DisplayScreenHeader("Data Points Frequency");
          

            Console.Write("Frequency of Data Points: ");

            //  validate user input
            double.TryParse(Console.ReadLine(), out dataPointFrequency);

            DisplayContinuePrompt();

            return dataPointFrequency;
        }

        /// <summary>
        /// get the number of data points
        /// </summary>
        /// <returns>number of data points</returns>
        static int DataRecorderDisplayGetNumberOfDataPoints()
        {
            int numberOfDataPoints;
            string userResponse;
            DisplayScreenHeader("Number of Data Points");

            Console.Write("Number of Data Points: ");
            userResponse = Console.ReadLine();
            //  validate user input
            int.TryParse(userResponse, out numberOfDataPoints);

            DisplayContinuePrompt();

            return numberOfDataPoints;

        }

        #endregion

        #region FINCH ROBOT MANAGEMENT

        /// <summary>
        /// *****************************************************************
        /// *               Disconnect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");
            DisplayContinuePrompt();

            finchRobot.disConnect();

            Console.WriteLine("\tThe Finch robot is now disconnect.");

            DisplayMenuPrompt("Main Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *                  Connect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinuePrompt();

            robotConnected = finchRobot.connect();

            // TODO test connection and provide user feedback - text, lights, sounds

            DisplayMenuPrompt("Main Menu");

            //
            // reset finch robot
            //
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();

            return robotConnected;
        }

        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}
