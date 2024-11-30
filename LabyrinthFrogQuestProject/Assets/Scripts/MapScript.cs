using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PushDirection { Left, Right, Up, Down }

public class MapScript : MonoBehaviour
{
    [SerializeField] List<Tile> tileList = new List<Tile>();
    [SerializeField] Tile[,] mapTiles;

    [SerializeField] int mapDepth = 2;
    [SerializeField] int mapWidth = 2;

    [SerializeField]
    Tile handTile;
    // Start is called before the first frame update



    void Start()
    {
        mapTiles = new Tile[mapWidth, mapDepth];

        //CreateMap();
        //DrawMap();
    }



    public void DrawMap()
    {
        for (int i = 0; i <= mapWidth - 1; i++)
        {
            for (int j = 0; j <= mapDepth - 1; j++)
            {
                Tile tileClone = mapTiles[i, j];
                Tile createdTile = Instantiate(tileClone, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
                createdTile.transform.position = new Vector3(i, j, 0);
                Debug.Log(i.ToString() + j.ToString());
            }
        }
    }
    public void CreateMap()
    {
        for (int i = 0; i <= mapWidth - 1; i++)
        {
            for (int j = 0; j <= mapDepth - 1; j++)
            {
                mapTiles[i, j] = tileList[Random.Range(0, tileList.Count - 1)];
            }
        }
    }

    public void ChangeDimensions(int width, int depth)
    {
        MapWidth = width;
        MapDepth = depth;

        mapTiles = new Tile[width, depth];
    }

    public int MapDepth
    {
        get { return mapDepth; }
        set { mapDepth = value; }
    }
    public int MapWidth
    {
        get { return mapWidth; }
        set { mapWidth = value; }
    }

    public Tile[,] GetMap()
    {
        return mapTiles;
    }


    public Vector3 Center()
    {
        return new Vector3(((float)MapWidth / 2), ((float)MapDepth / 2) - 0.5f);
    }

    public void PushTiles(PushDirection direction, int x, int y)
    {
        List<Tile> tilesToMove = new List<Tile>();
        int maxSizeWidth = mapWidth - 1;
        int maxSizeDepth = mapDepth - 1;    

        switch (direction) 
        { 
                        //  Pushing FROM the right side and TOWARD the left
            case PushDirection.Left:

                for(int i = maxSizeWidth; i >= 0; i-- )
                {
                    if(i == 0) 
                    {
                        Tile tempTile = mapTiles[0, y];
                        mapTiles[maxSizeWidth, y] = handTile;
                        handTile = tempTile;
                    }
                    else
                    {
                        tilesToMove.Add(mapTiles[i, y]);
                    }
                    
                }
                tilesToMove.Reverse();
                
                for(int i = 0; i < tilesToMove.Count; i++)
                {
                    

                    Vector3 tilePos = tilesToMove[i].GetComponent<Transform>().position;
                    tilePos.x -= 1;
                    tilesToMove[i].GetComponent<Transform>().position = tilePos;

                    mapTiles[i, y] = tilesToMove[i];
                    
                }

                break;
                        //  Pushing FROM the left side and TOWARD the right
            case PushDirection.Right:

                for(int i = 0; i <= maxSizeWidth; i++)
                {
                    if (i == maxSizeWidth)
                    {
                        Tile tempTile = mapTiles[maxSizeWidth, y];
                        mapTiles[0, y] = handTile;
                        handTile = tempTile;
                    }
                    else
                    {
                        tilesToMove.Add(mapTiles[i, y]);
                    }


                }
                tilesToMove.Reverse();

                for (int i = maxSizeWidth; i > 0; i--)
                {

                    Vector3 tilePos = tilesToMove[i].GetComponent<Transform>().position;
                    tilePos.x += 1;
                    tilesToMove[i].GetComponent<Transform>().position = tilePos;

                    mapTiles[i, y] = tilesToMove[i];

                }



                break;
                        //  Pushing FROM the bottom side and TOWARD the top
            case PushDirection.Up:

                for (int i = 0; i <= maxSizeDepth; i++)
                {
                    if (i == maxSizeDepth)
                    {
                        Tile tempTile = mapTiles[x, maxSizeDepth];
                        mapTiles[x, maxSizeDepth] = handTile;
                        handTile = tempTile;
                    }
                    else
                    {
                        tilesToMove.Add(mapTiles[x, maxSizeDepth]);
                    }


                }
                tilesToMove.Reverse();

                for (int i = maxSizeDepth; i > 0; i--)
                {

                    Vector3 tilePos = tilesToMove[i].GetComponent<Transform>().position;
                    tilePos.y += 1;
                    tilesToMove[i].GetComponent<Transform>().position = tilePos;

                    mapTiles[x, i] = tilesToMove[i];

                }

                break;
                        //  Pushing FROM the top side and TOWARD the bottom
            case PushDirection.Down:

                for (int i = maxSizeDepth; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        Tile tempTile = mapTiles[x, 0];
                        mapTiles[x, maxSizeDepth] = handTile;
                        handTile = tempTile;
                    }
                    else
                    {
                        tilesToMove.Add(mapTiles[x, i]);
                    }


                }
                tilesToMove.Reverse();

                for (int i = 0; i < maxSizeDepth; i++)
                {

                    Vector3 tilePos = tilesToMove[i].GetComponent<Transform>().position;
                    tilePos.y -= 1;
                    tilesToMove[i].GetComponent<Transform>().position = tilePos;

                    mapTiles[x, i] = tilesToMove[i];

                }

                break;

        }




    }


}
