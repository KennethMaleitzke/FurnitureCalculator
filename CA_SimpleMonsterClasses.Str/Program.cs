using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_SimpleMonsterClasses
{
    class Program
    {
        // *********************************************************
        // Author: Kenneth Maleitzke
        // Date: 12/3/18
        // Modified: 12/5/18
        // Project: Furniture Calculator
        // *********************************************************
        static void Main(string[] args)
        {
            DisplayOpeningScreen();
            DisplayMenu();
            DisplayClosingScreen();
        }

        //
        // Calculate Cost Per Square Foot
        //
        static void DisplayCalculatePricePerSquareFoot()
        {
            string userResponse;
            string userLength;
            string userWidth;
            double area;
            double total;

            DisplayHeader("Carpet Calculator");

            Console.Write("Please Enter the Length:");
            userLength = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Please Enter the Width:");
            userWidth = Console.ReadLine();
            Console.Write("Please Enter a budget:");
            userResponse = Console.ReadLine();
            Console.WriteLine();


            double.TryParse(userLength, out double length);
            double.TryParse(userWidth, out double width);
            double.TryParse(userResponse, out double budget);

            Console.WriteLine($"Length: {length}");
            Console.WriteLine($"Width: {width}");
            Console.WriteLine($"Budget: ${budget}");

            area = length + width;
            total = budget / area;

            Console.WriteLine($"Total Price Per Square Foot: ${total}");

            DisplayContinuePrompt();
        }

        //
        // Calculate the total of all Furniture Items
        //
        static void DisplayTotalValueOfItems(List<FurnitureItems> furnitureItems)
        {
            double total;

            DisplayHeader("Calculate Value of Items");

            total = 0;
            foreach (FurnitureItems furnitureItem in furnitureItems)
            {
                total += furnitureItem.Value;
            }

            Console.WriteLine($"Total Value of Items: ${total}");

            DisplayContinuePrompt();

        }

        /// <summary>
        /// instantiate and initialize furniture item dresser
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>FurnitureItem object</returns>
        static FurnitureItems InitializeFurnitureItemDresser(string name)
        {
            FurnitureItems dresser = new FurnitureItems(name);

            dresser.Weight = 2.5;
            dresser.CurrentCondition = FurnitureItems.ConditionOfFurniture.Good;
            dresser.Room = "Bedroom";
            dresser.Value = 150.00;

            return dresser;
        }

        /// <summary>
        /// instantiate and initialize furniture item bed
        /// </summary>
        /// <returns>FurnitureItems object</returns>
        static FurnitureItems InitializeFurnitureItemBed()
        {
            FurnitureItems bed = new FurnitureItems();

            bed.NameOfItem = "Bed";
            bed.Weight = 50;
            bed.CurrentCondition = FurnitureItems.ConditionOfFurniture.Okay;
            bed.Room = "Bedroom";
            bed.Value = 200.50;

            return bed;
        }

        /// <summary>
        /// display all information about Furniture Items
        /// </summary>
        /// <param name="furnitureItems">furnitureItem object</param>
        static void DisplayFurnitureItemInfo(List<FurnitureItems> furnitureItems)
        {
            string userFurnitureItemChoice;

            DisplayHeader("Display Furniture Item Info");

            //
            // Get Furniture Item from user
            //
            foreach (FurnitureItems furnitureItem in furnitureItems)
            {
                Console.WriteLine(furnitureItem.NameOfItem);
            }
            Console.WriteLine();
            Console.Write("Enter Name:");
            userFurnitureItemChoice = Console.ReadLine();

            //
            // Display furniture item info
            //
            bool furnitureItemFound = false;
            foreach (FurnitureItems furnitureItem in furnitureItems)
            {
                if (furnitureItem.NameOfItem == userFurnitureItemChoice)
                {
                    Console.WriteLine(furnitureItem.NameOfItem);
                    Console.WriteLine(furnitureItem.Weight);
                    Console.WriteLine(furnitureItem.CurrentCondition);
                    Console.WriteLine(furnitureItem.Room);
                    Console.WriteLine(furnitureItem.Value);
                    furnitureItemFound = true;
                    break;
                }
            }

            if (!furnitureItemFound)
            {
                Console.WriteLine($"Unable to locate the sea monster named {userFurnitureItemChoice}");
            }

            DisplayContinuePrompt();
        }

        static void DisplayDeleteFurnitureItemInfo(List<FurnitureItems> furnitureItems)
        {
            string userFurnitureChoice;

            DisplayHeader("Delete Furniture Item Info");

            //
            // Get Furniture Item name from user
            //
            foreach (FurnitureItems furnitureItem in furnitureItems)
            {
                Console.WriteLine(furnitureItem.NameOfItem);
            }
            Console.WriteLine();
            Console.Write("Enter Name:");
            userFurnitureChoice = Console.ReadLine();

            //
            // Delete a furniture item. 
            //
            bool furnitureItemFound = false;
            foreach (FurnitureItems furnitureItem in furnitureItems)
            {
                if (furnitureItem.NameOfItem == userFurnitureChoice)
                {
                    furnitureItems.Remove(furnitureItem);
                    furnitureItemFound = true;
                    break;
                }
            }

            if (!furnitureItemFound)
            {
                Console.WriteLine($"Unable to locate the furniture named {userFurnitureChoice}");
            }

            DisplayContinuePrompt();
        }
        /// <summary>
        /// display a list of all furniture items
        /// </summary>
        /// <param name="furnitureItems">list of Furniture Items</param>
        static void DisplayAllFurnitureItems(List<FurnitureItems> furnitureItems)
        {
            DisplayHeader("List of Furniture Items");

            foreach (FurnitureItems furnitureItem in furnitureItems)
            {
                Console.WriteLine(furnitureItem.CurrentConditionInfo());
            }
            
            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a screen to get a new furniture from the user
        /// </summary>
        /// <param name="furnitureItems">list of SeaMonster</param>
        static void DisplayGetUserFurnitureItems(List<FurnitureItems> furnitureItems)
        {
            //
            // Create (instantiate) a new FurnitureItem object
            //
            FurnitureItems userFurnitureItem = new FurnitureItems();

            DisplayHeader("Add a Furniture Item");
            
            //
            // Get the FurnitureItem object's proptery values from user
            //
            Console.Write("Enter Name:");
            userFurnitureItem.NameOfItem = Console.ReadLine();
            Console.Write("Enter Weight:");
            double.TryParse(Console.ReadLine(), out double weight);
            userFurnitureItem.Weight = weight;
            Console.Write("Enter Conditional State:");
            Enum.TryParse(Console.ReadLine(), out FurnitureItems.ConditionOfFurniture conditionalState);
            userFurnitureItem.CurrentCondition = conditionalState;
            Console.Write("Enter Value:");
            double.TryParse(Console.ReadLine(), out double value);
            userFurnitureItem.Value = value;

            //
            // add FurnitureItem object to list
            //
            furnitureItems.Add(userFurnitureItem);

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display menu and process user menu choices
        /// </summary>
        static void DisplayMenu()
        {
            //
            // instantiate furniture items
            //
            FurnitureItems bed;
            bed = InitializeFurnitureItemBed();
            FurnitureItems dresser;
            dresser = InitializeFurnitureItemDresser("Dresser");

            //
            // add furniture items to list
            //
            List<FurnitureItems> furnitureItems = new List<FurnitureItems>();
            furnitureItems.Add(bed);
            furnitureItems.Add(dresser);

            string menuChoice;
            bool exiting = false;

            while (!exiting)
            {
                DisplayHeader("Main Menu");

                Console.WriteLine("\tA) Display All Furniture Items");
                Console.WriteLine("\tB) Add a Furniture Item");
                Console.WriteLine("\tC) Delete a Furniture Item");
                Console.WriteLine("\tD) Display Furniture Item Info");
                Console.WriteLine("\tE) Display Calculations");
                Console.WriteLine("\tF) Display Carpet Calculator");
                Console.WriteLine("\tG) Exit");

                Console.Write("Enter Choice:");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "A":
                    case "a":
                        DisplayAllFurnitureItems(furnitureItems);
                        break;

                    case "B":
                    case "b":
                        DisplayGetUserFurnitureItems(furnitureItems);
                        break;

                    case "C":
                    case "c":
                        DisplayDeleteFurnitureItemInfo(furnitureItems);
                        break;

                    case "D":
                    case "d":
                        DisplayFurnitureItemInfo(furnitureItems);
                        break;

                    case "E":
                    case "e":
                        DisplayTotalValueOfItems(furnitureItems );
                        break;

                    case "F":
                    case "f":
                        DisplayCalculatePricePerSquareFoot();
                        break;

                    case "G":
                    case "g":
                        exiting = true;
                        break;

                    default:
                        break;
                }
            }
        }

        #region HELPER METHODS

        /// <summary>
        /// display opening screen
        /// </summary>
        static void DisplayOpeningScreen()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("\t\tWelcome to the Furniture Calculator");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display closing screen
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("\t\tThanks for using my Furniture Calculator.");
            Console.WriteLine();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display header
        /// </summary>
        static void DisplayHeader(string headerTitle)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerTitle);
            Console.WriteLine();
        }

        #endregion


    }
}
