namespace Gomoku;

public readonly record struct Game {
    public Board Board { get; }
    public Stone Turn { get; }

    internal Game(Board board, Stone turn) => (Board, Turn) = (board, turn);
}

public static class Games {
    public static Game Create() => new(Boards.Create(), Stone.Black);

    public static Game PlayMove(Game game, Move move) {
        if (!Moves.IsValid(game, move)) {
            throw new InvalidOperationException(
                $"Move ({move.X}, {move.Y}) by {move.Stone} is not legal in the current game state (wrong turn, out of bounds, or occupied tile).");
        }

        return new Game(
            Boards.PlaceStone(game.Board, move.X, move.Y, move.Stone),
            Stones.Opponent(game.Turn));
    }
}
