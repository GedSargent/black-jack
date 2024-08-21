using CardGame;

class Program
{
  static void Main()
  {
    string? playAgain = "y";

    while (playAgain == "y")
    {
      PlayGame();
    }

    Console.WriteLine("Thanks for playing!");

    // Exit the game
    Environment.Exit(0);

    // ------------------------------------------------------------

    void PlayGame() {
      (Game game, Deck deck, Player player, Player opponent) SetupNewGame() {
        var game = new Game();
        var deck = new Deck();
        deck.Shuffle();

        var player = new Player("Player 1");
        var opponent = new Player("Player 2");

        return (game, deck, player, opponent);
      }

      var (game, deck, player, opponent) = SetupNewGame();

      // Deal cards to player and computer
      Console.WriteLine("--------------------");
      Console.WriteLine("Welcome to Blackjack!");
      Console.WriteLine("Dealing cards...");
      Console.WriteLine("");
      game.DealCards(player, deck, game);
      game.DealCards(opponent, deck, game);
      game.CheckForEarlyWin(player, game);
      game.CheckForEarlyWin(opponent, game);

      // Player's turn
      while (!game.isOver && !player.hasLost && player.isCurrentlyPlaying)
      {
        game.TakeTurn(player, deck, opponent);
      }

      // Check if player has lost early
      if (player.hasLost)
      {
        opponent.hasWon = true;
        opponent.isCurrentlyPlaying = false;
        game.isOver = true;
      }

      // Computer's turn
      while (!game.isOver && !opponent.hasLost && opponent.isCurrentlyPlaying)
      {
        game.TakeTurn(opponent, deck, player);
      }

      // Determine winner
      game.CheckFinalWinner(player, opponent);

      // Ask player if they want to play again. If they do, reset the game
      Console.WriteLine("Do you want to play again? (y/n)");
      playAgain = Console.ReadLine();

      while (playAgain != "y" && playAgain != "n")
      {
        Console.WriteLine("Invalid input. Please enter 'y' to play again or 'n' to exit.");
        playAgain = Console.ReadLine();
      }

      if (playAgain == "y")
      {
        PlayGame();
      } else if (playAgain == "n")
      {
        return;
      }
    }
  }
}
