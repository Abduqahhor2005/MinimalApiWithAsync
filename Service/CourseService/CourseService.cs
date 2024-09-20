using Client.Model;
using Dapper;
using Npgsql;

namespace Client.Service.CourseService;

public class CourseService : ICourseService
{
    public async Task<IEnumerable<Course>> GetAll()
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.QueryAsync<Course>(SqlCommands.GetAll);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Course?> GetById(int id)
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.QueryFirstOrDefaultAsync<Course>(SqlCommands.GetById,new{Id = id});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> CreateAsync(Course course)
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.ExecuteAsync(SqlCommands.Create,course)>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateAsync(Course course)
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.ExecuteAsync(SqlCommands.Update,course)>0;
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
    public const string GetAll = "select * from courses";
    public const string GetById = "select * from courses where id=@id";
    public const string Create = "insert into courses(id,Name,Duration_course,Price,Created_at,Updated_at,Is_deleted) values(@id,@Name,@Duration_course,@Price,@Created_at,@Updated_at,@Is_deleted)";
    public const string Update = "update courses set Name=@Name, Duration_course=@Duration_course, Price=@Price, Created_at=@Created_at, Updated_at=@Updated_at, Is_deleted=@Is_deleted where id = @id";
    public const string Delete = "delete from courses where id=@id";
}