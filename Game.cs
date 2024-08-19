namespace CardGame
{
  class Game
  {
    public bool isOver = false;
    private const int maxScore = 21;

    public int GetPlayerScore(Player player) {
      return player.CalculateScore();
    }

    public void DealCards(Player player, Deck deck, Game game) {
      player.InitialDraw(deck);
      player.DisplayHand();
      player.DisplayScore();
    }

    public void CheckForEarlyWin(Player player, Game game) {
      player.CheckForBlackjack();
      player.CheckForRoyalBlackjack();

      if (!player.hasBlackjack || !player.hasRoyalBlackjack)
      {
        return;
      }

      if (player.hasBlackjack)
      {
        Console.WriteLine(player.Name + " has blackjack!");
        game.isOver = true;
      } else if (player.hasRoyalBlackjack)
      {
        Console.WriteLine(player.Name + " has royal blackjack!");
        game.isOver = true;
      }
    }

    // Calculate if player has bust
    public bool IsBust(Player player) {
      return GetPlayerScore(player) > maxScore;
    }

    // Ask player if they want to twist or stick
    public void PlayerTurn(Player player, Deck deck) {
      Console.WriteLine(player.Name + ", do you want to twist or stick? (t/s)");
      string? choice = Console.ReadLine();

      // If user inputs anything other than t or s, ask again until they respond with t or s
      while (choice != "t" && choice != "s")
      {
        Console.WriteLine("Invalid input. Please enter 't' to twist or 's' to stick.");
        choice = Console.ReadLine();
      }

      if (choice == "t")
      {
        player.Draw(deck);
        player.DisplayHand();
        player.DisplayScore();

        CheckPlayerStatus(player, deck);
      }
      else if (choice == "s")
      {
        Console.WriteLine(player.Name + " sticks.");
        player.isCurrentlyPlaying = false;
      }
    }

    public void CheckPlayerStatus(Player player, Deck deck) {
      if (IsBust(player))
      {
        Console.WriteLine(player.Name + " is bust!");
        isOver = true;
        player.hasLost = true;
        player.isCurrentlyPlaying = false;

        return;
      }

      if (player.HasFiveCardTrick())
      {
        Console.WriteLine(player.Name + " has a five card trick!");
      }

      PlayerTurn(player, deck);
    }

    public void ResetGame(Player player, Player computer, Deck deck, Game game) {
      player.Hand.Clear();
      computer.Hand.Clear();
      deck.Shuffle();
      game.isOver = false;
      player.isCurrentlyPlaying = true;
      computer.isCurrentlyPlaying = true;
      player.hasWon = false;
      computer.hasWon = false;
      player.hasLost = false;
      computer.hasLost = false;
      player.isBust = false;
      computer.isBust = false;
    }
  }
}
