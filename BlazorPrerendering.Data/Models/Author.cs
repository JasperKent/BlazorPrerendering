namespace BlazorPrerendering.Data.Models;

public class Author
{
    public int Id { get; set; }
    public  required string FirstName { get; set; }
    public  required string Surname { get; set; }
    public string Nationality { get; set; } = "";
}
