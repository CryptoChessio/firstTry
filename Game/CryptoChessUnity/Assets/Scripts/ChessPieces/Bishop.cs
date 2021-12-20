using UnityEngine;
using System.Collections.Generic;

public class Bishop : ChessPiece
{
    public override List<Vector2Int> GetAvalMoves(
        ref ChessPiece[,] board,
        int tileCountX,
        int tileCountY)
    {
        List<Vector2Int> moves = new List<Vector2Int>();

        //Top right
        for (int i = currX + 1, j = currY + 1; i < tileCountX && j < tileCountY; i++, j++) //double for loop
        { // if these is no pieces
            if (board[i, j] == null)
            {
                moves.Add(new Vector2Int(i, j));
            }
            if (board[i, j] != null)
            {  //if there is a piece
                if (board[i, j].team != team)
                {
                    moves.Add(new Vector2Int(i, j));
                }
                break;
            }
        }

        //Top left
        for (int i = currX - 1, j = currY + 1; i >= 0 && j < tileCountY; i--, j++) //double for loop
        { // if these is no pieces
            if (board[i, j] == null)
            {
                moves.Add(new Vector2Int(i, j));
            }
            if (board[i, j] != null)
            {  //if there is a piece
                if (board[i, j].team != team)
                {
                    moves.Add(new Vector2Int(i, j));
                }
                break;
            }
        }

        //Bottom right
        for (int i = currX + 1, j = currY - 1; i < tileCountX && j >= 0; i++, j--) //double for loop
        { // if these is no pieces
            if (board[i, j] == null)
            {
                moves.Add(new Vector2Int(i, j));
            }
            if (board[i, j] != null)
            {  //if there is a piece
                if (board[i, j].team != team)
                {
                    moves.Add(new Vector2Int(i, j));
                }
                break;
            }
        }

        //Bottom left

        for (int i = currX - 1, j = currY - 1; i >= 0 && j >= 0; i--, j--) //double for loop
        { // if these is no pieces
            if (board[i, j] == null)
            {
                moves.Add(new Vector2Int(i, j));
            }
            if (board[i, j] != null)
            {  //if there is a piece
                if (board[i, j].team != team)
                {
                    moves.Add(new Vector2Int(i, j));
                }
                break;
            }
        }



        return moves;

    }


}