using CardGame;

class Program
{
  static void Main()
  {
    var game = new Game();
    var deck = new Deck();
    deck.Shuffle();

    var player = new Player("Ged");
    var computer = new Player("Computer");

    // Deal cards to player and computer
    game.DealCards(player, deck, game);
    game.DealCards(computer, deck, game);
    game.CheckForEarlyWin(player, game);
    game.CheckForEarlyWin(computer, game);

    // Player's turn
    while (!game.isOver || player.isCurrentlyPlaying)
    {
      game.PlayerTurn(player, deck);
    }

    // Computer's turn
    while (!game.isOver || computer.isCurrentlyPlaying)
    {
      game.PlayerTurn(computer, deck);
    }

    // Determine winner
    if (player.hasWon)
    {
      Console.WriteLine(player.Name + " wins!");
    }
    else if (computer.hasWon)
    {
      Console.WriteLine(computer.Name + " wins!");
    }
    else
    {
      Console.WriteLine("It's a draw!");
    }

    // Ask player if they want to play again. If they do, reset the game
    Console.WriteLine("Do you want to play again? (y/n)");
    string? playAgain = Console.ReadLine();

    while (playAgain != "y" && playAgain != "n")
    {
      Console.WriteLine("Invalid input. Please enter 'y' to play again or 'n' to exit.");
      playAgain = Console.ReadLine();
    }

    if (playAgain == "y")
    {
      game.ResetGame(player, computer, deck, game);
    } else if (playAgain == "n")
    {
      Console.WriteLine("Thanks for playing!");

      // Exit the game
      Environment.Exit(0);
    }
  }
}
