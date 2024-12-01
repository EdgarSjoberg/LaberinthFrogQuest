using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PushDirection { Left, Right, Up, Down, Invalid }

public class MapScript : MonoBehaviour
{
    [SerializeField] List<Tile> tileList = new List<Tile>();
    [SerializeField] Tile[,] mapTiles;

    int mapDepth = 0;
    int mapWidth = 0;

    CharacterPusher pusher;

    [SerializeField]
    CharacterScript player;

    [SerializeField]
    Tile handTile;
    // Start is called before the first frame update



    void Start()
    {
        mapTiles = new Tile[mapWidth, mapDepth];
        pusher = FindObjectOfType<CharacterPusher>();
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
                mapTiles[i, j] = createdTile;
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

        Vector3 playerPos = player.GetComponent<Transform>().position;
        bool playerPushed = false;


        switch (direction) 
        { 
                        //  Pushing FROM the right side and TOWARD the left
            case PushDirection.Left:
                tilesToMove.Add(handTile);
                for (int i = maxSizeDepth; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        Tile tempTile = mapTiles[i, y];
                        handTile = tempTile;
                    }
                    else
                    {
                        tilesToMove.Add(mapTiles[i, y]);
                    }
                }
                tilesToMove.Reverse();
                for (int i = maxSizeDepth; i >= 0; i--)
                {
                    mapTiles[i, y] = tilesToMove[i];
                    mapTiles[i, y].transform.position = new Vector3(i, y, 0);

                    if(playerPos == mapTiles[i,y].transform.position && !playerPushed)
                    {
                        playerPushed = true;
                        playerPos.x -= 1;
                        player.transform.position = playerPos;
                    }

                }
                handTile.transform.position = new Vector3(0, 0, 1);

                break;
                        //  Pushing FROM the left side and TOWARD the right
            case PushDirection.Right:

                tilesToMove.Add(handTile);
                for (int i = 0; i <= maxSizeDepth; i++)
                {
                    if (i == maxSizeDepth)
                    {
                        Tile tempTile = mapTiles[i, y];
                        handTile = tempTile;
                    }
                    else
                    {
                        tilesToMove.Add(mapTiles[i, y]);
                    }
                }

                for (int i = 0; i <= maxSizeDepth; i++)
                {
                    mapTiles[i, y] = tilesToMove[i];
                    mapTiles[i, y].transform.position = new Vector3(i, y, 0);

                    if (playerPos == mapTiles[i, y].transform.position && !playerPushed)
                    {
                        playerPushed = true;
                        playerPos.x += 1;
                        player.transform.position = playerPos;
                    }

                }
                handTile.transform.position = new Vector3(0, 0, 1);


                break;
                        //  Pushing FROM the bottom side and TOWARD the top
            case PushDirection.Up:

                tilesToMove.Add(handTile);
                for (int i = 0; i <= maxSizeDepth; i++)
                {
                    if (i == maxSizeDepth)
                    {
                        Tile tempTile = mapTiles[x, i];
                        handTile = tempTile;
                    }
                    else
                    {
                        tilesToMove.Add(mapTiles[x, i]);
                    }
                }

                for (int i = 0; i <= maxSizeDepth; i++)
                {
                    mapTiles[x, i] = tilesToMove[i];
                    mapTiles[x, i].transform.position = new Vector3(x, i, 0);

                    if (playerPos == mapTiles[x, i].transform.position && !playerPushed)
                    {
                        playerPushed = true;
                        playerPos.y += 1;
                        player.transform.position = playerPos;
                    }


                }
                handTile.transform.position = new Vector3 (0,0,1);

                break;
                        //  Pushing FROM the top side and TOWARD the bottom
            case PushDirection.Down:

                tilesToMove.Add(handTile);
                for (int i = maxSizeDepth; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        Tile tempTile = mapTiles[x, i];
                        handTile = tempTile;
                    }
                    else
                    {
                        tilesToMove.Add(mapTiles[x, i]);
                    }
                }
                tilesToMove.Reverse();
                for (int i = maxSizeDepth; i >= 0; i--)
                {
                    mapTiles[x, i] = tilesToMove[i];
                    mapTiles[x, i].transform.position = new Vector3(x, i, 0);

                    if (playerPos == mapTiles[x, i].transform.position && !playerPushed)
                    {
                        Debug.Log($"Player was on pos {playerPos} and is to be moved!");
                        playerPushed = true;
                        playerPos.y -= 1;
                        player.transform.position = playerPos;
                        Debug.Log($"Player was moved to {playerPos}!");
                    }

                }
                handTile.transform.position = new Vector3(0, 0, 1);
                break;

        }
        pusher.GetComponentInChildren<SpriteRenderer>().sprite = handTile.GetComponentInChildren<SpriteRenderer>().sprite;

        if (playerPos.x < 0)
        {
            playerPos.x = maxSizeWidth;
            player.transform.position = playerPos;
        }
        else if (playerPos.x > maxSizeWidth)
        {
            playerPos.x = 0;
            player.transform.position = playerPos;
        }
        else if (playerPos.y < 0) 
        {
            playerPos.y = maxSizeDepth;
            player.transform.position = playerPos;
        }
        else if(playerPos.y > maxSizeDepth)
        {
            playerPos.y = 0;
            player.transform.position = playerPos;
        }

        //RedrawMap();


    }
    public void RedrawMap()
    {
        Debug.Log("RedrawMap");
        for (int i = 0; i <= mapWidth - 1; i++)
        {
            for (int j = 0; j <= mapDepth - 1; j++)
            {
                Tile movingTile = mapTiles[i, j];
                movingTile.transform.position = new Vector3(i, j, 0);
            }
        }

    }


}
