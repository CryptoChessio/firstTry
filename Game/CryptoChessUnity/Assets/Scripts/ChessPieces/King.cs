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

    public override SpecialMove GetSpecialMove(
        ref ChessPiece[,] board,
        ref List<Vector2Int[]> movesList,
        ref List<Vector2Int> avalMoves)
    {
        SpecialMove m = SpecialMove.None;

        var KingMove = movesList.Find(t => t[0].x == 4 && t[0].y == ((team == 0) ? 0 : 7)); //Look at King's position
        var leftRook = movesList.Find(t => t[0].x == 0 && t[0].y == ((team == 0) ? 0 : 7)); // Look at left rook's position
        var rightRook = movesList.Find(t => t[0].x == 7 && t[0].y == ((team == 0) ? 0 : 7)); //Look at Right rook's position

        if (KingMove == null && currX == 4)
        {
            if (team == 0)
            {
                // Left rook
                if (leftRook == null)
                {
                    if (board[0, 0].type == ChessPieceType.Rook)
                    {
                        if (board[0, 0].team == 0)
                        {
                            if (board[3, 0] == null)
                            {
                                if (board[2, 0] == null)
                                {
                                    if (board[1, 0] == null)
                                    {
                                        //no obstructions
                                        avalMoves.Add(new Vector2Int(2, 0));
                                        m = SpecialMove.Castling;
                                    }
                                }
                            }
                        }
                    }

                }

                // Right
                if (rightRook == null)
                {
                    if (board[7, 0].type == ChessPieceType.Rook)
                    {
                        if (board[7, 0].team == 0)
                        {
                            if (board[5, 0] == null)
                            {
                                if (board[6, 0] == null)
                                {
                                    //no obstructions
                                    avalMoves.Add(new Vector2Int(6, 0));
                                    m = SpecialMove.Castling;
                                }
                            }
                        }
                    }

                }
            }
            else
            {
                // Right rook
                if (leftRook == null)
                {
                    if (board[0, 7].type == ChessPieceType.Rook)
                    {
                        if (board[0, 7].team == 1)
                        {
                            if (board[3, 7] == null)
                            {
                                if (board[2, 7] == null)
                                {
                                    if (board[1, 7] == null)
                                    {
                                        //no obstructions
                                        avalMoves.Add(new Vector2Int(2, 7));
                                        m = SpecialMove.Castling;
                                    }
                                }
                            }
                        }
                    }

                }

                // Left Right
                if (rightRook == null)
                {
                    if (board[7, 7].type == ChessPieceType.Rook)
                    {
                        if (board[7, 7].team == 1)
                        {
                            if (board[5, 7] == null)
                            {
                                if (board[6, 7] == null)
                                {
                                    //no obstructions
                                    avalMoves.Add(new Vector2Int(6, 7));
                                    m = SpecialMove.Castling;
                                }
                            }
                        }
                    }

                }
            }
        }
        return m;
    }
}