using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] MapScript mapScript;
    [SerializeField] static int score = 0;
    [SerializeField] Collectable scoreCollectablePrefab;
    static Collectable scoreCollectablePropety;
    int amountOfCollectibles = 3; 

    static List<Collectable> scoreCollectableList = new List<Collectable>();
    void Start()
    {

        MapScript mapScript = GetComponent<MapScript>();
        //spawn first collectibles(Add more later?)

        for (int i = 0; i < amountOfCollectibles; i++)
        {
            AddScoreCollectable();
        }

        
    }

    void Update()
    {
        
    }

    public static void AddScore(int value)
    {
        score += value;
    }

    public static Collectable GetScoreCollectable()
    {
        return scoreCollectablePropety;
    }

    public static Collectable GetRandomScoreCollectable()
    {
        return scoreCollectablePropety;
    }
    public static void AddScoreCollectable()
    {
       
        scoreCollectableList.Add(new Collectable());
    }
}
