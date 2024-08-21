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
    public void TakeTurn(Player player, Deck deck, Player opponent) {
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

        CheckGameStatus(player, deck, opponent);
      }
      else if (choice == "s")
      {
        Console.WriteLine(player.Name + " sticks.");
        Console.WriteLine("--------------------------");
        player.isCurrentlyPlaying = false;

        CheckGameStatus(player, deck, opponent);

        return;
      }
    }

    public void CheckGameStatus(Player player, Deck deck, Player opponent) {
      if (IsBust(player))
      {
        isOver = true;
        player.hasLost = true;
        opponent.hasWon = true;
        player.isCurrentlyPlaying = false;

        return;
      }

      if (player.HasFiveCardTrick())
      {
        Console.WriteLine(player.Name + " has a five card trick!");
      }

      if (player.isCurrentlyPlaying)
      {
        TakeTurn(player, deck, opponent);
      }
    }

    public void CheckFinalWinner(Player player, Player opponent) {
      if (IsBust(player)) {
        player.hasLost = true;
        opponent.hasWon = true;
        Console.WriteLine(player.Name + " is bust!");
        Console.WriteLine(opponent.Name + " has won!");
        isOver = true;

        return;
      };

      if (IsBust(opponent)) {
        opponent.hasLost = true;
        player.hasWon = true;
        Console.WriteLine(opponent.Name + " is bust!");
        Console.WriteLine(player.Name + " has won!");
        isOver = true;

        return;
      };

      bool isPlayerWinner = player.hasWon = GetPlayerScore(player) > GetPlayerScore(opponent);
      bool isDraw = GetPlayerScore(player) == GetPlayerScore(opponent);

      if (isDraw)
      {
        Console.WriteLine("It's a draw!");
        player.hasWon = true;
        opponent.hasWon = true;
        isOver = true;
      }
      else

      if (isPlayerWinner)
      {
        player.hasWon = true;
        opponent.hasLost = true;
        Console.WriteLine(player.Name + " wins!");
        isOver = true;
      }
      else
      {
        opponent.hasWon = true;
        player.hasLost = true;
        Console.WriteLine(opponent.Name + " wins!");
        isOver = true;
      }
    }
  }
}
