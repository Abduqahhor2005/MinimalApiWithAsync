using Client.Model;
using Dapper;
using Npgsql;

namespace Client.Service.StudentService;

public class StudentService : IStudentService
{
    public async Task<IEnumerable<Student>> GetAll()
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.QueryAsync<Student>(SqlCommands.GetAll);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Student?> GetById(int id)
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.QueryFirstOrDefaultAsync<Student>(SqlCommands.GetById,new{Id = id});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> CreateAsync(Student student)
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.ExecuteAsync(SqlCommands.Create,student)>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateAsync(Student student)
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.ExecuteAsync(SqlCommands.Update,student)>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.ExecuteAsync(SqlCommands.Delete,new {Id = id})>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}


file class SqlCommands
{
    public const string ConnectionString = "Host = localhost; Database = crm_db; User Id = postgres; Port = 4321; Password = salom";
    public const string GetAll = "select * from students";
    public const string GetById = "select * from students where id=@id";
    public const string Create = "insert into students(id,First_Name,Last_Name,Phone_Number,Address,Email,Created_at,Updated_at,Is_deleted) values(@id,@First_Name,@Last_Name,@Phone_Number,@Address,@Email,@Created_at,@Updated_at,@Is_deleted)";
    public const string Update = "update students set First_Name=@First_Name, Last_Name=@Last_Name, Phone_Number=@Phone_Number, Address=@Address, Email=@Email, Created_at=@Created_at, Updated_at=@Updated_at, Is_deleted=@Is_deleted where id = @id";
    public const string Delete = "delete from students where id=@id";
}