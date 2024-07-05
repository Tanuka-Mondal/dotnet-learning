using System.IO;
using System.Linq;

using BicycleApp.Models;

namespace BicycleApp.Repository
{
    public class BicycleRepository : IBicycleRepository
    {
        List<Bicycle> bicycle = new List<Bicycle>();

        #region Constructor
        public BicycleRepository()
        {
            if (File.Exists("bicycleData.txt"))
            {
                //int counter = 1;
                string[] bicycleData = File.ReadAllLines("bicycleData.txt");
                foreach (var item in bicycleData)
                {
                    string[] eachItem = item.Split('\t');
                    bicycle.Add(new Bicycle()
                    {
                        Id = Convert.ToInt32(eachItem[0]),
                        Name = eachItem[1],
                        Category = eachItem[2],
                        Price = Convert.ToDecimal(eachItem[3])
                    });
                    //counter++;
                }
            }
        }
        #endregion

        #region bicycle exist
        public Bicycle IsBicycleExist(Bicycle bicycleObj)
        {
            Bicycle? bicycleObject = null;
            foreach (var bicyclesObj in bicycle)
            {
                if (bicyclesObj != null && bicyclesObj.Name == bicycleObj.Name)
                {
                    bicycleObject = bicyclesObj;
                    break;
                }
                else
                {
                    continue;
                }
            }
            return bicycleObject;
        }
        #endregion

        #region Get All Bicycles
        public List<Bicycle> GetAllBicycles()
        {

            return bicycle;
        }
        #endregion

        #region Add Bicycles
        public bool AddBicycle(Bicycle bicycleObj)
        {
            bicycleObj.Id = bicycle.Count + 1;
            bicycle.Add(bicycleObj);
            File.AppendAllText("bicycleData.txt", bicycleObj.Display());
            File.AppendAllText("bicycleData.txt", "\n");
            return true;
        }
        #endregion

        #region Get Bicycle By Id
        public Bicycle GetBicycleById(int id)
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
        #endregion

        #region Get Bicycle By Name
        public Bicycle GetBicycleByName(string name)
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
        #endregion

        #region Edit Bicycle
        public Bicycle EditBicycle(int editId, string oldParam, string editValue)
        {
            string[] bicycleData = File.ReadAllLines("bicycleData.txt");
            Bicycle bicycleObject = null;


            int lineNumberToEdit = editId;
            string stringToReplace;
            string newString = editValue;

            Bicycle bicycleToEdit = bicycle[editId - 1];
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

        #endregion

        #region Delete Bicycle
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
        #endregion
    }
}
