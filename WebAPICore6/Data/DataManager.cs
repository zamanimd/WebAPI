using Newtonsoft.Json;
using WebAPICore6.Model;

namespace WebAPICore6.Data
{
    public class DataManager
    {
        public enum SelectData
        {
            All,
            Deleted,
            NotDeleted
        }

        static string dbDirectory = Path.Combine(Directory.GetCurrentDirectory(), $"Data\\{"db_Drone.json"}");

        string ReadFile()
        {
            string jsonData = System.IO.File.ReadAllText(dbDirectory);
            return jsonData;
        }

        void WriteFile(string content)
        {
            File.WriteAllText(dbDirectory, content);
        }

        public List<Drone> GetAllData()
        {
            try
            {
                string jsonData = ReadFile();
                var drones = new List<Drone>();

                if (jsonData != null)
                    drones = JsonConvert.DeserializeObject<List<Drone>>(jsonData);

                return drones;
            }
            catch
            {
                return null;
            }
        }



        #region Create
        //--- Creat ---//
        public bool AddData(Drone drone)
        {
            try
            {
                bool result = false;
                var lst_Drones = GetAllData();

                lst_Drones.Add(new Drone(drone.Id, drone.Name, drone.Description, drone.CreateDate, drone.IsDeleted));

                var convertedJson = JsonConvert.SerializeObject(lst_Drones, Formatting.Indented);
                WriteFile(convertedJson);

                result = true;
                return result;
            }
            catch
            {
                return false;
            }
        }

        #endregion



        #region Read
        //--- Read ---//
        public Drone ReadData(int id)
        {
            try
            {
                var lst_Drones = GetAllData();
                if (lst_Drones == null)
                    return null;

                return lst_Drones.FirstOrDefault(x => x.Id == id && x.IsDeleted == 0);
            }
            catch
            {
                return null;
            }
        }

        public Drone ReadData(string name)
        {
            try
            {
                var lst_Drones = GetAllData();
                if (lst_Drones == null)
                    return null;

                return lst_Drones.FirstOrDefault(x => x.Name == name && x.IsDeleted == 0);
            }
            catch
            {
                return null;
            }
        }

        //--- Read ---//
        public List<Drone> ReadAllData()
        {
            try
            {
                var lst_Drones = GetAllData();
                if (lst_Drones == null)
                    return null;
                lst_Drones = lst_Drones.Where(x => x.IsDeleted == 0).ToList();

                return lst_Drones;
            }
            catch
            {
                return null;
            }
        }

        #endregion



        #region Update
        //--- Update ---//
        public bool UpdateData(Drone drone)
        {
            try
            {
                bool result = false;
                var lst_Drones = GetAllData();

                foreach (Drone item in lst_Drones)
                {
                    if (item.Id == drone.Id && item.IsDeleted == 0)
                    {
                        item.Name = drone.Name;
                        item.Description = drone.Description;
                        item.CreateDate = drone.CreateDate;
                        item.IsDeleted = drone.IsDeleted;
                        break;
                    }
                }
                var convertedJson = JsonConvert.SerializeObject(lst_Drones, Formatting.Indented);
                WriteFile(convertedJson);

                result = true;
                return result;
            }
            catch
            {
                return false;
            }
        }

        public bool RecoverAllData()
        {
            try
            {
                bool result = false;
                var lst_Drones = GetAllData();

                foreach (Drone item in lst_Drones)
                {
                    item.IsDeleted = 0;
                }
                var convertedJson = JsonConvert.SerializeObject(lst_Drones, Formatting.Indented);
                WriteFile(convertedJson);

                result = true;
                return result;
            }
            catch
            {
                return false;
            }
        }

        public bool RecoverData(int id)
        {
            try
            {
                bool result = false;
                var lst_Drones = GetAllData();

                foreach (Drone item in lst_Drones)
                {
                    if (item.Id == id)
                    {
                        item.IsDeleted = 0;
                        break;
                    }
                }
                var convertedJson = JsonConvert.SerializeObject(lst_Drones, Formatting.Indented);
                WriteFile(convertedJson);

                result = true;
                return result;
            }
            catch
            {
                return false;
            }
        }

        #endregion



        #region Delete
        //--- Delete ---//
        public bool RemoveAllData()
        {
            try
            {
                bool result = false;
                var lst_Drones = GetAllData();

                foreach (Drone item in lst_Drones)
                {
                    item.IsDeleted = 1;
                }
                var convertedJson = JsonConvert.SerializeObject(lst_Drones, Formatting.Indented);
                WriteFile(convertedJson);

                result = true;
                return result;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveData(int id)
        {
            try
            {
                bool result = false;
                var lst_Drones = GetAllData();

                foreach (Drone item in lst_Drones)
                {
                    if (item.Id == id && item.IsDeleted == 0)
                    {
                        item.IsDeleted = 1;
                        break;
                    }
                }
                var convertedJson = JsonConvert.SerializeObject(lst_Drones, Formatting.Indented);
                WriteFile(convertedJson);

                result = true;
                return result;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveData(string name)
        {
            try
            {
                bool result = false;
                var lst_Drones = GetAllData();

                foreach (Drone item in lst_Drones)
                {
                    if (item.Name == name && item.IsDeleted == 0)
                    {
                        item.IsDeleted = 1;
                        result = true;
                        break;
                    }
                }
                var convertedJson = JsonConvert.SerializeObject(lst_Drones, Formatting.Indented);
                WriteFile(convertedJson);

                return result;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
