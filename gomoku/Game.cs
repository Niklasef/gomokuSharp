namespace Gomoku;

public readonly record struct Game {
    public Board Board { get; }
    public Stone Turn { get; }

    internal Game(Board board, Stone turn) => (Board, Turn) = (board, turn);
}

public static class Games {
    public static Game Create() => new(Boards.Create(), Stone.Black);
}
