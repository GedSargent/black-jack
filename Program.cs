using CardGame;

class Program
{
  static void Main()
  {
    var game = new Game();
    var deck = new Deck();

    // Shuffle the deck
    deck.Shuffle();

    // Create a new player
    var player = new Player("Ged");
    // Create a computer player
    var computer = new Player("Computer");

    // Draw 2 cards for each player
    player.InitialDraw(deck);
    computer.InitialDraw(deck);

    // Display the player's hand
    player.DisplayHand();
    // Display the computer's hand
    computer.DisplayHand();

    // Display the player's score
    player.DisplayScore();
    // Display the computer's score
    computer.DisplayScore();

    // Check if player has blackjack
    if (player.IsBlackjack())
    {
      Console.WriteLine(player.Name + " has blackjack!");
      game.isGameOver = true;
    }

    // Check if computer has blackjack
    if (computer.IsBlackjack())
    {
      Console.WriteLine(computer.Name + " has blackjack!");
      game.isGameOver = true;
    }

    // Check if player has royal blackjack
    if (player.IsRoyalBlackjack())
    {
      Console.WriteLine(player.Name + " has royal blackjack!");
      game.isGameOver = true;
    }

    // Check if computer has royal blackjack
    if (computer.IsRoyalBlackjack())
    {
      Console.WriteLine(computer.Name + " has royal blackjack!");
      game.isGameOver = true;
    }

    // Ask player if they want to twist or stick
    while (!game.isGameOver)
    {
      game.PlayerTurn(player, deck);
      // Check if player has bust
      if (game.IsBust(player))
      {
        Console.WriteLine(player.Name + " is bust!");
        game.isGameOver = true;
      }

      // Check if player has blackjack
      if (player.IsBlackjack())
      {
        Console.WriteLine(player.Name + " has blackjack!");
        game.isGameOver = true;
      }

      // Check if player has royal blackjack
      if (player.IsRoyalBlackjack())
      {
        Console.WriteLine(player.Name + " has royal blackjack!");
        game.isGameOver = true;
      }

      // Check if player has five card trick
      if (player.IsFiveCardTrick())
      {
        Console.WriteLine(player.Name + " has a five card trick!");
        game.isGameOver = true;
      }

      // Computer's turn
      if (!game.isGameOver)
      {
        game.PlayerTurn(computer, deck);
        // Check if computer has bust
        if (game.IsBust(computer))
        {
          Console.WriteLine(computer.Name + " is bust!");
          game.isGameOver = true;
        }

        // Check if computer has blackjack
        if (computer.IsBlackjack())
        {
          Console.WriteLine(computer.Name + " has blackjack!");
          game.isGameOver = true;
        }

        // Check if computer has royal blackjack
        if (computer.IsRoyalBlackjack())
        {
          Console.WriteLine(computer.Name + " has royal blackjack!");
          game.isGameOver = true;
        }

        // Check if computer has five card trick
        if (computer.IsFiveCardTrick())
        {
          Console.WriteLine(computer.Name + " has a five card trick!");
          game.isGameOver = true;
        }
      }
    }
  }
}

class Game {
  // Set maximum score to 21
  public bool isGameOver = false;
  private const int maxScore = 21;
  private bool hasFinishedTurn = false;

  public int GetPlayerScore(Player player) {
    return player.CalculateScore();
  }

  // Calculate if player has bust
  public bool IsBust(Player player) {
    return GetPlayerScore(player) > maxScore;
  }

  // Ask player if they want to twist or stick
  public void PlayerTurn(Player player, Deck deck) {
    Console.WriteLine(player.Name + ", do you want to twist or stick? (t/s)");
    string choice = Console.ReadLine();

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
    }
    else if (choice == "s")
    {
      Console.WriteLine(player.Name + " sticks.");
      hasFinishedTurn = true;
    }
  }
}
