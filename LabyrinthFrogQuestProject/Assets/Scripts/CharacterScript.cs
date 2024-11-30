using Unity.VisualScripting;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    // Start is called before the first frame update

    bool moveTurn = true;
    bool placeTileTurn;
    [SerializeField] float moveSpeed;
    void Start()
    {
        transform.position = Vector3.zero;
    }

    enum MoveDirection
    {
        Up,
        Down,
        Right,
        Left
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!moveTurn)
            {
                placeTileTurn = false;
                moveTurn = true;
                Debug.Log("move turn");
            }
            else
            {
                moveTurn = false;
                placeTileTurn = true;
                Debug.Log("Place turn");
            }
        }
        if (moveTurn)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0, 1, 0);


            } 
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(0, -1, 0);
            } 
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.position += new Vector3(1, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.position += new Vector3(-1, 0, 0);
            }
        }
    }

    bool CanMove(MoveDirection moveDirection)
    {
        
        return true;
    }
}
