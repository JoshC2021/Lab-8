using System;
using System.Linq;

namespace ArrayAccess
{
    class Program
    {
        public static int studentID = 0;
        public static string[,] students = {                                            
                                                 {"Josh","Joshua","Ramon","Antonio","Wendi","Nathan","Jeffrey","Juliana","Nick",
                                                    "Grace","Jeremiah", "Tommy","Stephen",},

                                                 {"Baldwin, MI", "Novi, MI", "Tigard, OR", "Beverly Hills, MI", "Detroit, MI", "Berkley, MI", "Detroit, MI",
                                                    "Denver, CO", "Canton, MI", "Mesa, Az", "Crystal, MI", "Raleigh NC","The Moon", },

                                                 { "Falafel", "Naleśniki", "Burgers", "Focaccia Barese", "Salami", "Steak",
                                                    "Steak", "Tacos", "Tacos", "sweet potato fries", "Burgers", "Chicken Curry","Mooncakes" },

                                                 { "Red", "Blue", "Green", "Orange", "Purple", "Black",
                                                    "Silver", "Yellow", "Gold", "Pink", "Brown", "Gray","White" }
                                            };
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our C# class. ");
            do
            {
                Update();
            }
            while (GoAgain());
        }

        public static void Update()
        {
            ValidateID();
            DisplayInfo(GetInfo());
        }
        public static string GetInput()
        {
            Console.WriteLine();
            Console.Write("Which student would you like to learn more about? (enter their name or number 1-13): ");
            return Console.ReadLine();
        }

        // This method tries to find a valid student in the array
        public static void ValidateID()
        {
            studentID = -1;
            string input = GetInput().Trim();
            try
            {
                // is user trying to search by ID or name
                if (input.Any(char.IsDigit))
                {
                    studentID = int.Parse(input) - 1;
                    input = students[0, studentID];
                }
                else
                {
                    // loop iterates using the columns of the array or amount of students
                    for (int i = 0; i < students.GetLength(1); i++)
                    {
                        if(students[0,i] == input)
                        {
                            studentID = i;
                        }
                    }
                    // no student found
                    if(studentID == -1)
                    {
                        throw new Exception("That student does not exist. Please try again.");
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("That is not a valid ID. Please try again");
                ValidateID();
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("That student does not exist. Please try again.");
                ValidateID();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                ValidateID();
            }
        }
        // this method tries to tell what the user wants to know
        public static int GetInfo()
        {
            Console.WriteLine();
            Console.Write($"What would you like to know about {students[0,studentID]}? \n(enter “hometown” or “favorite food” or “favorite color“):");
            string input = Console.ReadLine().ToLower().Trim();
            try
            {
                bool IsNotValid = true;

                // only looking for specific info
                if(input == "hometown" || input == "favorite food" || input == "favorite color")
                {
                    IsNotValid = false;
                }
                if(IsNotValid)
                {
                    throw new Exception("That data does not exist. Please try again.");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                GetInfo();
            }

            return (input =="hometown")?1:(input == "favorite food")?2:3;
        }


        // displays info based on user selection
        public static void DisplayInfo(int x)
        {
            string output = (x == 1) ? $"{students[0, studentID]} is from {students[x, studentID]}":
                            (x == 2) ? $"{students[0, studentID]}'s favorite food is {students[x, studentID]}"
                                     : $"{students[0, studentID]}'s favorite color is {students[x, studentID]}";
            Console.WriteLine(output);
        }


        // identifies if the user wants to continue to get info
        public static bool GoAgain()
        {
            Console.WriteLine();
            Console.Write("Would you like to learn more? (enter \"yes\" or \"no\"): ");
            string input = Console.ReadLine().ToLower().Trim();
            try
            {
                if (input != "yes" )
                {
                    if (input != "no")
                    {
                        throw new Exception("Invalid response, please try again");
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                GoAgain();
            }

            if(input == "yes")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Goodbye");
                return false;
            }
        }
    }
}


