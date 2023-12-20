namespace UserManyToManyAPI.Models
{
    public class RolePremissions
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PremissionId { get; set; }
    }
}
