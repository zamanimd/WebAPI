using Newtonsoft.Json;
using WebAPICore6.Model;

namespace WebAPICore6.Data
{
    public class DataManager
    {
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


        #region Create
        //--- Creat ---//
        public bool AddData(Drone drone)
        {
            try
            {
                bool result = false;
                var list = ReadAllData();

                list.Add(new Drone(drone.Id, drone.Name, drone.Description, drone.CreateDate, 0));

                var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
                WriteFile(convertedJson);

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
        public List<Drone> ReadAllData()
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

        public Drone ReadData(int id)
        {
            try
            {
                string jsonData = ReadFile();
                var drones = new List<Drone>();
                var _drone = new Drone();

                if (jsonData != null)
                {
                    drones = JsonConvert.DeserializeObject<List<Drone>>(jsonData);
                    if (drones != null)
                    {
                        _drone = drones
                            .Where(x => x.IsDeleted == 0)
                            .FirstOrDefault(x => x.Id == id);
                    }
                }

                return _drone;
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

                //foreach (Drone item in lst_drones)
                //{
                //    if (drone.Id == item.Id)
                //    {
                //        item.Name = drone.Name;
                //        item.Description = drone.Description;
                //        return Ok();
                //    }
                //}

                return result;
            }
            catch
            {
                return false;
            }
        }


        public bool RecoverAllData(int id)
        {
            try
            {
                bool result = false;

                //foreach (Drone item in lst_drones)
                //{
                //    if (drone.Id == item.Id)
                //    {
                //        item.Name = drone.Name;
                //        item.Description = drone.Description;
                //        return Ok();
                //    }
                //}

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

                //foreach (Drone item in lst_drones)
                //{
                //    if (drone.Id == item.Id)
                //    {
                //        item.Name = drone.Name;
                //        item.Description = drone.Description;
                //        return Ok();
                //    }
                //}

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
