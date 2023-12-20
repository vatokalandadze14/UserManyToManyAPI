namespace UserManyToManyAPI.Models
{
    public class Role
    {
        public int id { get; set; }
        public string Name { get; set; }
        public List<Premission> Premissions { get; set; }
    }
}
