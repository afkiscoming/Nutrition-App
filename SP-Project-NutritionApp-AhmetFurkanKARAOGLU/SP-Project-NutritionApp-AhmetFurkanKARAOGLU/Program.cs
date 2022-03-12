using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace SP_Project_NutritionApp_AhmetFurkanKARAOGLU
{
    class Program
    {
        //BY AHMET FURKAN KARAOGLU
        //CSE603
        public static void Main(string[] args)
        {

            List<double> IdArray = new List<double>();
            List<double> AgeArray = new List<double>();
            List<double> WeightArray = new List<double>();
            List<double> HeightArray = new List<double>();
            List<double> ActiveArray = new List<double>();

            List<string> NameArray = new List<string>();
            List<string> SurnameArray = new List<string>();
            List<string> GenderArray = new List<string>();

            double counter = 0;
            bool CanEnter = true;

            Console.WriteLine("Welcome To The Nutrition App!");
            Console.WriteLine();

            Console.WriteLine("Please Select What You Would Like To Do:");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("=============================================================");
                Console.WriteLine("1- Add a New Patient");
                Console.WriteLine("2- Calculate The Patient's Body Mass Index (BMI)");
                Console.WriteLine("3- Calculate The Patient's Daily Water Intake");
                Console.WriteLine("4- See The Patient's Information");
                Console.WriteLine("5- Save/Print The Patient's Information");
                Console.WriteLine("Q- Exit The App");
                Console.WriteLine("=============================================================");

                string selectedOption = Console.ReadLine();
                Console.WriteLine();

                if (selectedOption == "q")
                {
                    SelectionExitApp();    //OPTION EXIT APP
                    break;
                }
                else if (selectedOption == "1")
                {
                    Selection1();   //OPTION1
                }
                else if (selectedOption == "2")
                {
                    Selection2();   //OPTION 2
                }
                else if (selectedOption == "3")
                {
                    Selection3();   //OPTION 3
                }
                else if (selectedOption == "4")
                {
                    Selection4();   //OPTION 4
                }
                else if (selectedOption == "5")
                {
                    Selection5();   //OPTION 5
                }
                else
                {
                    InvalidOption(); //INVALID OPTION
                }
            }

            void SelectionExitApp()
            {
                Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX\n         EXITING THE APP...\nXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            }

            void Selection1()
            {

                Console.WriteLine("- The Patient's ID Number is: " + (counter + 1));
                IdArray.Add(counter);

                Console.Write("- Write The Patient's Name: ");
                string input = Console.ReadLine();
                NameArray.Add(input);

                Console.Write("- Write The Patient's Surname: ");
                input = Console.ReadLine();
                SurnameArray.Add(input);

                Console.Write("- Write The Patient's Age: ");
                input = Console.ReadLine();
                AgeArray.Add(double.Parse(input));

                Console.Write("- Write The Patient's Gender (f/m): ");
                input = Console.ReadLine();
                GenderArray.Add(input);

                Console.Write("- How Active is The Patient in a day (on a scale of 1 to 3): ");
                input = Console.ReadLine();
                ActiveArray.Add(double.Parse(input));

                Console.Write("- Write The Patient's Height: ");
                input = Console.ReadLine();
                HeightArray.Add(double.Parse(input));

                Console.Write("- Write The Patient's Weight: ");
                input = Console.ReadLine();
                WeightArray.Add(double.Parse(input));

                Console.WriteLine("\n++++++++++++++++++++++++\n     PATIENT ADDED!\n++++++++++++++++++++++++");

                Console.WriteLine();
                counter++;
                CanEnter = false;
            }

            void Selection2()
            {
                if (CanEnter == true)
                {
                    AddNewPatient();
                }

                else
                {
                    int n;
                    double HWrate;
                    Console.Write("* Which Patient's Body Mass Index (BMI) would you like to calculate? (ID NUMBER): ");
                    n = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    HWrate = 10000 * (WeightArray[n - 1] / (HeightArray[n - 1] * HeightArray[n - 1]));
                    Console.WriteLine("- Your Body Mass Index is: " + Math.Round(HWrate, 1));

                    if (HWrate <= 18.4)
                    {
                        Console.WriteLine("- Your Body Mass Index is UNDERWEIGHT!\n" +
                                            "- You should try including more protein, carbohydrates and healthy fats into your diet.");
                    }
                    else if (HWrate >= 18.5 || HWrate <= 24.9)
                    {
                        Console.WriteLine("- Your Body Mass Index is NORMAL.\n" +
                                            "- Keep your diet and physical activity balanced.");
                    }
                    else if (HWrate >= 25 || HWrate <= 29.9)
                    {
                        Console.WriteLine("- Your Body Mass Index is OVERWEIGHT!\n" +
                                            "- You should try including more vegetables and fruits into your diet.");
                    }
                    else if (HWrate >= 30 || HWrate <= 34.9)
                    {
                        Console.WriteLine("- Your Body Mass Index is OBESE!\n" +
                                            "- You should try avoiding processed sugars, and engaging into some type of physical activity daily.");
                    }
                    else if (HWrate >= 35)
                    {
                        Console.WriteLine("- Your Body Mass Index is EXTREMELY OBESE!\n" +
                                            "- You should immediately get in touch with your Nutritionist!! ");
                    }
                    Console.WriteLine();
                }
            }

            void Selection3()
            {
                if (CanEnter == true)
                {
                    AddNewPatient();
                }
                else
                {
                    int n;
                    double waterUsage, waterNeeded;
                    Console.Write("* Which Patient's Daily Water Intake would you like to calculate? (ID NUMBER): ");
                    n = int.Parse(Console.ReadLine());

                    Console.Write("* How many liters of Water do you drink daily? (if it's a decimal number; seperate by a dot): ");
                    waterUsage = double.Parse(Console.ReadLine());
                    Console.WriteLine();

                    if (ActiveArray[n - 1] == 1)
                    {
                        waterNeeded = WeightArray[n - 1] * 0.033;
                        Console.WriteLine("- Your Daily Water Intake should be: " + Math.Round(waterNeeded, 1) + " liters");

                        if (waterUsage < waterNeeded)
                        {
                            Console.WriteLine("- You should drink " + (Math.Round(waterNeeded - waterUsage, 1)) + " more liters of water.");
                        }
                        else if (waterUsage == waterNeeded)
                        {
                            Console.WriteLine("- Your water intake is normal.");
                        }
                        else
                        {
                            Console.WriteLine("- You should drink " + (Math.Round(waterUsage - waterNeeded, 1)) + " less liters of water.");
                        }
                    }
                    else if (ActiveArray[n - 1] == 2)
                    {
                        waterNeeded = WeightArray[n - 1] * 0.04;
                        Console.WriteLine("- Your Daily Water Intake should be: " + Math.Round(waterNeeded, 1) + " liters");

                        if (waterUsage < waterNeeded)
                        {
                            Console.WriteLine("- You should drink " + (Math.Round(waterNeeded - waterUsage, 1)) + " more liters of water.");
                        }
                        else if (waterUsage == waterNeeded)
                        {
                            Console.WriteLine("- Your water intake is normal.");
                        }
                        else
                        {
                            Console.WriteLine("- You should drink " + (Math.Round(waterUsage - waterNeeded, 1)) + " less liters of water.");
                        }
                    }
                    else if (ActiveArray[n - 1] == 3)
                    {
                        waterNeeded = WeightArray[n - 1] * 0.05;
                        Console.WriteLine("- Your Daily Water Intake should be: " + Math.Round(waterNeeded, 1) + " liters");

                        if (waterUsage < waterNeeded)
                        {
                            Console.WriteLine("- You should drink " + (Math.Round(waterNeeded - waterUsage, 1)) + " more liters of water.");
                        }
                        else if (waterUsage == waterNeeded)
                        {
                            Console.WriteLine("- Your water intake is normal.");
                        }
                        else
                        {
                            Console.WriteLine("- You should drink " + (Math.Round(waterUsage - waterNeeded, 1)) + " less liters of water.");
                        }
                    }
                }
                Console.WriteLine();
            }

            void Selection4()
            {
                if (CanEnter == true)
                {
                    AddNewPatient();
                }
                else
                {
                    int n;
                    Console.Write("* Which Patient's Information would you like to see? (ID NUMBER): ");
                    n = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    {
                        Console.WriteLine("- Patient's ID Number: " + n);
                        Console.WriteLine("- Patient's Name: " + NameArray[n - 1]);
                        Console.WriteLine("- Patient's Surname: " + SurnameArray[n - 1]);
                        Console.WriteLine("- Patient's Age: " + AgeArray[n - 1]);
                        Console.WriteLine("- Patient's Gender: " + GenderArray[n - 1]);
                        Console.WriteLine("- Patient's Activity Status: " + ActiveArray[n - 1]);
                        Console.WriteLine("- Patient's Height: " + HeightArray[n - 1]);
                        Console.WriteLine("- Patient's Weight: " + WeightArray[n - 1]);
                    }
                    Console.WriteLine();
                }
            }

            void Selection5()
            {
                if (CanEnter == true)
                {
                    AddNewPatient();
                }
                else
                {
                    while (true)
                    {

                        string[] InfoArray = {"Patient's ID Number: ","Patient's Name: ", "Patient's Surname: ", "Patient's Age: ", "Patient's Gender: ",
                                            "Patient's Activity Status: ", "Patient's Height: ", "Patient's Weight: " };

                        Console.WriteLine("* Would you like to export only one person or all the patients?\n");
                        Console.WriteLine("1- Only 1 Patient");
                        Console.WriteLine("2- The Whole Patient List");
                        Console.WriteLine("3- Turn Back to Main Menu");
                        string exportSelection = Console.ReadLine();
                        Console.WriteLine();

                        if (exportSelection == "1")
                        {
                            //ONE PATIENT

                            int n;
                            Console.Write("* Which Patient's Information would you like to save/print? (ID NUMBER): ");
                            n = int.Parse(Console.ReadLine());

                            Console.Write("- Please Write The File Name: ");
                            string file = Console.ReadLine();
                            string text = "";
                            Console.WriteLine();


                            text += InfoArray[0];
                            text += n + "\n";
                            text += InfoArray[1];
                            text += NameArray[n - 1] + "\n";
                            text += InfoArray[2];
                            text += SurnameArray[n - 1] + "\n";
                            text += InfoArray[3];
                            text += AgeArray[n - 1] + "\n";
                            text += InfoArray[4];
                            text += GenderArray[n - 1] + "\n";
                            text += InfoArray[5];
                            text += ActiveArray[n - 1] + "\n";
                            text += InfoArray[6];
                            text += HeightArray[n - 1] + "\n";
                            text += InfoArray[7];
                            text += WeightArray[n - 1] + "\n\n";

                            File.WriteAllText(file, text);
                            Console.WriteLine("+++++++++++++++++++++\n     FILE SAVED!\n+++++++++++++++++++++\n");
                        }

                        else if (exportSelection == "2")
                        {
                            //WHOLE LIST

                            Console.Write("- Please Write The File Name: ");
                            string file = Console.ReadLine();
                            string text = "";
                            Console.WriteLine();

                            for (int i = 0; i < counter; i++)
                            {
                                text += InfoArray[0];
                                text += i + 1 + "\n";
                                text += InfoArray[1];
                                text += NameArray[i] + "\n";
                                text += InfoArray[2];
                                text += SurnameArray[i] + "\n";
                                text += InfoArray[3];
                                text += AgeArray[i] + "\n";
                                text += InfoArray[4];
                                text += GenderArray[i] + "\n";
                                text += InfoArray[5];
                                text += ActiveArray[i] + "\n";
                                text += InfoArray[6];
                                text += HeightArray[i] + "\n";
                                text += InfoArray[7];
                                text += WeightArray[i] + "\n\n";
                            }
                            File.WriteAllText(file, text);
                            Console.WriteLine("+++++++++++++++++++++\n     FILE SAVED!\n+++++++++++++++++++++\n");
                        }
                        else if (exportSelection == "3")
                        {
                            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX\n       TURNING BACK TO MAIN MENU...\n" +
                                                "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX\n");
                            break;
                        }
                        else
                        {
                            InvalidOption();
                        }
                    }
                }
            }

            void InvalidOption()
            {
                Console.WriteLine("#########################################\n     PLEASE CHOOSE A VALID OPTION!!!\n#########################################\n");
            }

            void AddNewPatient()
            {
                Console.WriteLine("#########################################\n    PLEASE FIRST ADD A NEW PATIENT!!!\n#########################################\n");
            }

        }
    }
}
