using UnityEngine;
using System.Collections.Generic;
public class Rook : ChessPiece
{
    public override List<Vector2Int> GetAvalMoves(
       ref ChessPiece[,] board,
       int tileCountX,
       int tileCountY)
    {
        List<Vector2Int> moves = new List<Vector2Int>();

        //Down
        for (int i = currY - 1; i >= 0; i--)
        { // if these is no pieces
            if (board[currX, i] == null)
            {
                moves.Add(new Vector2Int(currX, i));
            }
            if (board[currX, i] != null)
            {  //if there is a piece
                if (board[currX, i].team != team)
                {
                    moves.Add(new Vector2Int(currX, i));
                }
                break;
            }
        }

        //Up
        for (int i = currY + 1; i < tileCountY; i++)
        { // if these is no pieces
            if (board[currX, i] == null)
            {
                moves.Add(new Vector2Int(currX, i));
            }
            if (board[currX, i] != null)
            {  //if there is a piece
                if (board[currX, i].team != team)
                {
                    moves.Add(new Vector2Int(currX, i));
                }
                break;
            }
        }

        //Left
        for (int i = currX - 1; i >= 0; i--)
        { // if these is no pieces
            if (board[i, currY] == null)
            {
                moves.Add(new Vector2Int(i, currY));
            }
            if (board[i, currY] != null)
            {  //if there is a piece
                if (board[i, currY].team != team)
                {
                    moves.Add(new Vector2Int(i, currY));
                }
                break;
            }
        }

        //Right
        for (int i = currX + 1; i < tileCountX; i++)
        { // if these is no pieces
            if (board[i, currY] == null)
            {
                moves.Add(new Vector2Int(i, currY));
            }
            if (board[i, currY] != null)
            {  //if there is a piece
                if (board[i, currY].team != team)
                {
                    moves.Add(new Vector2Int(i, currY));
                }
                break;
            }
        }

        return moves;

    }


}