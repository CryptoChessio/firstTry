using UnityEngine;
using System.Collections.Generic;

public class King : ChessPiece
{


    public override List<Vector2Int> GetAvalMoves(
       ref ChessPiece[,] board,
       int tileCountX,
       int tileCountY)
    {
        List<Vector2Int> moves = new List<Vector2Int>();

        //Right
        if (currX + 1 < tileCountX)
        {
            if (board[currX + 1, currY] == null)
            {
                moves.Add(new Vector2Int(currX + 1, currY));
            }
            else if (board[currX + 1, currY].team != team)
            {
                moves.Add(new Vector2Int(currX + 1, currY));
            }

            //top right
            if (currY + 1 < tileCountY)
            {
                if (board[currX + 1, currY + 1] == null)
                {
                    moves.Add(new Vector2Int(currX + 1, currY + 1));
                }
                else if (board[currX + 1, currY + 1].team != team)
                {
                    moves.Add(new Vector2Int(currX + 1, currY + 1));
                }
            }

            //bottom right
            if (currY - 1 >= 0)
            {
                if (board[currX + 1, currY - 1] == null)
                {
                    moves.Add(new Vector2Int(currX + 1, currY - 1));
                }
                else if (board[currX + 1, currY - 1].team != team)
                {
                    moves.Add(new Vector2Int(currX + 1, currY - 1));
                }
            }
        }

        //Left
        if (currX - 1 >= 0)
        {
            if (board[currX - 1, currY] == null)
            {
                moves.Add(new Vector2Int(currX - 1, currY));
            }
            else if (board[currX - 1, currY].team != team)
            {
                moves.Add(new Vector2Int(currX - 1, currY));
            }

            //top left
            if (currY + 1 < tileCountY)
            {
                if (board[currX - 1, currY + 1] == null)
                {
                    moves.Add(new Vector2Int(currX - 1, currY + 1));
                }
                else if (board[currX - 1, currY + 1].team != team)
                {
                    moves.Add(new Vector2Int(currX - 1, currY + 1));
                }
            }

            //bottom left
            if (currY - 1 >= 0)
            {
                if (board[currX - 1, currY - 1] == null)
                {
                    moves.Add(new Vector2Int(currX - 1, currY - 1));
                }
                else if (board[currX - 1, currY - 1].team != team)
                {
                    moves.Add(new Vector2Int(currX - 1, currY - 1));
                }
            }
        }

        //Up
        if (currY + 1 < tileCountY)
        {
            if (board[currX, currY + 1] == null ||
                board[currX, currY + 1].team != team)
            {
                moves.Add(new Vector2Int(currX, currY + 1));
            }
        }

        //Down
        if (currY - 1 >= 0)
        {
            if (board[currX, currY - 1] == null ||
                board[currX, currY - 1].team != team)
            {
                moves.Add(new Vector2Int(currX, currY - 1));
            }
        }
        return moves;

    }


}