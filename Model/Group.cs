namespace Client.Model;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Course_id { get; set; }
    public int Max_students { get; set; }
    public int Min_students { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
    public bool Is_deleted { get; set; }
}