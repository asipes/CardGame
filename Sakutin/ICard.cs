namespace Sakutin
{
    public interface ICard
    {
        int GetValueAsNumber();

        int GetTypeAsNumber();

        CardType GetType();
    }
}