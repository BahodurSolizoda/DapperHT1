using Dapper;
using Npgsql;

namespace Classes;

public class HackatonService:IHackatonService
{
    private readonly string ConnectionString;

    public HackatonService(string connectionString)
    {
        ConnectionString = connectionString;
    }
    
    public bool InsertHackaton(Hackaton hackaton)
    {
        using var connection = new NpgsqlConnection(ConnectionString);
        var sql="insert into hackaton (Name, Startdate, EndDate,Location) values (@Name, @Startdate, @EndDate,@Location;)";
        var id=connection.ExecuteScalar<int>(sql, hackaton);
        return id > 0;
    }

    public bool UpdateHackaton(Hackaton hackaton)
    {
        using var connection = new NpgsqlConnection(ConnectionString);
        var sql="Update Hackaton set  Name=@Name, Startdate=@Startdate, EndDate=@EndDate,Location=@Location where Id=@id;";
        var affected=connection.Execute(sql, hackaton);
        return affected > 0;
    }
    

    public bool DeleteHackaton(int id)
    {
        using var connection = new NpgsqlConnection(ConnectionString);
        var sql="Delete from Hackaton where Id=@id;";
        var affected=connection.Execute(sql, new {Id=id});
        return affected > 0;
    }

    public Hackaton GetHackatonById(int id)
    {
        using var connection = new NpgsqlConnection(ConnectionString);
        var sql="select * from Hackaton where Id=@id;";
        return connection.QuerySingleOrDefault<Hackaton>(sql, new {Id=id});
    }

    public List<Hackaton> GetHackatons()
    {
        using var connection = new NpgsqlConnection(ConnectionString);
        var sql="select * from Hackaton;";
        return connection.Query<Hackaton>(sql).ToList();
    }
}