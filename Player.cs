namespace CardGame
{
  class Player
  {
    public string Name { get; set; }
    public List<Card> Hand;

    public Player(string name)
    {
      Name = name ?? throw new ArgumentNullException(nameof(name));
      Hand = new List<Card>() ?? throw new ArgumentNullException(nameof(Hand));
    }

    public void InitialDraw(Deck deck)
    {
      Hand.Add(deck.Draw());
      Hand.Add(deck.Draw());
    }

    public void Draw(Deck deck)
    {
      Hand.Add(deck.Draw());
    }

    public int CalculateScore()
    {
      int score = 0;
      int aces = 0;

      foreach (var card in Hand)
      {
        score += card.GetScore();
        if (card.Value == Value.Ace)
        {
          aces++;
        }
      }

      while (score > 21 && aces > 0)
      {
        score -= 10;
        aces--;
      }

      return score;
    }

    // Calculate if player has bust
    public bool IsBust()
    {
      int score = CalculateScore();
      bool isBust = score > 21;

      if (isBust)
          {
            // Check if player has an ace
            foreach (Card card in Hand)
            {
              if (card.Value == Value.Ace)
              {
                // Change the value of the ace from 11 to 1
                score -= 10;
              }
              // Check if player is still bust
              isBust = score <= 21;
              return isBust;
            }
          }

      return isBust;
    }

    // Calculate if player has blackjack with only two cards
    public bool IsBlackjack()
    {
      return CalculateScore() == 21 && Hand.Count == 2;
    }
    public bool IsRoyalBlackjack()
    {
      bool hasAce = Hand.Any(c => c.Value == Value.Ace);
      bool hasRoyal = Hand.Any(c => c.Value == Value.King || c.Value == Value.Queen || c.Value == Value.Jack);

      return Hand.Count == 2 && hasAce && hasRoyal;
    }

    public bool IsFiveCardTrick()
    {
      return Hand.Count == 5 && CalculateScore() <= 21;
    }

    public void DisplayHand()
    {
      Console.WriteLine(Name + "'s hand:");
      foreach (Card card in Hand)
      {
        Console.WriteLine(card);
      }
      Console.WriteLine("--------------------------");
    }

    public void DisplayScore()
    {
      Console.WriteLine(Name + "'s score: " + CalculateScore());
      Console.WriteLine("--------------------------");
    }

    public void Hit(Deck deck)
    {
      Hand.Add(deck.Draw());
      // Calculate new score
      int score = CalculateScore();
      // Display new score
      Console.WriteLine(Name + " drew " + Hand.Last());
      Console.WriteLine(Name + "'s new score: " + score);
    }
  }
}
