using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour
{

    [Header("Pretty")]

    [SerializeField] private Material tileMat;
    [SerializeField] private Material hoverMat;

    [SerializeField] private Material WhiteHover;

    [SerializeField] private Material BlackHover;

    [SerializeField] private Material AvalMovesMat;

    [SerializeField] private float TILE_SIZE = 1.0f;

    [Header("Prefabs and Mats")]

    [SerializeField] private GameObject[] prefab;
    [SerializeField] private Material[] mats;



    //Game logic
    private ChessPiece ACTIVE;
    private ChessPiece[,] chessPieces;
    private List<Vector2Int> avalMoves = new List<Vector2Int>();
    private List<ChessPiece> deadWhite = new List<ChessPiece>();
    private List<ChessPiece> deadBlack = new List<ChessPiece>();
    private const int TILE_C_X = 8;
    private const int TILE_C_Y = 8;
    private GameObject[,] tiles; //2 dem array 
    private Camera currentCamera;
    private Vector2Int currentHover;
    public void Awake()
    {
        GenrateGrid(TILE_SIZE, TILE_C_X, TILE_C_Y);

        //test

        SpawnAllPieces();
        PositionAllPieces();
    }

    private void GenrateGrid(float tileSize, int tileCountX, int tileCountY)
    {  //generate grid
        tiles = new GameObject[tileCountX, tileCountY]; //2 dem array
        for (int x = 0; x < tileCountX; x++)
            for (int y = 0; y < tileCountY; y++)
                tiles[x, y] = GenrateTile(tileSize, x, y); //call genrate tile
    }

    private void Update()
    {
        if (!currentCamera)
        { //if no camera is set
            currentCamera = Camera.main;  //set the main camera
            return;
        }
        // foreach (GameObject tile in tiles) //loop through all tiles **this is terrible code**
        //     tile.GetComponent<Renderer>().material = tileMat; //set material to default


        RaycastHit info;
        Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out info, 100))
        { //if raycast hits a tile
            //get index of hit tile
            Vector2Int hitPostion = LookTileIndex(info.transform.gameObject); //get index of hit tile

            if (currentHover == -Vector2Int.one)
            { //if no hover
                currentHover = hitPostion; //set hover to hit tile
                tiles[hitPostion.x, hitPostion.y].GetComponent<Renderer>().material = hoverMat;
            }
            if (currentHover != -Vector2Int.one)
            {
                currentHover = hitPostion; //set new hover to hit tile
                tiles[currentHover.x, currentHover.y].GetComponent<MeshRenderer>().material = hoverMat;

            }

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("click");
                if (chessPieces[hitPostion.x, hitPostion.y] != null)
                { //if there is a piece
                    if (true)
                    { //is turn
                        ACTIVE = chessPieces[currentHover.x, currentHover.y]; //set active

                        avalMoves = ACTIVE.GetAvalMoves(ref chessPieces, TILE_C_X, TILE_C_Y); //get aval moves
                        HighlightTiles(); //highlight aval moves
                    }
                }
            }

            if (ACTIVE != null && Input.GetMouseButtonUp(0))
            { //mouse release 
                Vector2Int prevPos = new Vector2Int(ACTIVE.currX, ACTIVE.currY); //prev pos
                Debug.Log("prevPos: " + prevPos);
                bool validMove = MoveTo(ACTIVE, hitPostion.x, hitPostion.y); //move piece
                if (!validMove)
                { //if move is invalid
                    ACTIVE.SetPosition(GetTileCenter(prevPos.x, prevPos.y)); //move piece back
                    ACTIVE = null; //reset active
                }
                else
                {
                    ACTIVE = null; //reset active
                }
            }

        }
        else
        {
            if (currentHover != -Vector2Int.one)
            {
                tiles[currentHover.x, currentHover.y].GetComponent<Renderer>().material = tileMat;
                currentHover = -Vector2Int.one;
            }

            if (ACTIVE && Input.GetMouseButtonUp(0))
            {
                ACTIVE.SetPosition(GetTileCenter(ACTIVE.currX, ACTIVE.currY));
                ACTIVE = null;
            }
        }

        // set tiles with chess pieces to have a WhiteTile matriel

        //if dragging piece 
        if (ACTIVE)
        {
            Plane horzPlan = new Plane(Vector3.up, Vector3.up);
            float distance = 0.0f;
            if (horzPlan.Raycast(ray, out distance))
            {
                ACTIVE.SetPosition(ray.GetPoint(distance));
            }
        }

    }

    //board gen
    private GameObject GenrateTile(float tileSize, int x, int y)
    {
        GameObject tileObject = new GameObject(string.Format("x:{0}, y{1}", x, y)); //prints values
        tileObject.transform.parent = transform; //set tile transform to board transform 

        Mesh mesh = new Mesh(); //create mesh
        tileObject.AddComponent<MeshFilter>().mesh = mesh;  //add mesh filter
        tileObject.AddComponent<MeshRenderer>().material = tileMat;  //add mesh renderer

        //init verts for tiles
        Vector3[] verts = new Vector3[4];  //4 verts
        verts[0] = new Vector3(x * tileSize, 0, y * tileSize); //top left
        verts[1] = new Vector3(x * tileSize, 0, (y + 1) * tileSize); //bottom left
        verts[2] = new Vector3((x + 1) * tileSize, 0, y * tileSize); //top right
        verts[3] = new Vector3((x + 1) * tileSize, 0, (y + 1) * tileSize); //bottom right

        int[] triangle = new int[] { 0, 1, 2, 1, 3, 2 };  //triangles for mesh 

        //set
        mesh.vertices = verts; //set verts
        mesh.triangles = triangle; //set triangles
        mesh.RecalculateNormals(); //recalculate normals
        tileObject.layer = LayerMask.NameToLayer("Tile"); //set layer to tile
        tileObject.AddComponent<BoxCollider>(); //aprl box collier is more ef then a plane idk why i didn't make the rules your mom did
        return tileObject;
    }

    // Spawn Piece
    private void SpawnAllPieces()
    {
        chessPieces = new ChessPiece[TILE_C_X, TILE_C_Y];
        int white = 0;
        int black = 1;

        //thank you copilot i love you 
        chessPieces[0, 0] = SpawnSinglePiece(ChessPieceType.Rook, white);
        chessPieces[1, 0] = SpawnSinglePiece(ChessPieceType.Knight, white);
        chessPieces[2, 0] = SpawnSinglePiece(ChessPieceType.Bishop, white);
        chessPieces[3, 0] = SpawnSinglePiece(ChessPieceType.Queen, white);
        chessPieces[4, 0] = SpawnSinglePiece(ChessPieceType.King, white);
        chessPieces[5, 0] = SpawnSinglePiece(ChessPieceType.Bishop, white);
        chessPieces[6, 0] = SpawnSinglePiece(ChessPieceType.Knight, white);
        chessPieces[7, 0] = SpawnSinglePiece(ChessPieceType.Rook, white);

        for (int i = 0; i < TILE_C_X; i++)
            chessPieces[i, 1] = SpawnSinglePiece(ChessPieceType.Pawn, white);

        chessPieces[0, 7] = SpawnSinglePiece(ChessPieceType.Rook, black);
        chessPieces[1, 7] = SpawnSinglePiece(ChessPieceType.Knight, black);
        chessPieces[2, 7] = SpawnSinglePiece(ChessPieceType.Bishop, black);
        chessPieces[3, 7] = SpawnSinglePiece(ChessPieceType.Queen, black);
        chessPieces[4, 7] = SpawnSinglePiece(ChessPieceType.King, black);
        chessPieces[5, 7] = SpawnSinglePiece(ChessPieceType.Bishop, black);
        chessPieces[6, 7] = SpawnSinglePiece(ChessPieceType.Knight, black);
        chessPieces[7, 7] = SpawnSinglePiece(ChessPieceType.Rook, black);



        for (int i = 0; i < TILE_C_X; i++)
            chessPieces[i, 6] = SpawnSinglePiece(ChessPieceType.Pawn, black);
    }
    private ChessPiece SpawnSinglePiece(ChessPieceType type, int team)
    {  //spawn single piece
        ChessPiece piece = Instantiate(prefab[(int)type - 1], transform).GetComponent<ChessPiece>(); //instantiate and get piece
        piece.type = type;
        piece.team = team;
        piece.GetComponent<MeshRenderer>().material = mats[team]; //set material
        return piece;
    }

    private void PositionAllPieces()
    { //position all pieces
        for (int x = 0; x < TILE_C_X; x++)
            for (int y = 0; y < TILE_C_Y; y++)
                if (chessPieces[x, y] != null)
                    PostionSinglePiece(x, y, true);
    }

    private void PostionSinglePiece(int x, int y, bool force = false)
    { //position single piece
        chessPieces[x, y].currX = x;
        chessPieces[x, y].currY = y;
        // chessPieces[x,y].transform.position = new Vector3(x * TILE_SIZE, 0, y * TILE_SIZE);
        chessPieces[x, y].SetPosition(GetTileCenter(x, y), force); //get tile center

    }

    private Vector3 GetTileCenter(int x, int y)
    { //get tile center
        Vector3 halfSize = Vector3.one * (TILE_SIZE / 2); //get half size
        Vector3 tilePos = new Vector3(x, -.4f, y); //get tile pos
        return tilePos + halfSize; //return tile pos + half size
    }
    //ops
    private Vector2Int LookTileIndex(GameObject hitInfo)
    { //look tile index
        for (int x = 0; x < TILE_C_X; x++)
            for (int y = 0; y < TILE_C_Y; y++)
                if (tiles[x, y] == hitInfo) //if tile is hit
                    return new Vector2Int(x, y); //return tile index

        return -Vector2Int.one; //return -1
    }

    private void HighlightTiles()
    {
        for (int i = 0; i < avalMoves.Count; i++)
            tiles[avalMoves[i].x, avalMoves[i].y].GetComponent<MeshRenderer>().material = AvalMovesMat;
    }

    private void UnhighlightTiles()
    {
        for (int i = 0; i < avalMoves.Count; i++)
            tiles[avalMoves[i].x, avalMoves[i].y].GetComponent<MeshRenderer>().material = tileMat;
        avalMoves.Clear();
    }

    private bool MoveTo(ChessPiece ACTIVE, int x, int y)
    { //move to
        Vector2Int prevPos = new Vector2Int(ACTIVE.currX, ACTIVE.currY); //get prev pos
        //is there another piece on target pos
        if (chessPieces[x, y] != null)
        { //if there is a piece
            ChessPiece ocp = chessPieces[x, y]; //get other piece

            if (ACTIVE.team == ocp.team) //if same team
                return false; //return false

            if (ocp.team == 0)
            {
                deadWhite.Add(ocp);
                Destroy(ocp.gameObject);
            }
            else
            {
                deadBlack.Add(ocp);
                Destroy(ocp.gameObject);
            }
        }
        chessPieces[x, y] = ACTIVE; //set piece
        chessPieces[prevPos.x, prevPos.y] = null; //set prev pos to null

        PostionSinglePiece(x, y); //position piece

        return true;

    }
}

