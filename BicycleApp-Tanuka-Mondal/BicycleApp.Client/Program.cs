using BicycleApp.Models;
using BicycleApp.Repository;

namespace BicycleApp.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region start

            Console.WriteLine("How many bikes do you want in the database?");
            BicycleRepository.bicycleCount = Convert.ToInt32(Console.ReadLine());
            BicycleRepository bicycleRepository = new BicycleRepository();
            IBicycleRepository _bicycleRepository = (IBicycleRepository)bicycleRepository;
            goto allOption;

            #endregion

            allOption:
            Console.WriteLine("What do you want to do? \nChoose 1 to see all bicycle" +
                "\nChoose 2 to add bicycle \nChoose 3 to edit bicycle \nChoose 4 to get bicycle by id" +
                "\nChoose 5 to get bicycle by name \nChoose 6 to delete bicycle " +
                "\nChoose 7 to exit");
            Console.Write("Your Option: ");
            int userInput = Convert.ToInt32(Console.ReadLine());
            if (userInput == 1)
            {
                goto displayAllBicycle;
            }
            else if (userInput == 2)
            {
                goto AddBicycle;
            }
            else if (userInput == 3)
            {
                goto EditBiCycle;
            }
            else if (userInput == 4)
            {
                goto GetBicycleById;
            }
            else if (userInput == 5)
            {
                goto GetBicycleByName;
            }
            else if (userInput == 6)
            {
                goto DeleteBicycle;
            }
            else if (userInput == 7)
            {
                goto exit;
            }

            #region display all bicycle   
            
            displayAllBicycle:
            Bicycle[] bicycle = bicycleRepository.GetAllBicycles();
            foreach (Bicycle bicycleObj in bicycle)
            {
                if (bicycleObj != null)
                {
                    Console.WriteLine(bicycleObj.Display());
                }
                else
                {
                    continue;
                }
            }

            goto allOption; 

            #endregion

            #region Add bicycle

            AddBicycle:
            Console.Write("Enter the Name of the bicycle: ");
            string Name = Console.ReadLine();
            Console.Write("Enter the Category of the bicycle: ");
            string Category = Console.ReadLine();
            
            Console.Write("Enter the Price of the bicycle: ");
            decimal Price = Convert.ToDecimal(Console.ReadLine());

            Bicycle newBicycle = new Bicycle()
            {
                Name = Name,
                Category = Category,
                Price = Price
            };
            bool bicycleAddStatus = bicycleRepository.AddBicycle(newBicycle);
            if (bicycleAddStatus)
            {
                goto displayAllBicycle;
            }

            #endregion

        #region Get Bicycle by Id
            GetBicycleById:
            Console.WriteLine("Enter the id of the bicycle: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Bicycle BicycleById = bicycleRepository.GetBycycleById(id);
            if (BicycleById != null) {
                Console.WriteLine(BicycleById.Display());
            }
            else
            {
                Console.WriteLine("Id not found!!!");
            }
            goto allOption;
        #endregion

        #region Get Bicycle by Name
            GetBicycleByName:
            Console.WriteLine("Enter the name of the bicycle: ");
            string name = Console.ReadLine();
            Bicycle BicycleByName = bicycleRepository.GetBycycleByName(name);
            if (BicycleByName != null)
            {
                Console.WriteLine(BicycleByName.Display());
            }
            else
            {
                Console.WriteLine("Name not found!!!");
            }
            goto allOption;
        #endregion

        #region Edit Bicycle data
            EditBiCycle:
            Console.WriteLine("Enter the id of the bicycle you want to edit: ");
            int editId = Convert.ToInt32(Console.ReadLine());
            Bicycle EditBicycle = bicycleRepository.GetBycycleById(editId);
            if (EditBicycle != null)
            {
                Console.WriteLine("What parameter do you want to edit? Name | Category | Price");
                string oldParam = Console.ReadLine();
                Console.WriteLine("Write the edited value: ");
                string editValue = Console.ReadLine();
                Bicycle EditedBicycle = bicycleRepository.EditBicycle(editId,oldParam,editValue);
                goto displayAllBicycle;
            }
            else
            {
                Console.WriteLine("Id not found!!!");
                goto allOption;
            }
        #endregion

        #region Delete Bicycle
        DeleteBicycle:
            Console.WriteLine("Enter the id of the bicycle you want to delete: ");
            int deleteId = Convert.ToInt32(Console.ReadLine());
            Bicycle DeleteBicycle = bicycleRepository.GetBycycleById(deleteId);
            if (DeleteBicycle != null)
            {
                bool DeleteBiCycleStatus = bicycleRepository.DeleteBicycle(deleteId);
                if (DeleteBiCycleStatus == true)
                {
                    goto displayAllBicycle;
                }
                else
                {
                    Console.WriteLine("Deletion not possible!!");
                    goto allOption;
                }
            }
            else
            {
                Console.WriteLine("Id Not Found!!");
            }

        #endregion

        exit:
            Console.WriteLine("Thank you for using bicycle app by Tanuka");
        }
    }
}
