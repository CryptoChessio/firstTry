using UnityEngine;
using System;
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

    public override SpecialMove GetSpecialMove(
        ref ChessPiece[,] board,
        ref List<Vector2Int[]> movesList,
        ref List<Vector2Int> avalMoves)
    {
        int direction = (team == 0) ? 1 : -1;

        // Queening
        if ((team == 0 && currY == 6) || (team == 1 && currY == 1))
        {
            return SpecialMove.Promotion;
        }
        //En Passant
        if (movesList.Count > 0)
        {
            Vector2Int[] lastMove = movesList[movesList.Count - 1];

            Debug.Log("Checking En Passant");


            if (board[lastMove[1].x, lastMove[1].y].type == ChessPieceType.Pawn) //if the last piece was a pawn
            {
                Debug.Log("Last piece was a pawn");
                if (Mathf.Abs(lastMove[0].y - lastMove[1].y) == 2)   //if the last move wwas postive in either direction
                {
                    Debug.Log("Last move was positive");
                    if (board[lastMove[1].x, lastMove[1].y].team != team) //if the move was from a diffrent team
                    {
                        Debug.Log("Last move was from diffrent team");
                        if (lastMove[1].y == currY) //if both pawn are on same y
                        {
                            Debug.Log("Both pawns on same y");
                            if (lastMove[1].x == currX - 1) // Landed left
                            {
                                Debug.Log("Landed left");
                                avalMoves.Add(new Vector2Int(currX - 1, currY + direction));
                                return SpecialMove.EnPassant;
                            }
                            if (lastMove[1].x == currX + 1) // Landed right
                            {
                                Debug.Log("Landed right");
                                avalMoves.Add(new Vector2Int(currX + 1, currY + direction));
                                return SpecialMove.EnPassant;
                            }
                        }
                    }
                }
            }
        }
        return SpecialMove.None;
    }

}