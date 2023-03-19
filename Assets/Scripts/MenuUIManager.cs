using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{

    [SerializeField] private TMPro.TMP_InputField inputField;
    private Button startButton;

    private void Awake() {
        inputField = FindObjectOfType<TMPro.TMP_InputField>();
        startButton = GameObject.Find("StartButton").GetComponent<Button>();
    }

    public void EnableButton()
    {
        if(inputField.text.ToString() != "")
        {
            startButton.interactable = true;
            PlayerManager.Instance.PlayerName = inputField.text;
        }
    }

    public void GameStart()
    {
        SceneManager.LoadScene("main");
    }

    
}
