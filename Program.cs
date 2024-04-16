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
            Recipe recipe = new Recipe();

            Console.WriteLine("***WELCOME TO MY RECIPE BOOK***");

            while (true)
            {
                Console.WriteLine("Enter option:");
                Console.WriteLine("1. Enter recipe details");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Clear all data");
                Console.WriteLine("5. Exit");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        recipe.EnterDetails();
                        break;
                    case 2:
                        recipe.Display();
                        break;
                    case 3:
                        recipe.Scale();
                        break;
                    case 4:
                        recipe = new Recipe();
                        break;
                    case 5:
                        break;

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
        {
            Console.WriteLine("Enter the number of Ingredients: ");
            numIngredients = int.Parse(Console.ReadLine());

            name = new string[numIngredients];
            quantity = new double[numIngredients];  
            units = new string[numIngredients];

            for (int i = 0; i <numIngredients; i++)
            {
                Console.WriteLine($"Enter the name of the Ingredients {i + 1}: ");
                name[i] = Console.ReadLine();

                Console.WriteLine($"Enter the quantity of the Ingredients {i + 1}: ");
                quantity[i] = double.Parse(Console.ReadLine());

                Console.WriteLine($"Enter the units of measurements of the Ingredients {i + 1}: ");
                units[i] = Console.ReadLine();

            }

            Console.WriteLine("Enter the number of steps: ");
            numSteps = int.Parse(Console.ReadLine());

            steps = new string[numSteps];

            for (int i = 0; i < numSteps;i++)
            {
                Console.WriteLine($"Enter step {i+1}: ");
                steps[i] = Console.ReadLine();
            }

        }

        public void Display()
        {
            Console.WriteLine("Ingredients: ");

            for (int i = 0;i < numIngredients;i++)
            {
                Console.WriteLine($"{name[i]}: {quantity[i]} {units[i]}");
            }

            Console.WriteLine("Steps: ");

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        
        }

        public void Scale()
        {
            Console.WriteLine("Enter scale factor (0.5, 2, 3: ");
            double factor = double.Parse(Console.ReadLine());   

            for(int i = 0; i < numIngredients; i++)
            {
                quantity[i] *= factor;
            }
        }

    }

}
   
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    