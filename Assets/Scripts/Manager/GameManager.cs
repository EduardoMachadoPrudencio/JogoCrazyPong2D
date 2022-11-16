using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Player player1, player2;
    public BallBase ballBase;
    public StateMachine stateMachine;
    public static GameManager Instance;
    public float timeToSetBallFree = 1f;
   

    [Header("Menus")]

    public GameObject uiMainMenu;
    public GameObject uiEndGameMenu;

    private void Awake()
    {
        Instance = this;
        ballBase.ResetBall();
   
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
     
            EndGame();
            
        }

    }

    public void SwitchStateReset()
    {

        stateMachine.ResetPosition();
       
    }

    public void ResetBall()
    {
        ballBase.CanMove(false);
        ballBase.ResetBall();
        Invoke(nameof(SetBallFree), timeToSetBallFree);
    }

    private void SetBallFree()
    {
        ballBase.CanMove(true);
    }

    public void StartGame()
    {
        
        ballBase.CanMove(true);
       

    }

    public void EndGame()
    {
      
        stateMachine.SwitchState(StateMachine.States.END_GAME);
        ballBase.ResetBall();
        player1.ResetPlayer();
        player2.ResetPlayer();
        ballBase.CanMove(false);
      
    }

    public void ShowMainMenu()
    {
       GameManager.Instance.uiMainMenu.SetActive(true);

    }
}



