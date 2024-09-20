using Client.Model;
using Dapper;
using Npgsql;

namespace Client.Service.MentorGroupService;

public class MentorGroupService : IMentorGroupService
{
    public async Task<IEnumerable<MentorGroup>> GetAll()
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.QueryAsync<MentorGroup>(SqlCommands.GetAll);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<MentorGroup?> GetById(int id)
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.QueryFirstOrDefaultAsync<MentorGroup>(SqlCommands.GetById,new{Id = id});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> CreateAsync(MentorGroup mentorGroup)
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.ExecuteAsync(SqlCommands.Create,mentorGroup)>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateAsync(MentorGroup mentorGroup)
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.ExecuteAsync(SqlCommands.Update,mentorGroup)>0;
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
    public const string GetAll = "select * from mentor_group";
    public const string GetById = "select * from mentor_group where id=@id";
    public const string Create = "insert into mentor_group(id,Teacher_id,Group_id) values(@id,@Teacher_id,@Group_id)";
    public const string Update = "update mentor_group set Teacher_id=@Teacher_id, Group_id=@Group_id where id = @id";
    public const string Delete = "delete from mentor_group where id=@id";
}