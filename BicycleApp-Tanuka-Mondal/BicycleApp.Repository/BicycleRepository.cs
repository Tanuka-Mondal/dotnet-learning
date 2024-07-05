using System.IO;
using System.Linq;

using BicycleApp.Models;

namespace BicycleApp.Repository
{
    public class BicycleRepository : IBicycleRepository
    {
        public static int bicycleCount;
        int counter = 1;
        Bicycle[] bicycle = new Bicycle[bicycleCount];
        public BicycleRepository()
        {
            if (File.Exists("bicycleData.txt"))
            {
                string[] bicycleData = File.ReadAllLines("bicycleData.txt");
                foreach (var item  in bicycleData)
                {
                    string[] eachItem = item.Split('\t');
                    bicycle[counter-1] = new Bicycle()
                    {
                        Id = Convert.ToInt32(eachItem[0]),
                        Name = eachItem[1],
                        Category = eachItem[2],
                        Price = Convert.ToDecimal(eachItem[3])
                    };
                    counter++;
                }
            }
        }

        public Bicycle[] GetAllBicycles()
        {

            return bicycle;
        }

        public bool AddBicycle(Bicycle bicycleObj)
        {
            bicycleObj.Id = counter;
            bicycle[bicycleObj.Id] =bicycleObj;
            File.AppendAllText("bicycleData.txt", bicycleObj.Display());
            File.AppendAllText("bicycleData.txt", "\n");
            counter++;
            return true;
        }

        public Bicycle GetBycycleById(int id)
        {
            Bicycle bicycleObject = null;
            foreach(var bicyclesObj in bicycle)
            {
                if (bicyclesObj != null && bicyclesObj.Id == id)
                {
                    bicycleObject = bicyclesObj;
                }
                else
                {
                    continue;
                }
            }
            return bicycleObject;
        }

        public Bicycle GetBycycleByName(string name)
        {
            Bicycle bicycleObject = null;
            foreach (var bicyclesObj in bicycle)
            {
                if (bicyclesObj != null && bicyclesObj.Name == name)
                {
                    bicycleObject = bicyclesObj;
                }
                else
                {
                    continue;
                }
            }
            return bicycleObject;
        }

        public Bicycle EditBicycle(int editId, string oldParam, string editValue)
        {
            string[] bicycleData = File.ReadAllLines("bicycleData.txt");
            Bicycle bicycleObject = null;


            int lineNumberToEdit = editId;
            string stringToReplace;
            string newString = editValue;

            Bicycle bicycleToEdit = bicycle[editId-1];
            switch (oldParam.ToLower())
            {
                case "name":
                    stringToReplace = bicycle[editId - 1].Name;
                    bicycleToEdit.Name = editValue;                    
                    break;
                case "category":
                    stringToReplace = bicycle[editId - 1].Category;
                    bicycleToEdit.Category = editValue;                   
                    break;
                case "price":
                    decimal priceVal = bicycle[editId - 1].Price;
                    stringToReplace = priceVal.ToString();
                    bicycleToEdit.Price = Convert.ToDecimal(editValue);                    
                    break;
                default:
                    return bicycleObject; 
            }
            bicycle[editId - 1] = bicycleToEdit;

            if (lineNumberToEdit > 0 && lineNumberToEdit <= bicycleData.Length)
            {
                bicycleData[lineNumberToEdit - 1] = bicycleData[lineNumberToEdit - 1].Replace(stringToReplace, newString);

                File.WriteAllLines("bicycleData.txt", bicycleData);

                Console.WriteLine("The specified line has been updated.");
            }




            return bicycleObject;
        }

        public bool DeleteBicycle(int deleteId)
        {
            int lineNumberToDelete = deleteId;
            string[] bicycleData = File.ReadAllLines("bicycleData.txt");
            bicycle[deleteId - 1] = null;
            if (lineNumberToDelete > 0 && lineNumberToDelete <= bicycleData.Length)
            {
                bicycleData = bicycleData.Where((line, index) => index != lineNumberToDelete - 1).ToArray();
                File.WriteAllLines("bicycleData.txt", bicycleData);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
