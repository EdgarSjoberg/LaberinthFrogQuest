using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    // Start is called before the first frame update

    //bool moveTurn = true;
    bool placeTileTurn;
    [SerializeField] float moveSpeed;
    [SerializeField] MapScript mapScript;

    bool playerTurn;


    void Start()
    {
        transform.position = Vector3.zero;
        playerTurn = false;
    }

    enum MoveDirection
    {
        Up,
        Down,
        Right,
        Left
    }

    // Update is called once per frame
    public void Update()
    {
        


        
    }

    //public void CheckMoveInput()
    //{
    //    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
    //    {
    //        if (CanMove(MoveDirection.Up))
    //        {
    //            //moveTurn = false;
    //            transform.position += new Vector3(0, 1, 0);
    //        }

    //    }
    //    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
    //    {
    //        if (CanMove(MoveDirection.Down))
    //        {
    //            //moveTurn = false;
    //            transform.position += new Vector3(0, -1, 0);
    //        }
    //    }
    //    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
    //    {
    //        if (CanMove(MoveDirection.Right))
    //        {
    //            //moveTurn = false;
    //            transform.position += new Vector3(1, 0, 0);
    //        }
    //    }
    //    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
    //    {
    //        if (CanMove(MoveDirection.Left))
    //        {
    //            //moveTurn = false;
    //            transform.position += new Vector3(-1, 0, 0);
    //        }
    //    }
    //}

    public bool CheckMoveInput()
    {
        //  Skip turn function
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return true;

        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (CanMove(MoveDirection.Up))
            {
                //moveTurn = false;
                transform.position += new Vector3(0, 1, 0);
                return true;
            }

        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (CanMove(MoveDirection.Down))
            {
                //moveTurn = false;
                transform.position += new Vector3(0, -1, 0);
                return true;
            }
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (CanMove(MoveDirection.Right))
            {
                //moveTurn = false;
                transform.position += new Vector3(1, 0, 0);
                return true;
            }
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (CanMove(MoveDirection.Left))
            {
                //moveTurn = false;
                transform.position += new Vector3(-1, 0, 0);
                return true;
            }
        }
        return false;
    }


    bool CanMove(MoveDirection moveDirection)
    {
        Tile[,] mapTiles = mapScript.GetMap();

        switch (moveDirection)
        {
            case MoveDirection.Up:
                if (mapTiles[(int)transform.position.x, (int)transform.position.y].CheckPaths(0))
                {
                    Debug.Log("Passed if it can leave up");
                    if (transform.position.y + 1 <= mapScript.MapDepth)
                        if (mapTiles[(int)transform.position.x, (int)transform.position.y + 1].CheckPaths(2))
                        {

                            Debug.Log("Passed if it can enter from below");
                            return true;
                        }
                    Debug.Log("Failed can enter from below");
                }
                break;
            case MoveDirection.Down:
                if (mapTiles[(int)transform.position.x, (int)transform.position.y].CheckPaths(2))
                {
                    Debug.Log("Passed if it can leave Down");
                    if (transform.position.y - 1 >= 0)
                        if (mapTiles[(int)transform.position.x, (int)transform.position.y - 1].CheckPaths(0))
                        {

                            Debug.Log("Passed if it can enter from above");
                            return true;
                        }
                    Debug.Log("Failed can enter from above");
                }
                break;
            case MoveDirection.Right:
                if (mapTiles[(int)transform.position.x, (int)transform.position.y].CheckPaths(1))
                {
                    Debug.Log("Passed if it can leave right");
                    if (transform.position.x + 1 <= mapScript.MapWidth)
                        if (mapTiles[(int)transform.position.x + 1, (int)transform.position.y].CheckPaths(3))
                        {

                            Debug.Log("Passed if it can enter from left");
                            return true;
                        }
                    Debug.Log("Failed can enter from left");
                }
                break;
            case MoveDirection.Left:
                if (mapTiles[(int)transform.position.x, (int)transform.position.y].CheckPaths(3))
                {
                    Debug.Log("Checked if it can leave left");
                    if (transform.position.x - 1 >= 0)
                        if (mapTiles[(int)transform.position.x - 1, (int)transform.position.y].CheckPaths(1))
                        {
                            Debug.Log("Checked if it can enter from right");
                            return true;
                        }
                }
                break;
        }

        return false;
    }



    public bool PlayerTurn
    {
        get { return playerTurn; }
        set { playerTurn = value;  }
    }

}
