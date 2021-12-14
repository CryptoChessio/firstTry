using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour {

    [Header("Pretty")]
    [SerializeField] private Material tileMat;
    //Game logic
    private const int TILE_C_X = 8;
    private const int TILE_C_Y = 8;
    private GameObject[,] tiles; //2 dem arry 
    private Camera currentCamera;
    private Vector2Int currentHover;
    public void Awake() {
        GenrateGrid(1, TILE_C_X, TILE_C_Y);
    }

    private void GenrateGrid(float tileSize, int tileCountX, int tileCountY){
        tiles = new GameObject[tileCountX, tileCountY];
        for (int x = 0; x < tileCountX; x++)
        {
            for (int y = 0; y < tileCountY; y++)
            {
                tiles[x,y] = GenrateTile(tileSize, x, y);
            }
        }
    }

    private void Update() {
        if (!currentCamera){
            currentCamera = Camera.main;
            return;
        }

        RaycastHit info;
        Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out info, 100, LayerMask.GetMask("Tile"))){
            //get index of hit tile
            Vector2Int hitPostion = LookTileIndex(info.transform.gameObject);

            if(currentHover == -Vector2Int.one){ //def hover
                currentHover = hitPostion;
                tiles[hitPostion.x, hitPostion.y].layer = LayerMask.NameToLayer("Hover");
                Debug.Log("hover");
            }
            if(currentHover != -Vector2Int.one){ //def hover
                tiles[currentHover.x, currentHover.y].layer = LayerMask.NameToLayer("Tile"); //reset tile
                currentHover = hitPostion;
                tiles[hitPostion.x, hitPostion.y].layer = LayerMask.NameToLayer("Hover");
                Debug.Log("hover");
            }
        }else{
            if(currentHover != -Vector2Int.one){
                tiles[currentHover.x, currentHover.y].layer = LayerMask.NameToLayer("Tile");
                currentHover = -Vector2Int.one;
            }
        }
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

    //ops
    private Vector2Int LookTileIndex(GameObject hitInfo){
        for (int x = 0; x < TILE_C_X; x++)
        {
            for (int y = 0; y < TILE_C_Y; y++)
            {
                if(tiles[x,y] == hitInfo)
                    return new Vector2Int(x,y);
            }
        }
        return -Vector2Int.one;
    }
}