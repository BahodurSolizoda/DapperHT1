using Dapper;
using Classes;
using Npgsql;

var connectionString="Server=127.0.0.1;Port=5432;Database=StudentsDB;User Id=postgres;Password=7070;";
IHackatonService hackatonService = new HackatonService(connectionString);

Console.WriteLine("CRUD Operations on Hackaton Table\n");

Console.WriteLine("Inserting Hackaton ---> ");
var newhackaton = new Hackaton();
{
    var Name = "SoftClub Hackaton 2024";
    var StartTime = DateTime.Now;
    var EndTime = DateTime.Now.AddDays(1);
    var location = "SoftClub Academy";
}

var isInserted = hackatonService.InsertHackaton(newhackaton);

var firstHackaton = hackatonService.GetHackatonById(1);
Console.WriteLine($@"""
            Name = {firstHackaton.Name},
            Start Date = {firstHackaton.StartTime},
            End Date = {firstHackaton.EndTime},
            Location = {firstHackaton.Location}
        """);
Console.WriteLine(new String('-', 20));


Console.WriteLine("Updating Hackaton ---> ");
firstHackaton.Location = "Alif Academy";
var updateHackaton = hackatonService.UpdateHackaton(firstHackaton);
Console.WriteLine($"Updated = {updateHackaton}");
var updatedHackaton = hackatonService.GetHackatonById(1);
Console.WriteLine($@"""
            Name = {updatedHackaton.Name},
            Start Date = {updatedHackaton.StartTime},
            End Date = {updatedHackaton.EndTime},
            Location = {updatedHackaton.Location}
        """);
Console.WriteLine(new String('-', 20));


Console.WriteLine("Deleting Hackaton ---> ");
var deleteHackaton=hackatonService.DeleteHackaton(firstHackaton.Id);
Console.WriteLine($"Deleted = {deleteHackaton}");
Console.WriteLine(new String('-', 20));
