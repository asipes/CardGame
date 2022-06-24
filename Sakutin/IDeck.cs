using System.Collections.Generic;

namespace Sakutin
{
    public interface IDeck
    {
        void Shuffle();

        List<ICard> RetrieveCards(int count);

        int Size();
    }
}