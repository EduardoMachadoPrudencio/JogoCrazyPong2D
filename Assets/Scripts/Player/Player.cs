using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
  public float speed = 10;

    public int maxPoints = 5;

    public string playerName = "";

    public Image uiPlayer;


    [Header("Key Setup")]

    public KeyCode KeyCodeMoveUp = KeyCode.UpArrow;
    public KeyCode KeyCodeMoveDown = KeyCode.DownArrow;

    public Rigidbody2D myRigidbody2D;

    [Header("Points")]

    public int currentPoints = 0;
    public TextMeshProUGUI uiTextPoints;
    public TextMeshProUGUI uiTextWinner;
    

    

    public Vector2 _initialPosition;

    private void Awake()
    {
        _initialPosition = transform.position;
        ResetPlayer();
        
    }

   public void SetName(string s)
    {
        playerName = s;
        UpdateUI();
    }

   

    public void ResetPlayer()
    {
        currentPoints = 0;
        transform.position = _initialPosition;
        UpdateUI();
    }
    void Update()
    {
        if (Input.GetKey(KeyCodeMoveUp))
            myRigidbody2D.MovePosition(transform.position + transform.up * speed);
        // transform.Translate(transform.up * speed);
        else if (Input.GetKey(KeyCodeMoveDown))
            myRigidbody2D.MovePosition(transform.position + transform.up * -speed);
        //transform.Translate(transform.up * speed * -1);
    }

    public void AddPoint()
    {
        CheckMaxPoints();
        currentPoints++;
        UpdateUI();
    }

    public void ChangeColor(Color c)
    {
        uiPlayer.color = c;
    }
    private void UpdateUI()
    {
        uiTextPoints.text = playerName + " : " + currentPoints.ToString();
    }

    public void PlayerWinner()
    {
        uiTextWinner.text = "VENCEDOR: " + playerName + (" WIN!");
        UpdateUI();
    }


    private void CheckMaxPoints()
    {
        if (currentPoints >= maxPoints)
        {
            GameManager.Instance.EndGame();
            HighScoreManager.Instance.SavePlayerWin(this);
            PlayerWinner();
            
            
        }
    }

   
}
