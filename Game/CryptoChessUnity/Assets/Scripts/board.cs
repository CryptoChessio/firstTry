using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour {

    [Header("Pretty")]
    
    [SerializeField] private Material tileMat;
    [SerializeField] private Material hoverMat;

    [SerializeField] private Material WhiteHover;

    [SerializeField] private Material BlackHover;

    [SerializeField] private float TILE_SIZE = 1.0f;

    [Header("Prefabs and Mats")]

    [SerializeField] private GameObject[] prefab;
    [SerializeField] private Material[] mats;
    

    
    //Game logic
    private ChessPiece ACTIVE;
    private ChessPiece[,] chessPieces;
    private const int TILE_C_X = 8;
    private const int TILE_C_Y = 8;
    private GameObject[,] tiles; //2 dem array 
    private Camera currentCamera;
    private Vector2Int currentHover;
    public void Awake() {
        GenrateGrid(TILE_SIZE, TILE_C_X, TILE_C_Y);

        //test
        
        SpawnAllPieces();
        PositionAllPieces();
    }

    private void GenrateGrid(float tileSize, int tileCountX, int tileCountY){
        tiles = new GameObject[tileCountX, tileCountY];
        for (int x = 0; x < tileCountX; x++)
            for (int y = 0; y < tileCountY; y++)
                tiles[x,y] = GenrateTile(tileSize, x, y);
    }

    private void Update() {
        if (!currentCamera){
            currentCamera = Camera.main;
            return;
        }

        //this is fuking disgusting and not efficient at all

        RaycastHit info;
        Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out info, 100, LayerMask.GetMask("Tile"))){
            //get index of hit tile
            Vector2Int hitPostion = LookTileIndex(info.transform.gameObject);
            
            if(currentHover == -Vector2Int.one){ //def hover
                currentHover = hitPostion;
                
                tiles[hitPostion.x, hitPostion.y].layer = LayerMask.NameToLayer("Hover");
                // tiles[currentHover.x, currentHover.y].GetCompontent<MeshRenderer>().material = hoverMat;
                // Debug.Log("hover");
            }
            if(currentHover != -Vector2Int.one){ //def hover
                tiles[currentHover.x, currentHover.y].layer = LayerMask.NameToLayer("Tile"); //reset tile
                currentHover = hitPostion;
                tiles[hitPostion.x, hitPostion.y].layer = LayerMask.NameToLayer("Hover");
                tiles[currentHover.x, currentHover.y].GetComponent<MeshRenderer>().material = hoverMat;
                
            }

            if(Input.GetMouseButtonDown(0)){
                Debug.Log("click");
                if (chessPieces[hitPostion.x, hitPostion.y] != null){
                    // if(chessPieces[hitPostion.x, hitPostion.y].team == ACTIVE.team){
                    //     ACTIVE = chessPieces[currentHover.x, currentHover.y];
                    //     Debug.Log("active");
                    // }
                    // for later
                    if (true){
                        ACTIVE = chessPieces[currentHover.x, currentHover.y];
                        Debug.Log("active");
                    }
                }
            }
            
            if (ACTIVE != null && Input.GetMouseButtonUp(0)){
                Vector2Int prevPos = new Vector2Int(ACTIVE.currX, ACTIVE.currY);
                Debug.Log("prevPos: " + prevPos);
                bool validMove = MoveTo(ACTIVE, hitPostion.x, hitPostion.y);
                if(!validMove){
                    ACTIVE.transform.position = GetTileCenter(prevPos.x, prevPos.y);
                    ACTIVE = null;
                }
            }

        }else{
            if(currentHover != -Vector2Int.one){
                tiles[currentHover.x, currentHover.y].layer = LayerMask.NameToLayer("Tile");
                currentHover = -Vector2Int.one;
            }
        }

        // set tiles with chess pieces to have a WhiteTile matriel
        
    }

    //board gen
    private GameObject GenrateTile(float tileSize, int x, int y){
        GameObject tileObject = new GameObject(string.Format("x:{0}, y{1}", x, y)); //prints values
        tileObject.transform.parent = transform; //set tile transform to board transform 

        Mesh mesh = new Mesh();
        tileObject.AddComponent<MeshFilter>().mesh = mesh;
        tileObject.AddComponent<MeshRenderer>().material = tileMat;
        
        //init verts for tiles
        Vector3[] verts = new Vector3[4];
        verts[0] = new Vector3(x*tileSize, 0, y*tileSize);
        verts[1] = new Vector3(x*tileSize, 0, (y+1)*tileSize);
        verts[2] = new Vector3((x+1)*tileSize, 0, y*tileSize);
        verts[3] = new Vector3((x+1)*tileSize, 0, (y+1)*tileSize);

        int[] triangle = new int[] {0, 1, 2, 1, 3, 2}; 

        //set
        mesh.vertices = verts;
        mesh.triangles = triangle;
        mesh.RecalculateNormals();
        tileObject.layer = LayerMask.NameToLayer("Tile");
        tileObject.AddComponent<BoxCollider>(); //aprl box collier is more ef then a plane idk why i didn't make the rules your mom did
        return tileObject;
    }

    // Spawn Piece
    private void SpawnAllPieces(){
        chessPieces = new ChessPiece[TILE_C_X, TILE_C_Y];
        int white = 0;
        int black = 1;
        
        //thank you copilot i love you
        chessPieces[0,0] = SpawnSinglePiece(ChessPieceType.Rook, white);
        chessPieces[1,0] = SpawnSinglePiece(ChessPieceType.Knight, white);
        chessPieces[2,0] = SpawnSinglePiece(ChessPieceType.Bishop, white);
        chessPieces[3,0] = SpawnSinglePiece(ChessPieceType.Queen, white);
        chessPieces[4,0] = SpawnSinglePiece(ChessPieceType.King, white);
        chessPieces[5,0] = SpawnSinglePiece(ChessPieceType.Bishop, white);
        chessPieces[6,0] = SpawnSinglePiece(ChessPieceType.Knight, white);
        chessPieces[7,0] = SpawnSinglePiece(ChessPieceType.Rook, white);

        for (int i = 0; i < TILE_C_X; i++)
            chessPieces[i,1] = SpawnSinglePiece(ChessPieceType.Pawn, white);
        
        chessPieces[0,7] = SpawnSinglePiece(ChessPieceType.Rook, black);
        chessPieces[1,7] = SpawnSinglePiece(ChessPieceType.Knight, black);
        chessPieces[2,7] = SpawnSinglePiece(ChessPieceType.Bishop, black);
        chessPieces[3,7] = SpawnSinglePiece(ChessPieceType.Queen, black);
        chessPieces[4,7] = SpawnSinglePiece(ChessPieceType.King, black);
        chessPieces[5,7] = SpawnSinglePiece(ChessPieceType.Bishop, black);
        chessPieces[6,7] = SpawnSinglePiece(ChessPieceType.Knight, black);
        chessPieces[7,7] = SpawnSinglePiece(ChessPieceType.Rook, black);

        

        for (int i = 0; i < TILE_C_X; i++)
            chessPieces[i,6] = SpawnSinglePiece(ChessPieceType.Pawn, black);
    }
    private ChessPiece SpawnSinglePiece(ChessPieceType type, int team){
        ChessPiece piece = Instantiate(prefab[(int)type -1], transform).GetComponent<ChessPiece>(); //instantiate and get piece
        piece.type = type;
        piece.team = team;
        piece.GetComponent<MeshRenderer>().material = mats[team];
        return piece;
    }

    private void PositionAllPieces(){
        for (int x = 0; x < TILE_C_X; x++)
            for (int y = 0; y < TILE_C_Y; y++)
                if(chessPieces[x,y] != null)
                    PostionSinglePiece( x, y, true);
    }

    private void PostionSinglePiece(int x, int y, bool force = false){
        chessPieces[x,y].currX = x;
        chessPieces[x,y].currY = y;
        // chessPieces[x,y].transform.position = new Vector3(x * TILE_SIZE, 0, y * TILE_SIZE);
        chessPieces[x,y].transform.position = GetTileCenter(x, y);

    }

    private Vector3 GetTileCenter(int x, int y){
        Vector3 halfSize = Vector3.one * (TILE_SIZE / 2);
        Vector3 tilePos = new Vector3(x, -.4f, y);
        return tilePos + halfSize;
    }
    //ops
    private Vector2Int LookTileIndex(GameObject hitInfo){
        for (int x = 0; x < TILE_C_X; x++)
            for (int y = 0; y < TILE_C_Y; y++)
                if(tiles[x,y] == hitInfo)
                    return new Vector2Int(x,y);
        
        return -Vector2Int.one;
    }

    private bool MoveTo(ChessPiece ACTIVE, int x, int y){
        Vector2Int prevPos = new Vector2Int(ACTIVE.currX, ACTIVE.currY);

        chessPieces[x,y] = ACTIVE;
        chessPieces[prevPos.x , prevPos.y] = null;

        PostionSinglePiece(x, y);

        return true;
    }
}

