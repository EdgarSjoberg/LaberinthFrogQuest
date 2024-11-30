using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] protected bool[] paths = null;
    [SerializeField] protected bool hasCollectable;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract bool CheckPaths(int direction);
}
