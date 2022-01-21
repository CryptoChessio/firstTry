using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ChessPieceType
{ //ul of data vals for chess pieces 
    None = 0,
    Pawn = 1,
    Rook = 2,
    Knight = 3,
    Bishop = 4,
    Queen = 5,
    King = 6
}


public class ChessPiece : MonoBehaviour
{ //chess piece class
    public int team;
    public int currX;
    public int currY;
    public ChessPieceType type;
    public Vector3 desPosition;
    // public Vector3 desScale = new Vector3(1,1,1);
    public void Start()
    {
        transform.rotation = Quaternion.Euler((team == 0 ) ? new Vector3(-90, 90, 0) : new Vector3(-90, 270, 0));
        //if chessPiece is pawn rotate it on the z direction by 90
        if(type == ChessPieceType.Pawn)
        {
            transform.Rotate(new Vector3(0, -90, 0));
            //transfrom up by 3
            transform.Translate(new Vector3(0, 0, 10));
        }
    }
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, desPosition, Time.deltaTime * 5); //lerp to des position
        // transform.localScale = Vector3.Lerp(transform.localScale, desScale, Time.deltaTime * 5); //lerp to des scale
    }

    public virtual List<Vector2Int> GetAvalMoves(
        ref ChessPiece[,] board,
        int tileCountX,
        int tileCountY)
    {
        List<Vector2Int> moves = new List<Vector2Int>();

        moves.Add(new Vector2Int(3, 3));
        moves.Add(new Vector2Int(3, 4));
        moves.Add(new Vector2Int(4, 3));
        moves.Add(new Vector2Int(4, 4));

        return moves;

    }
    public virtual SpecialMove GetSpecialMove(
        ref ChessPiece[,] board,
        ref List<Vector2Int[]> movesList,
        ref List<Vector2Int> avalMoves)
    {
        return SpecialMove.None;
    }

    public virtual void SetPosition(Vector3 pos, bool force = false)
    { //set position
        desPosition = pos;
        if (force)
            transform.position = desPosition;
    }

    // public virtual void SetScale(Vector3 scale, bool force = false){ //set scale
    //     desScale = scale;
    //     if(force)
    //         transform.localScale = desScale;
    // }
}