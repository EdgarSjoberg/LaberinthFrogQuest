using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
 
    [SerializeField] static int score = 0;
    [SerializeField] Collectable scoreCollectable;
    static Collectable ScoreCollectable;

    static List<Collectable> scoreCollectables = new List<Collectable>();
    void Start()
    {
        ScoreCollectable = this.scoreCollectable;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void AddScore(int value)
    {
        score += value;
    }

    public static Collectable GetScoreCollectable()
    {
        return ScoreCollectable;
    }

    public static Collectable GetRandomScoreCollectable()
    {
        return ScoreCollectable;
    }
    public static void AddScoreCollectable(Collectable collectable)
    {
        scoreCollectables.Add(collectable);
    }
}
