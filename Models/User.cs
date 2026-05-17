namespace BogeyGolfersWeb.models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}