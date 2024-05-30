using RecipeApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RecipeApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            RecipeBook recipeBook = new RecipeBook(); // new instance of the recipe class

            Console.WriteLine("***WELCOME TO MY RECIPE BOOK***");

            while (true)
            { // display menu options
                Console.WriteLine("Enter option:");
                Console.WriteLine("1. Add a recipe");
                Console.WriteLine("2. Display all recipes");
                Console.WriteLine("3. Display specific recipe");
                Console.WriteLine("4. Scale recipe");
                Console.WriteLine("5. Clear all data");
                Console.WriteLine("6. Exit");
            
                int option = int.Parse(Console.ReadLine()); // input users choice

                switch (option) // perform action based on users input
                {
                    case 1:
                        recipeBook.AddRecipe(); // calls AddRecipe method
                        break;
                    case 2:
                        recipeBook.DisplayAll(); // calls DisplayAll method
                        break;
                    case 3:
                        recipeBook.DisplaySpecific(); // calls DisplaySpecific method
                        break;
                    case 4:
                        recipeBook.ScaleRecipe(); // calls Scale method
                        break;
                    case 5:
                        recipeBook.ClearData(); // calls ClearData method
                        break;
                    case 6:
                        break; // exits the program

                }
            }
        }
    } 

    class RecipeBook
    {
        private List<Recipe> recipes = new List<Recipe>(); // list to store recipes

        public void AddRecipe()
        {
            Recipe recipe = new Recipe(); // create a new recipe
            recipe.EnterDetails(); // enter details for recipe
            recipes.Add(recipe); // add recipe to the list 
        }

        public void DisplayAll()
        { // display all the recipes
                
            if (recipes.Count == 0)
                {
                    Console.WriteLine("No recipes available.");
                    return;
                }

                Console.WriteLine("Recipes: ");
                foreach (var recipe in recipes.OrderBy(r => r.RecipeName))
                {
                    Console.WriteLine(recipe.RecipeName); // display each recipe
                }
            }
            public void DisplaySpecific()
            { // display a specfic recipe
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available.");
                return;
            }

            Console.WriteLine("Enter the name of the recipe you want to display:");
            string recipeName = Console.ReadLine();
            Recipe recipe = recipes.FirstOrDefault(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

            if (recipe == null)
            {
                Console.WriteLine("Recipe not found.");
            }
            else
            {
                recipe.Display(); // deipslay recipe details
            }

        }
        public void ScaleRecipe()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available.");
                return;
            }

            Console.WriteLine("Enter the name of the recipe you want to scale:");
            string recipeName = Console.ReadLine();
            Recipe recipe = recipes.FirstOrDefault(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

            if (recipe == null)
            {
                Console.WriteLine("Recipe not found.");
            }
            else
            {
                recipe.Scale(); // scale the recipe
            }
        }
        public void ClearData()
        { // thsi clears all the recipe data 
            recipes.Clear();
            Console.WriteLine("All recipe data cleared.");
        }
    }

    class Recipe
    {
        public string RecipeName { get; set; }
        private int numIngred;
        private string[] ingredientNames;
        private double[] quantities;
        private string[] units;
        private int[] calories;
        private string[] foodGroup;
        private int numSteps;
        private string[] steps;

        public void EnterDetails()
        { //  enetr recipe details
            Console.WriteLine("Enter the name of the recipe: ");
            RecipeName = Console.ReadLine();

            Console.WriteLine("Enter the number of ingredients: ");
            numIngred = int.Parse(Console.ReadLine());

            ingredientNames = new string[numIngred];
            quantities = new double[numIngred];
            units = new string[numIngred];
            calories = new int[numIngred];
            foodGroup = new string[numIngred];

            for (int i = 0; i < numIngred; i++)
            {
                Console.WriteLine($"Enter the name of ingredient {i + 1}: ");
                ingredientNames[i] = Console.ReadLine();

                Console.WriteLine($"Enter the quantity of ingredient {i + 1}: ");
                quantities[i] = double.Parse(Console.ReadLine());

                Console.WriteLine($"Enter the units of measurement for ingredient {i + 1}: ");
                units[i] = Console.ReadLine();

                Console.WriteLine($"Enter the number of calories for ingredient {i + 1}: ");
                calories[i] = int.Parse(Console.ReadLine());

                Console.WriteLine($"Enter the food group for ingredient {i + 1}: ");
                foodGroup[i] = Console.ReadLine();
            }

            Console.WriteLine("Enter the number of steps: ");
            numSteps = int.Parse(Console.ReadLine());

            steps = new string[numSteps];

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Enter step {i + 1}: ");
                steps[i] = Console.ReadLine();
            }
        }

        public void Display()
        { // display recipe details
            Console.WriteLine($"Recipe: {RecipeName}");
            Console.WriteLine("Ingredients:");
            for (int i = 0; i < numIngred; i++)
            {
                Console.WriteLine($"{ingredientNames[i]}: {quantities[i]} {units[i]} ({calories[i]} calories, {foodGroup[i]})");
            }

            Console.WriteLine("Steps:");
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }

            int totalCalories = calories.Sum();
            Console.WriteLine($"Total Calories: {totalCalories}");

            if (totalCalories > 300)
            {
                Console.WriteLine("Warning: The total calories exceed 300!");
            }
        }
        public void Scale()
        { // scale the recipe
            Console.WriteLine("Enter scale factor (e.g., 0.5, 2, 3):");
            double factor = double.Parse(Console.ReadLine());

            for (int i = 0; i < numIngred; i++)
            {
                quantities[i] *= factor; // scale each ingredient 
            }

            Console.WriteLine("The recipe has been scaled.");
        }

    }
}



   
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    