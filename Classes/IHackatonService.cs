namespace Classes;

public interface IHackatonService
{
    bool InsertHackaton(Hackaton hackaton);
    bool UpdateHackaton(Hackaton hackaton);
    bool DeleteHackaton(int id);
    Hackaton GetHackatonById(int id);
    List<Hackaton> GetHackatons();
}