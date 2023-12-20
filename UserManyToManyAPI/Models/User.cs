namespace UserManyToManyAPI.Models
{
    public class User
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Role> Roles { get; set; }
    }
}
