using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control - Data Recorder & Talent Show
    // Description: Progrom is able to deisplay the Talent
    //              Show and Data Recorder application 
    // Application Type: Console
    // Author: Andrew Schaub
    // Dated Created: 2/19/2020
    // Last Modified: 3/1/2020
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
                        LightAlarmDisplayMenuScreen(finchRobot);
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

        #region ALARM SYSTEM
        static void LightAlarmDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitMenu = false;
            string menuChoice;

            string sensorToMonitor = "";
            string rangeType = "";
            int minMaxThresholdValue = 0;
            int timeToMonitor = 0;
            int minMaxTempValue = 0;

            do
            {
                DisplayScreenHeader("Light Alram Menu Screen");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Set Sensor to Monitor");
                Console.WriteLine("\tb) Set Range Type");
                Console.WriteLine("\tc) Set Mininum/Maxium Threshold Value for temperature and light");
                Console.WriteLine("\td) Set Time to Monitor");
                Console.WriteLine("\te) Set Alarm");
                Console.WriteLine("\tq) Return to Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        sensorToMonitor = LightAlarmDisplaySetSensorToMonitor();
                        break;

                    case "b":
                         rangeType = LightAlarmDisplaySetRangeType();
                        break;

                    case "c":
                        minMaxThresholdValue = LightAlarmSetMinMaxThresholValue(rangeType, finchRobot);
                        break;

                    case "d":
                        timeToMonitor = LightAlarmSetTimeToMonitor();
                        break;

                    case "e":
                        LightAlarmSetAlarm(finchRobot, sensorToMonitor, rangeType, minMaxThresholdValue, minMaxTempValue, timeToMonitor);
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



        static string LightAlarmDisplaySetSensorToMonitor()
        {
            string sensorToMonitor;

            DisplayScreenHeader("Sensors to Monitor");

            monitorQuestion:
            Console.WriteLine("Sensors to Monitor [left, right or both]:");
            sensorToMonitor = Console.ReadLine();

            if (sensorToMonitor == "left")
            {
                Console.WriteLine($"The {sensorToMonitor} sensor will be monitored");
            }
            else if (sensorToMonitor == "right")
            {
                Console.WriteLine($"The {sensorToMonitor} sensor will be monitored");
            }
            else if (sensorToMonitor == "both")
            {
                Console.WriteLine($"{sensorToMonitor} sensors will be monitored");
            }
            else
            {
                Console.WriteLine("Please select one of the following left, right or both" );
                goto monitorQuestion;
            }

            DisplayMenuPrompt("Light Alarm");

            return sensorToMonitor;
        }
        static string LightAlarmDisplaySetRangeType()
        {
            string rangeType;

            DisplayScreenHeader("Range Type");

            rangeQuestion:
            Console.WriteLine("Range Type [minimum, maximum]:");
            rangeType = Console.ReadLine();

            if (rangeType == "minimum")
            {
                Console.WriteLine($"You have selected the {rangeType} range");
            }
            else if (rangeType == "maximum")
            {
                Console.WriteLine($"You have selected the {rangeType} range");
            }
            else
            {
                Console.WriteLine("Sorry please select the minimum or maximum option");
                goto rangeQuestion;
            }

            DisplayMenuPrompt("Light Alarm");

            return rangeType;
        }
        static int LightAlarmSetMinMaxThresholValue(string rangeType, Finch finchRobot)
        {
            int minMaxThresholdValue;
            int minMaxTempValue;
            DisplayScreenHeader("Minimum/Maximum Threshold Value");

            Console.WriteLine($"Left light senor ambient value: {finchRobot.getLeftLightSensor()}");
            Console.WriteLine($"RIght light senor ambient value: {finchRobot.getRightLightSensor()}");
            Console.WriteLine();

            // validate value
            Console.WriteLine($"Enter the {rangeType} light sensor value:");
            int.TryParse(Console.ReadLine(), out minMaxThresholdValue);
            Console.WriteLine($"You have entered {minMaxThresholdValue} as your light sensor value");
            Console.WriteLine();

            // room temperature
            Console.WriteLine($"Room temperature: {finchRobot.getTemperature()}");

            // user response
            Console.WriteLine($"Enter the {rangeType} temperature value: ");
            int.TryParse(Console.ReadLine(), out minMaxTempValue);
            Console.WriteLine($"You have entered {minMaxTempValue} as your temperature value");
            Console.WriteLine();


            DisplayMenuPrompt("Light Alarm");

            return minMaxThresholdValue;
        }  

        static int LightAlarmSetTimeToMonitor()
        {
            int timeToMonitor;

            DisplayScreenHeader("Time to Monitor");


            // validate value
            Console.WriteLine($"Time to Monitor");
            int.TryParse(Console.ReadLine(), out timeToMonitor);
            Console.WriteLine($"The finch robot will monitor the light value for {timeToMonitor} seconds");

            DisplayMenuPrompt("Light Alarm");

            return timeToMonitor;
        }
        static void LightAlarmSetAlarm(
            Finch finchRobot, 
            string sensorToMonitor, 
            string rangeType, 
            int minMaxThresholdValue,
            int minMaxTempValue,
            int timeToMonitor)
        {
            int secondsElasped = 0;
            bool thresholdExceeded = false;
            int currentLightSensorValue = 0;

            DisplayScreenHeader("Set Alarm");

            Console.WriteLine($"Sensors to monitor: {sensorToMonitor}");
            Console.WriteLine($"Range Type: {rangeType}");
            Console.WriteLine($"Min/Max Threshold Value: {minMaxThresholdValue}");
            Console.WriteLine($"Min/Max Temp Value: {minMaxTempValue}");
            Console.WriteLine($"Time to Monitor: {timeToMonitor} seconds");
            Console.WriteLine();

            Console.WriteLine("Press any key to begin monitoring");
            Console.ReadKey();
            Console.WriteLine();

            while ((secondsElasped < timeToMonitor) && !thresholdExceeded)

            {
                switch (sensorToMonitor)
                {
                    case "left":
                        currentLightSensorValue = finchRobot.getLeftLightSensor();
                        break;

                    case "right":
                        currentLightSensorValue = finchRobot.getRightLightSensor();
                        break;

                    case "both":
                        currentLightSensorValue = (finchRobot.getRightLightSensor() + finchRobot.getLeftLightSensor()) / 2;
                        break;
                }

                Console.WriteLine($"Left light senor ambient value: {finchRobot.getLeftLightSensor()}");
                Console.WriteLine($"RIght light senor ambient value: {finchRobot.getRightLightSensor()}");
                Console.WriteLine($"Room temperature: {finchRobot.getTemperature()}");
                Console.WriteLine();

                switch (rangeType)
                {
                    case "minimum":
                        if (currentLightSensorValue < minMaxThresholdValue)
                        {
                            thresholdExceeded = true;
                            finchRobot.setLED(255, 0, 0);
                            finchRobot.noteOn(5000);
                            finchRobot.wait(2000);
                            finchRobot.noteOff();
                            finchRobot.setLED(0, 0, 0);
                            Console.WriteLine
                                ("********************************************************" +
                                "*  WARNING WARNING WARING A VALUE HAS BEEN EXCEEDED    *" +
                                "********************************************************");
                        }
                        break;

                    case "maximum":
                        if (currentLightSensorValue > minMaxThresholdValue)
                        {
                            thresholdExceeded = true;
                            thresholdExceeded = true;
                            finchRobot.setLED(255, 0, 0);
                            finchRobot.noteOn(5000);
                            finchRobot.wait(2000);
                            finchRobot.noteOff();
                            finchRobot.setLED(0, 0, 0);
                            Console.WriteLine
                                ("********************************************************" +
                                 "*  WARNING WARNING WARING A VALUE HAS BEEN EXCEEDED    *" +
                                 "********************************************************");
                        }
                        break;
                }
                finchRobot.wait(1000);
                secondsElasped++;
            }

            if (thresholdExceeded)
            {
                Console.WriteLine($"The {rangeType} threshold value of {minMaxThresholdValue}  was exceeded by the current light sensor value of {currentLightSensorValue}");
            }
            else
            {
                Console.WriteLine($"The {rangeType} threshold value of {minMaxThresholdValue} was not exceeded");
            }
            DisplayMenuPrompt("Light Alarm");
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
