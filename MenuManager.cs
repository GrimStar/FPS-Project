using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour {

    [SerializeField]
    GameObject mainMenu;
    string MainMenuScene = "MainMenu";
    [SerializeField]
    GameObject pauseMenu;
    string PauseMenuScene = "Main";
    [SerializeField]
    GameObject instructionsMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            OpenPauseMenu();
            
            
        }
	}
    public void OpenPauseMenu()
    {
        
        if (SceneManager.GetActiveScene().name == MainMenuScene)
        {
            if (instructionsMenu.activeSelf)
            {
                instructionsMenu.SetActive(false);
                
            }
            
            mainMenu.SetActive(true);
            
        }
        if (SceneManager.GetActiveScene().name == PauseMenuScene)
        {
            
            if (pauseMenu.activeSelf)
            {
                if (!LevelControl.instance.gameOver && !LevelControl.instance.endOfLevel)
                {
                    pauseMenu.SetActive(false);
                    Time.timeScale = 1;
                }
                
            }
            else
            {
                if (instructionsMenu.activeSelf)
                {
                    
                    instructionsMenu.SetActive(false);
                    
                }

                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
               
            }
        }
        

    }
    public void ClickPlay()
    {
        if(SceneManager.GetActiveScene().name == MainMenuScene)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Main");
        }
    }
    public void ClickInstructions()
    {
        
        if (SceneManager.GetActiveScene().name == MainMenuScene)
        {
            mainMenu.SetActive(false);
            instructionsMenu.SetActive(true);
            
        }
        if (SceneManager.GetActiveScene().name == PauseMenuScene)
        {

            pauseMenu.SetActive(false);
            instructionsMenu.SetActive(true);
            
        }
    }
    public void ClickExit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
    public void ClickMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void ClickRestart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
