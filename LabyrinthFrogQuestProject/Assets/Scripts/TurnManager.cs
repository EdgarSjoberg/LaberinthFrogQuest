using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TurnState { START, PLAYERTURN, LABYRINTHTURN, END}

public class TurnManager : MonoBehaviour
{
 
    //  Needs a reference to:
    //  1. The map (tiles)
    //  2. Player
    //  3. Something to manage effects?
    

    public TurnState state;

    public int numTurns;

    public bool playerActed = false;
    public bool won = false;

    void Start()
    {
        numTurns = 0;
        state = TurnState.START;
        //  StartCoRoutine(SetupGame());
        //  Initialising the game information

    }

    IEnumerator SetupGame()
    {
        //  Set up visuals and tile information
        //  

        yield return new WaitForSeconds(1f);

        state = TurnState.PLAYERTURN;
        //PlayerTurn();


    }

    public void PlayerTurn()
    {
        numTurns++;
        playerActed = false;

        //  Eventual dialog here?
        //  Some sort of check perhaps to ensure the player cant act more than once?
        //  Choosing action based on mouse input

    }

    IEnumerator PlayerClick()
    {

        //  If the tile clicked on is within movement range, check if its a valid move
        //  If it isn't a valid move, let the player make a new choice
        //  If it is a valid move, the move is made and then the turn is shifted to LabyrinthTurn

        yield return new WaitForSeconds(1f);

        //  A check to see if the player has acquired the 'objective', potentially ending the game
        //  Otherwise it continues on

        //  ONLY ONCE A VALID MOVE IS MADE SHOULD THE 'playerActed' BOOL BE MADE TRUE!
        playerActed = true;

        if(won)
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

        state = TurnState.PLAYERTURN;
        PlayerTurn();

    }

    public void EndGame()
    {
        //  Display how many turns it took the player to finish the game
        //  Funny visuals and dialog from our little frog lad?

        //  Potential to start a new game, if we have the time
    }




}
