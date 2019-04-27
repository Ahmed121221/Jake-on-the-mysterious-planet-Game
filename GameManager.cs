using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum GameState
{
    menu,
    inGame,
    gameOver

}
public class GameManager : MonoBehaviour // control events in the game
{
    public static GameManager instance;
    public GameState currentGameState = GameState.menu;

    public Canvas menuCanvas;
    public Canvas inGameCanvas;
    public Canvas gameOverCanvas;


    public int collectedCoins = 0;




    void SetGameState(GameState newGameState)
    {

        if (newGameState == GameState.menu)
        {
            //setup scene for menu 
            menuCanvas.enabled = true;
            inGameCanvas.enabled = false;
            gameOverCanvas.enabled = false;
        }
        else if (newGameState == GameState.inGame)
        {
            //setup scene for  ingame 
            menuCanvas.enabled = false;
            inGameCanvas.enabled = true;
            gameOverCanvas.enabled = false;


        }
        else if (newGameState == GameState.gameOver)
        {
            //setuo scene for game over
            menuCanvas.enabled = false;
            inGameCanvas.enabled = false;
            gameOverCanvas.enabled = true;


        }

        currentGameState = newGameState;

    }

    //--------------------------------------------------------------------------

    void Awake()
    {

        instance = this;

    }
    void start()
    {
        currentGameState = GameState.menu;

    }

    void Update()
    {

        if (Input.GetButtonDown("s"))
        {
            StartGame();
        }

    }



    //---------------------------------------------------------------------------
    public void StartGame()
    {
        PlayerController.instance.StartGame();
        SetGameState(GameState.inGame);

    }


    public void gameOver()
    {

        SetGameState(GameState.gameOver);


    }
    public void BackToMenu()
    {
        SetGameState(GameState.menu);


    }
    public void CollectedCoin()
    {
        collectedCoins++;
    }
    


    //--------------------------------------------------------------------------
} //end of the class
