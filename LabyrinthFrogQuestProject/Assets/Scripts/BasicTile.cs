using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTile : Tile
{

    // Start is called before the first frame update
    void Start()
    {
    }
    private void Awake()
    {
        if(hasScoreCollectable)
        {
            //Instantiate collectable
            Collectable scoreCollectable = GameManager.GetScoreCollectable();
            Collectable collectable = Instantiate(scoreCollectable);
            collectable.transform.SetParent(this.transform);
            collectable.transform.localPosition = new Vector3(0, 0, -1);
            GameManager.AddScoreCollectable(collectable);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override bool CheckPaths(int direction)
    {
        if (paths[direction])
            return true;
        else return false;
    }
}
