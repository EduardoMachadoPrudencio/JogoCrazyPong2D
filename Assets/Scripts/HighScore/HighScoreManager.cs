using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
  
    public static HighScoreManager Instance;

    public string keyToSave = "keyhighscore";

    [Header("References")]

    public TextMeshProUGUI uiTextHighScore;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        uiTextHighScore.text = PlayerPrefs.GetString(keyToSave, "Sem highscore");
    }
    public void SavePlayerWin(Player p)
    {
        PlayerPrefs.SetString(keyToSave, p.playerName);
        UpdateText();
    }
}
