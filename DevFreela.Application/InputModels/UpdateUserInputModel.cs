namespace DevDreela.Application.InputModels;

public class UpdateUserInputModel
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public DateTime Birthday { get; set; }
    public bool Active { get; set; }
}