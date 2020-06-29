// ----------------------------------------------------------------------
// <copyright file="Program.cs" company="Machuga / MatthewC">
// No Copyright; Intended for instructional purposes only.
// </copyright>
// ----------------------------------------------------------------------

/*  This implementation of Tic Tac Toe is intended to demonstrate a
 *  possible version of the game, using a heavily imperative styled
 *  solution.
 *
 *  No custom types, nor significantly advanced C# language features
 *  are intended to be used in this implementation; therefore,
 *  much of this code overall should be fairly easily
 *  convertible to other languages and other contexts.
 *
 * Written 2020.06.29 as a demo for a friend I was instructing
 * some basics to C# to get a better handle on a wider
 * range of programming languages.
 *
 * This should feel more like a C or assembly program, and less like a
 * C# program.
 * */

namespace TicTacToe_Imperative
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Text.RegularExpressions;

  /// <summary>
  /// <see cref="Program"/> class containing the <see cref="Main(string[])"/> entrypoin.
  /// </summary>
  public class Program
  {
    //---------------------------------------------
    // Readonly values
    //---------------------------------------------

    /// <summary>
    /// Stores the character representation for the
    /// Player 1 value in the board.
    /// </summary>
    private static readonly char P1Char = 'X';

    /// <summary>
    /// Stores the character representation for the
    /// Player 2 value in the board.
    /// </summary>
    private static readonly char P2Char = 'O';

    /// <summary>
    /// Stores the representation of the empty character.
    /// </summary>
    private static readonly char EmptyChar = '\0';

    /// <summary>
    /// Stores the representation of a tie character.
    /// </summary>
    private static readonly char TieChar = 'T';

    /// <summary>
    /// Stores the regex to use when taking user input.
    /// Uses some moderately complex Discrete Math II concepts to allow either:
    /// A Pair (Row, Col)
    /// or a singleton, representing Cell #.
    /// </summary>
    private static readonly Regex InputRegex = new Regex(
      @"(?'Pair'(?'Row'[\d]+)(?'Filler'[^\d]+)(?'Col'[\d]+))|(?'Singleton'([\d]+))",
      RegexOptions.Compiled);

    //---------------------------------------------
    // Configuration settings
    //---------------------------------------------

    /// <summary>
    /// Stores whether Player 2 is computer.
    /// Initially set to false, can be overridden either via command line
    /// arg, or by setting ingame, when starting.
    /// </summary>
    private static bool p2IsComputer = false;

    /// <summary>
    /// Stores the board width.
    /// </summary>
    private static int bWidth = 3;

    /// <summary>
    /// Stores the board height.
    /// </summary>
    private static int bHeight = 3;

    //---------------------------------------------
    // Runtime variables
    //---------------------------------------------

    /// <summary>
    /// Stores the board state.
    /// </summary>
    private static char[,] board;

    /// <summary>
    /// Stores the accumulated player 1 score.
    /// </summary>
    private static int p1Score = 0;

    /// <summary>
    /// Stores the accumulated player 2 score.
    /// </summary>
    private static int p2Score = 0;

    /// <summary>
    /// Stores whether player 1 is first.
    /// </summary>
    private static bool p1First = false;

    /// <summary>
    /// Stores the random number generator (to decide whether p1 goes first this current game at start,
    /// and, if the computer is activated, to pick the computer's turn.
    /// Computer is fully random, and does not pick intelligently.
    /// </summary>
    private static Random generator = new Random();

    /// <summary>
    /// Stores the current game #.
    /// </summary>
    private static int gameNumber = 0;

    /// <summary>
    /// Main entrypoint for the program; Initializes configuration variables, and runs the game.
    /// </summary>
    /// <param name="args">The optional command-line arguments to run with to customize behavior.</param>
    public static void Main(string[] args)
    {
      HandleCommandLineArgs(args);
      p1First = generator.Next() % 2 == 0;
      board = new char[bHeight, bWidth];
      ResetBoard();
      PlayGames();
      Console.WriteLine();
      Console.WriteLine("Press any key to terminate.");
      Console.ReadKey();
    }

    /// <summary>
    /// Handles parsing command line args.
    /// </summary>
    /// <param name="args">The args to handle parsing.</param>
    private static void HandleCommandLineArgs(string[] args)
    {
      // Handle deciding whether player 2 is computer.
      if (args.Contains("computer"))
      {
        p2IsComputer = true;
      }
      else
      {
        Console.WriteLine("Please enter \"YES\" if player 2 is a computer. Anthing else is assumed to be false.");
        if (Console.ReadLine().ToUpper() == "YES")
        {
          p2IsComputer = true;
        }
      }

      // Handle dimensions arg.
      if (args.Contains("dimensions"))
      {
        int index = 0;
        for (index = 0; index < args.Length; index++)
        {
          if (args[index] == "dimensions")
          {
            break; // terminate the loop; we found index of dimensions.
          }
        }

        if (args.Length < index + 3)
        {
          Console.WriteLine("Bad argument; \"dimensions\" switch provided, but not enough args to the switch. Please provide 2 integers to dimensions.");
          Console.ReadKey();
          return;
        }

        bool parseSuccess = false;
        parseSuccess = int.TryParse(args[index + 1], out bWidth);
        if (!parseSuccess)
        {
          bWidth = 3;
          Console.WriteLine("Width dimension was invalid; assuming 3.");
        }

        parseSuccess = int.TryParse(args[index + 1], out bHeight);
        if (!parseSuccess)
        {
          bHeight = 3;
          Console.WriteLine("Height dimension was invalid; assuming 3.");
        }
      }
    }

    /// <summary>
    /// Plays games. Queries user to terminate after each game.
    /// </summary>
    private static void PlayGames()
    {
      bool isDone = false;

      while (!isDone)
      {
        PlayGame();
        DrawBoard();
        ResetBoard();
        Console.WriteLine();
        Console.WriteLine("Play another game? (YES)");
        string answer = Console.ReadLine();
        if (answer.ToUpper() != "YES")
        {
          isDone = true;
        }

        try
        {
          Console.Clear();
        }
        catch (Exception ex)
        {
          // attempt to clear console; eat exception if failure.
        }
      }
    }

    /// <summary>
    /// Plays the game (asking for p1 turn, p2 turn) until victory.
    /// Prints score, and game details.
    /// </summary>
    private static void PlayGame()
    {
      Console.WriteLine("Game # {0}", ++gameNumber);
      Console.WriteLine("Score:");
      Console.WriteLine(
        "\tPlayer 1: {0}\t\tPlayer 2: {1} {2}",
        p1Score,
        p2Score,
        p2IsComputer ? "(Computer)" : string.Empty); //// Note: This line has a ternary operator. Simple inline if-else statement.

      // Invoke GetWinner() just in case to prime the pump; we loop on that.
      char winner = GetWinner();

      // Decide first player
      char player = p1First ? P1Char : P2Char;
      p1First = !p1First; // negate first player.

      while (winner == EmptyChar)
      {
        DrawBoard();
        TakeTurn(player);
        winner = GetWinner();

        if (winner == P1Char)
        {
          Console.WriteLine("Player 1 wins!");
          p1Score++;
        }
        else if (winner == P2Char)
        {
          Console.WriteLine("Player 2 wins!");
          p2Score++;
        }
        else if (winner == TieChar)
        {
          Console.WriteLine("Tie.");
        }
        else
        {
          if (player == P1Char)
          {
            player = P2Char;
          }
          else
          {
            player = P1Char;
          }
        }
      }

      Console.Beep();
    }

    /// <summary>
    /// Returns a character representing who the winner is.
    /// \0 = no winner
    /// X = Player 1
    /// O = Player 2
    /// T = Tie.
    /// Does not declare Tie early; requires full board to be set.
    ///
    /// Is not particularly clever to reduce code redundancy along dimensions; could be handled with exterior loops and sign bits.
    /// </summary>
    /// <returns>A character representing a winner, or null char, if no winner.</returns>
    private static char GetWinner()
    {
      // 1. Check rows.
      for (int row = 0; row < bHeight; row++)
      {
        char first = board[row, 0];
        bool wasWinner = true; // Assume this row was a winner, until proven otherwise.

        // early check; if first character is not a player, this row is not a winning row.
        if (first != P1Char && first != P2Char)
        {
          continue;
        }

        for (int col = 0; col < bWidth; col++)
        {
          if (board[row, col] != first)
          {
            wasWinner = false;
            break;
          }
        }

        if (wasWinner)
        {
          Console.WriteLine("Winner along row " + (row + 1));
          return first; // return who the winner was.
        }
      }

      // 2. Check columns.
      for (int col = 0; col < bHeight; col++)
      {
        char first = board[0, col];
        bool wasWinner = true; // Assume this col was a winner, until proven otherwise.

        // early check; if first character is not a player, this row is not a winning row.
        if (first != P1Char && first != P2Char)
        {
          continue;
        }

        for (int row = 0; row < bWidth; row++)
        {
          if (board[row, col] != first)
          {
            wasWinner = false;
            break;
          }
        }

        if (wasWinner)
        {
          Console.WriteLine("Winner along col " + (col + 1));
          return first; // return who the winner was.
        }
      }

      // 3. Check diagonals, IF square.
      if (bWidth == bHeight)
      {
        char first = board[0, 0];
        bool wasWinner = true; // Assume this diagonal was a winner, until proven otherwise.

        //// Top Left -> Bottom Right
        //// early check; if first character is not a player, this row is not a winning row.
        if (first == P1Char || first == P2Char)
        {
          for (int idx = 0; idx < bHeight; idx++)
          {
            if (board[idx, idx] != first)
            {
              wasWinner = false;
              break;
            }
          }

          if (wasWinner)
          {
            Console.WriteLine("Winner along Top Left -> Bottom Right Diagonal.");
            return first; // return who the winner was.
          }
        }

        //// Bottom Left -> Top Right
        first = board[bHeight - 1, 0];
        wasWinner = true;

        if (first == P1Char || first == P2Char)
        {
          for (int idx = 0; idx < bHeight; idx++)
          {
            if (board[bHeight - idx - 1, idx] != first)
            {
              wasWinner = false;
              break;
            }
          }

          if (wasWinner)
          {
            Console.WriteLine("Winner along Bottom Left -> Top Right Diagonal.");
            return first; // return who the winner was.
          }
        }
      }

      // 4. Check full board, TIE.
      bool wasTie = true; // assume we had a tie, prove there isn't one.
      for (int row = 0; row < bHeight && wasTie; row++)
      {
        for (int col = 0; col < bWidth; col++)
        {
          if (board[row, col] == EmptyChar)
          {
            wasTie = false;
            break;
          }
        }
      }

      if (wasTie)
      {
        return TieChar;
      }

      // 5. We got to this point; NULL
      return EmptyChar;
    }

    /// <summary>
    /// Takes the turn of the player specified.
    /// </summary>
    /// <param name="player">The player whose turn it is.</param>
    private static void TakeTurn(char player)
    {
      if (player == P1Char)
      {
        Console.WriteLine("Player 1, take your turn.");
      }
      else
      {
        Console.WriteLine("Player 2, take your turn.");
      }

      // 1. If Computer, and player 2, pick a square.
      if (player == P2Char && p2IsComputer)
      {
        // Look up rows which have at least 1 open cell.
        List<int> openRows = new List<int>();
        for (int row = 0; row < bHeight; row++)
        {
          for (int col = 0; col < bWidth; col++)
          {
            if (board[row, col] == EmptyChar)
            {
              openRows.Add(row);
            }
          }
        }

        // Select a random open row.
        int selectedRow = openRows[generator.Next(openRows.Count)];

        // Look up all open cells in selected row.
        List<int> openCells = new List<int>();
        for (int col = 0; col < bWidth; col++)
        {
          if (board[selectedRow, col] == EmptyChar)
          {
            openCells.Add(col);
          }
        }

        int selectedCol = openCells[generator.Next(openCells.Count)];

        Console.WriteLine(
          "Computer selected ({0}, {1}), or cell # {2}",
          selectedRow,
          selectedCol,
          PositionToOrdinalCell(selectedRow, selectedCol));

        board[selectedRow, selectedCol] = player;
      }
      else
      {
        // Human player.
        Console.WriteLine("Enter a Cell #, or \"ROW# COL#");
        bool wasInRange = false;
        int finalSelectedRow = -1;
        int finalSelectedCol = -1;

        while (!wasInRange)
        {
          // Use a Regex to validate.
          Match match = InputRegex.Match(Console.ReadLine());
          while (!match.Success)
          {
            Console.WriteLine("Invalid input. Please enter either Row # Col #, or a Cell # from left->right, top->bottom, 0 through N.");
            match = InputRegex.Match(Console.ReadLine());
          }

          if (match.Groups["Singleton"].Success)
          {
            // singleton.
            int ordinal = int.Parse(match.Groups["Singleton"].Value);

            if (ordinal < 0 || ordinal >= (bWidth * bHeight))
            {
              Console.WriteLine(
                "Selected cell ordinal was invalid. Please input {0} through {1}.",
                0,
                (bWidth * bHeight) - 1);
            }
            else
            {
              wasInRange = true;
              Tuple<int, int> val = OrdinalCellToPosition(ordinal);
              finalSelectedRow = val.Item1;
              finalSelectedCol = val.Item2;
            }
          }
          else if (match.Groups["Pair"].Success)
          {
            // pair.
            int row = int.Parse(match.Groups["Row"].Value);
            int col = int.Parse(match.Groups["Col"].Value);

            if (row < 0 || col < 0 || row >= bHeight || col >= bWidth)
            {
              Console.WriteLine(
                "Selected cell was invalid; Please constrain row to ({0}, {1}) and col to ({2}, {3}).",
                0,
                row - 1,
                0,
                col - 1);
            }
            else
            {
              wasInRange = true;
              finalSelectedRow = row;
              finalSelectedCol = col;
            }
          }

          if (wasInRange)
          {
            if (board[finalSelectedRow, finalSelectedCol] != EmptyChar)
            {
              Console.WriteLine("A player has already moved there. Pick another spot.");
              wasInRange = false;
              finalSelectedRow = -1;
              finalSelectedCol = -1;
            }
          }
        }

        board[finalSelectedRow, finalSelectedCol] = player;
      }
    }

    /// <summary>
    /// Draws the board.
    /// </summary>
    private static void DrawBoard()
    {
      StringBuilder sb = new StringBuilder();

      for (int row = 0; row < bHeight; row++)
      {
        for (int col = 0; col < bWidth; col++)
        {
          char displayChar = board[row, col];

          if (displayChar == '\0')
          {
            displayChar = '-';
          }

          sb.Append(displayChar);
        }

        sb.Append("\r\n");
      }

      if (sb.Length > 0)
      {
        sb.Remove(sb.Length - 2, 2);
      }

      Console.WriteLine(sb.ToString());
    }

    /// <summary>
    /// Resets the board.
    /// </summary>
    private static void ResetBoard()
    {
      for (int row = 0; row < bHeight; row++)
      {
        for (int col = 0; col < bWidth; col++)
        {
          board[row, col] = EmptyChar;
        }
      }
    }

    /// <summary>
    /// Converts a row/column position to an ordinal cell #.
    /// </summary>
    /// <param name="row">the row to convert.</param>
    /// <param name="col">the col to convert.</param>
    /// <returns>an int representing the position to ordinal.</returns>
    private static int PositionToOrdinalCell(int row, int col)
    {
      int ret = (((row - 1) * bWidth) * (col + 1)) - 1;
      return ret;
    }

    /// <summary>
    /// Converts a cell # to a row/col representation.
    /// </summary>
    /// <param name="cellNum">The ordinal cell #.</param>
    /// <returns>A tuple of row,height.</returns>
    private static Tuple<int, int> OrdinalCellToPosition(int cellNum)
    {
      int row = cellNum / bWidth;
      int col = cellNum % bWidth;
      return new Tuple<int, int>(row, col);
    }
  }
}