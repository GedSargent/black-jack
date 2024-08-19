namespace CardGame
{
  public class Card
  {
    public Suit Suit { get; set; }
    public Value Value { get; set; }
    public Card(Suit suit, Value value)
    {
      Suit = suit;
      Value = value;
    }
    public override string ToString()
    {
      return Value + " of " + Suit;
    }

    public int GetScore()
    {
      return cardValueScores[Value];
    }

    private Dictionary<Value, int> cardValueScores = new Dictionary<Value, int>()
    {
      { Value.Two, 2 },
      { Value.Three, 3 },
      { Value.Four, 4 },
      { Value.Five, 5 },
      { Value.Six, 6 },
      { Value.Seven, 7 },
      { Value.Eight, 8 },
      { Value.Nine, 9 },
      { Value.Ten, 10 },
      { Value.Jack, 10 },
      { Value.Queen, 10 },
      { Value.King, 10 },
      { Value.Ace, 11 },
    };
  }

  public enum Suit
  {
    Clubs,
    Diamonds,
    Hearts,
    Spades
  }

  public enum Value
  {
    Ace,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King
  }
}
