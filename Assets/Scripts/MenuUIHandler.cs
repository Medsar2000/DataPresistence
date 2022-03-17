using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI hiScoreText;
   // public string PlayerNameInput;
    // Start is called before the first frame update
    void Start()
    {
        if (SaveManager.Instance != null)
        {
            SaveManager.Instance.LoadHighScore();
            hiScoreText.text = "Best Score : " + SaveManager.Instance.HighPlayerName + " : " + SaveManager.Instance.HighScore.ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startNew()
    {
        if (SaveManager.Instance != null)
            SaveManager.Instance.LoadHighScore();
            SceneManager.LoadScene(1);
       
    }
    public void GetPlayerNameString(string s)
    {
        //PlayerNameInput = s;
        if (SaveManager.Instance != null)
            SaveManager.Instance.currentPlayerName = s;
        Debug.Log(SaveManager.Instance.currentPlayerName);

    }
}
