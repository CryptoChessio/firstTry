using UnityEngine;
using System.Collections.Generic;
public class Pawn : ChessPiece
{

    public override List<Vector2Int> GetAvalMoves(
        ref ChessPiece[,] board,
        int tileCountX,
        int tileCountY)
    {
        List<Vector2Int> moves = new List<Vector2Int>();

        int direction = (team == 0) ? 1 : -1;

        // one up 
        if (board[currX, currY + direction] == null)
        {
            moves.Add(new Vector2Int(currX, currY + direction));
        }

        // two up
        if (board[currX, currY + direction] == null)
        {
            //white
            if (team == 0 && currY == 1 && board[currX, currY + (direction * 2)] == null)
            {
                moves.Add(new Vector2Int(currX, currY + (direction * 2)));
            }
            //black
            else if (team == 1 && currY == 6 && board[currX, currY + (direction * 2)] == null)
            {
                moves.Add(new Vector2Int(currX, currY + (direction * 2)));
            }
            moves.Add(new Vector2Int(currX, currY + direction));
        }

        // diagonal left
        if (currX != tileCountX - 1)
        {
            if (board[currX + 1, currY + direction] != null && board[currX + 1, currY + direction].team != team)
            {
                moves.Add(new Vector2Int(currX + 1, currY + direction));
            }
        }
        if (currX != 0)
        {
            if (board[currX - 1, currY + direction] != null && board[currX - 1, currY + direction].team != team)
            {
                moves.Add(new Vector2Int(currX - 1, currY + direction));
            }
        }

        return moves;
    }

}