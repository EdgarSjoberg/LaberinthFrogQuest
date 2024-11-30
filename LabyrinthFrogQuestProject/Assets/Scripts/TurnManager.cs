using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TurnState { START, PLAYERTURN_LABYRINTH, PLAYERTURN_MOVE, LABYRINTHTURN, END}

public class TurnManager : MonoBehaviour
{
 
    //  Needs a reference to:
    //  1. The map (tiles)
    //  2. Player
    //  3. Something to manage effects?
    

    public TurnState state;

    public int numTurns;

    public bool playerActed = false;
    public bool playerMoved = false;
    public bool won = false;

    [SerializeField]
    MapScript mapScript;

    [SerializeField]
    Camera maincamera;

    [SerializeField]
    CharacterScript player;


    //[SerializeField] List<Tile> tileList = new List<Tile>();
    [SerializeField] Vector2 mapSize = new Vector2(2,2);

    void Start()
    {
        numTurns = 0;
        
        state = TurnState.START;
        StartCoroutine(SetupGame());
        //  Initialising the game information

    }

    IEnumerator SetupGame()
    {
        //  Set up visuals and tile information
        //  
        mapScript.ChangeDimensions((int)mapSize.x, (int)mapSize.y);

        mapScript.CreateMap();
        mapScript.DrawMap();
        
        CenterCamera();

        yield return new WaitForSeconds(1f);

        state = TurnState.PLAYERTURN_LABYRINTH;
        PlayerTurn();

    }

    public void PlayerTurn()
    {
        numTurns++;
        playerActed = false;
        playerMoved = false;

        player.PlayerTurn = true;

        //  await input to begin PlayerLabyrinthAction, moving a row/column of the labyrinth
        //  before being able to move the character.

        //  Eventual dialog here?
        //  Some sort of check perhaps to ensure the player cant act more than once?
        //  Choosing action based on mouse input

    }

    IEnumerator PlayerLabyrinthAction()
    {

        //  If the tile clicked on is within movement range, check if its a valid move
        //  If it isn't a valid move, let the player make a new choice
        //  If it is a valid move, the move is made and then the turn is shifted to LabyrinthTurn

        yield return new WaitForSeconds(1f);

        //  A check to see if the player has acquired the 'objective', potentially ending the game
        //  Otherwise it continues on

        //  ONLY ONCE A VALID MOVE IS MADE SHOULD THE 'playerActed' BOOL BE MADE TRUE!
        playerActed = true;

        state = TurnState.PLAYERTURN_MOVE;
        StartCoroutine (PlayerMove());

    }

    IEnumerator PlayerMove()
    {
        //  Check if move is valid. If player already moved, don't execute another move (see playerMoved bool)
        //  If yes: execute the move
        //  if no: dont do anything and wait for valid input

        yield return new WaitForSeconds(1f);

        playerMoved = true;

        //  

        if (won)
        {
            state = TurnState.END;
            EndGame();
        }
        else
        {

            state = TurnState.LABYRINTHTURN;
            StartCoroutine(LabyrinthTurn());
        }
    }



    IEnumerator LabyrinthTurn()
    {
        //  take into account the player's last move before making its own!
        //  Potential for moving enemies around during this phase.
        //  Pick a column or row entrypoint and begin a move all along that.

        yield return new WaitForSeconds(1f);

        state = TurnState.PLAYERTURN_LABYRINTH;
        PlayerTurn();

    }

    public void EndGame()
    {
        //  ITS SO JOEVER

        //  Display how many turns it took the player to finish the game
        //  Funny visuals and dialog from our little frog lad?

        //  Potential to start a new game, if we have the time
    }

    public void CenterCamera()
    {
        Vector3 newVector = mapScript.Center();
        newVector.z = -10;

        maincamera.GetComponent<Transform>().position = newVector;


    }




}
