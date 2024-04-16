using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe(); // new instance of the recipe class

            Console.WriteLine("***WELCOME TO MY RECIPE BOOK***");

            while (true)
            { // display menu options
                Console.WriteLine("Enter option:");
                Console.WriteLine("1. Enter recipe details");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Clear all data");
                Console.WriteLine("5. Exit");

                int option = int.Parse(Console.ReadLine()); // input users choice

                switch (option) // perform action based on users input
                {
                    case 1:
                        recipe.EnterDetails(); // calls EnterDetails method
                        break;
                    case 2:
                        recipe.Display(); // calls Display method
                        break;
                    case 3:
                        recipe.Scale(); // calls Scale method
                        break;
                    case 4:
                        recipe = new Recipe(); // clears all recipe data
                        break;
                    case 5:
                        break; // exits the program

                }
            }
        }
    } 

    class Recipe
    {
        private int numIngredients;
        private string[] name;
        private double[] quantity;
        private string[] units;
        private int numSteps;
        private string[] steps;

        public void EnterDetails()
        { // input the number of ingredients
            Console.WriteLine("Enter the number of Ingredients: ");
            numIngredients = int.Parse(Console.ReadLine());

            // intialiszes arrays to store ingredient details
            name = new string[numIngredients];
            quantity = new double[numIngredients];  
            units = new string[numIngredients];

            // input details for each ingredient
            for (int i = 0; i <numIngredients; i++)
            {
                Console.WriteLine($"Enter the name of the Ingredients {i + 1}: ");
                name[i] = Console.ReadLine();

                Console.WriteLine($"Enter the quantity of the Ingredients {i + 1}: ");
                quantity[i] = double.Parse(Console.ReadLine());

                Console.WriteLine($"Enter the units of measurements of the Ingredients {i + 1}: ");
                units[i] = Console.ReadLine();

            }

            // input the number of steps
            Console.WriteLine("Enter the number of steps: ");
            numSteps = int.Parse(Console.ReadLine());

            // initizes array to store steps
            steps = new string[numSteps];

            // input details for each step
            for (int i = 0; i < numSteps;i++)
            {
                Console.WriteLine($"Enter step {i+1}: ");
                steps[i] = Console.ReadLine();
            }

        }

        public void Display()
        { // display the ingredients
            Console.WriteLine("Ingredients: ");
            for (int i = 0;i < numIngredients;i++)
            {
                Console.WriteLine($"{name[i]}: {quantity[i]} {units[i]}");
            }

            // display the steps
            Console.WriteLine("Steps: ");
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        
        }

        public void Scale()
        { // input the scale factor
            Console.WriteLine("Enter scale factor (0.5, 2, 3: ");
            double factor = double.Parse(Console.ReadLine());   

            // scale the quantity of each ingredient
            for(int i = 0; i < numIngredients; i++)
            {
                quantity[i] *= factor;
            }
        }

    }

}
   
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    