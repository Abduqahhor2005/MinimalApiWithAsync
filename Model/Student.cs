namespace Client.Model;

public class Student
{
    public int Id { get; set; }
    public string First_Name { get; set; } = null!;
    public string Last_Name { get; set; } = null!;
    public string Phone_Number { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
    public bool Is_deleted { get; set; }
}