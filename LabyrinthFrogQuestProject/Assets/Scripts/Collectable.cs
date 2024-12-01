using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector2 postition;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void Collect()
    {
        Destroy(gameObject);
    }
}
