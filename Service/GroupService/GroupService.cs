using Client.Model;
using Dapper;
using Npgsql;

namespace Client.Service.GroupService;

public class GroupService : IGroupService
{
    public async Task<IEnumerable<Group>> GetAll()
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.QueryAsync<Group>(SqlCommands.GetAll);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Group?> GetById(int id)
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.QueryFirstOrDefaultAsync<Group>(SqlCommands.GetById,new{Id = id});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> CreateAsync(Group group)
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.ExecuteAsync(SqlCommands.Create,group)>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateAsync(Group group)
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.ExecuteAsync(SqlCommands.Update,group)>0;
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
    public const string GetAll = "select * from groups";
    public const string GetById = "select * from groups where id=@id";
    public const string Create = "insert into groups(id,Name,Course_id,Max_students,Min_students,Created_at,Updated_at,Is_deleted) values(@id,@Name,@Course_id,@Max_students,@Min_students,@Created_at,@Updated_at,@Is_deleted)";
    public const string Update = "update groups set Name=@Name, Course_id=@Course_id, Max_students=@Max_students, Min_students=@Min_students, Created_at=@Created_at, Updated_at=@Updated_at, Is_deleted=@Is_deleted where id = @id";
    public const string Delete = "delete from groups where id=@id";
}