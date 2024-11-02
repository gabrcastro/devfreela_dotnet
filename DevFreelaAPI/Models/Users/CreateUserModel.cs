namespace DevFreelaAPI.Models.Users {
    public class CreateUserModel {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Ocupation { get; set; } = string.Empty;
    }
}
