using UnityEngine;
using System.Collections;

public enum ChessPieceType { //ul of data vals for chess pieces 
    None = 0,
    Pawn = 1,
    Rook = 2,
    Knight = 3,
    Bishop = 4,
    Queen = 5, 
    King =6
}


public class ChessPiece : MonoBehaviour {
    public int team;
    public int currX;
    public int currY;
    public ChessPieceType type;
    public Vector3 desPosition;
    public Vector3 desScale;
}