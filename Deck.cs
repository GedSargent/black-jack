namespace CardGame
{
  public class Deck
  {
    private List<Card> cards;
    public Deck()
    {
        cards = CreateDeck();
    }
    public List<Card> Cards => cards; // Public property to expose the cards field

    public List<Card> CreateDeck()
    {
        cards = new List<Card>();
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                cards.Add(new Card((Suit)i, (Value)j));
            }
        }

        return cards;
    }

    public void Shuffle()
    {
        List<Card> shuffled = new List<Card>();
        Random rand = new Random();
        while (cards.Count > 0)
        {
            int index = rand.Next(cards.Count);
            shuffled.Add(cards[index]);
            cards.RemoveAt(index);
        }
        cards = shuffled;
    }
    public Card Draw()
    {
        Card card = cards[0];
        cards.RemoveAt(0);
        return card;
    }
  }
}
