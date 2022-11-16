using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeNameBase : MonoBehaviour
{
    [Header("References")]

    public TextMeshProUGUI uiTextName;
    public TMP_InputField uiInputField;
    public GameObject changeNameInput;
    public Player player;

    public string nameOfPlayer;





    // Start is called before the first frame update
    void Start()
    {
        
    }

public void ChangeName()
    {
        nameOfPlayer = uiInputField.text;
        uiTextName.text = nameOfPlayer;
        changeNameInput.SetActive(false);
        player.SetName(nameOfPlayer);
    }  
}
