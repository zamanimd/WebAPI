namespace WebAPICore6.Model
{
    public class Drone
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        //public drone()
        //{

        //}

        public Drone(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        //public void GetDrones()
        //{
        //    string dbDirectory = Path.Combine(Directory.GetCurrentDirectory(), $"Data\\{"db_Drone.json"}");
        //    var JSON = System.IO.File.ReadAllText(dbDirectory);
        //    var root = JsonConvert.DeserializeObject<Drone>(JSON);

        //}

    }
}
