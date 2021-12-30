using UnityEngine;
using System.Collections.Generic;

public class Knight : ChessPiece
{


    public override List<Vector2Int> GetAvalMoves(
        ref ChessPiece[,] board,
        int tileCountX,
        int tileCountY)
    {
        List<Vector2Int> moves = new List<Vector2Int>();

        // Top Right

        int x = currX + 1;
        int y = currY + 2;
        if (x < tileCountX && y < tileCountY) //inside bounds
        {
            if (board[x, y] == null || board[x, y].team != team)
            {
                moves.Add(new Vector2Int(x, y));
            }
        }

        x = currX + 2;
        y = currY + 1;
        if (x < tileCountX && y < tileCountY) //inside bounds
        {
            if (board[x, y] == null || board[x, y].team != team)
            {
                moves.Add(new Vector2Int(x, y));
            }
        }

        // Top Left
        x = currX - 1;
        y = currY + 2;
        if (x >= 0 && y < tileCountY) //inside bounds
        {
            if (board[x, y] == null || board[x, y].team != team)
            {
                moves.Add(new Vector2Int(x, y));
            }
        }

        x = currX - 2;
        y = currY + 1;
        if (x >= 0 && y < tileCountY) //inside bounds
        {
            if (board[x, y] == null || board[x, y].team != team)
            {
                moves.Add(new Vector2Int(x, y));
            }
        }

        // Bottom Right
        x = currX + 1;
        y = currY - 2;
        if (x < tileCountX && y >= 0) //inside bounds
        {
            if (board[x, y] == null || board[x, y].team != team)
            {
                moves.Add(new Vector2Int(x, y));
            }
        }

        x = currX + 2;
        y = currY - 1;
        if (x < tileCountX && y >= 0) //inside bounds
        {
            if (board[x, y] == null || board[x, y].team != team)
            {
                moves.Add(new Vector2Int(x, y));
            }
        }

        // Bottom Left
        x = currX - 1;
        y = currY - 2;
        if (x >= 0 && y >= 0) //inside bounds
        {
            if (board[x, y] == null || board[x, y].team != team)
            {
                moves.Add(new Vector2Int(x, y));
            }
        }

        x = currX - 2;
        y = currY - 1;
        if (x >= 0 && y >= 0) //inside bounds
        {
            if (board[x, y] == null || board[x, y].team != team)
            {
                moves.Add(new Vector2Int(x, y));
            }
        }
        return moves;

    }


}