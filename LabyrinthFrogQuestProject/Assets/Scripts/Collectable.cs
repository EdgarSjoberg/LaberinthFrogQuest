using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    //wont use?
    //private Vector2 postition;

    //set parent, gives postiion and movement
    [SerializeField] GameObject parentTile;



    void Start()
    {


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetParent(GameObject parent)
    {
        parentTile = parent;
        this.transform.SetParent(parent.transform);
       
    }
    public virtual void Collect()
    {
        //add into scorere
        Destroy(gameObject);
    }
}
