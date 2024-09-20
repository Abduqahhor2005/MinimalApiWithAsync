using System.Data.SqlTypes;
using System.Runtime.InteropServices.JavaScript;

namespace Client.Model;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime Duration_course { get; set; }
    public decimal Price { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
    public bool Is_deleted { get; set; }
}