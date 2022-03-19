using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{

    [SerializeField]
    Button Level2Button;

    private bool isLevel2Playable;
    public bool IsLevel2Playable {
        get 
        {
            return IsLevel2Playable;
        }
        set 
        {
            isLevel2Playable = value;
            Level2Button.interactable = value;
        }
    }
    public void LoadLevel(string Level)
    {
        SceneManager.LoadScene(Level);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }
}
