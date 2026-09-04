namespace Gomoku;

public readonly record struct Move {
    public Stone Stone { get; }
    public int X { get; }
    public int Y { get; }

    public Move(Stone stone, int x, int y) {
        Stone = stone;
        X = x;
        Y = y;
    }
}

public static class Moves {
    public static bool IsValid(Game game, Move move) =>
        move.Stone == game.Turn
        && Boards.IsInBounds(move.X, move.Y)
        && Tiles.IsEmpty(Boards.GetTile(game.Board, move.X, move.Y));

    public static Move Create(Game game, int x, int y) {
        if (!Boards.IsInBounds(x, y)) {
            throw new ArgumentOutOfRangeException(nameof(x),
                $"Coordinates ({x}, {y}) are outside the 0..{Board.Size - 1} range.");
        }

        if (!Tiles.IsEmpty(Boards.GetTile(game.Board, x, y))) {
            throw new InvalidOperationException($"Tile ({x}, {y}) is already occupied.");
        }

        return new Move(game.Turn, x, y);
    }
}
