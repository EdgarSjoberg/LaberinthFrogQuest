using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    [SerializeField] List<Tile> tileList = new List<Tile>();
    [SerializeField] Tile[,] mapTiles;

     [SerializeField] int mapDepth = 2;
     [SerializeField] int mapWidth = 2;
    // Start is called before the first frame update



    void Start()
    {
        mapTiles = new Tile[mapWidth, mapDepth];
        CreateMap();
        DrawMap();
    }

    // Update is called once per frame
    void Update()
    {

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
}
