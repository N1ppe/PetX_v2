using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class titleButtons : MonoBehaviour {

    public GameObject newgame_window,settings_window,quit_Window;

	void Start ()
    {	
	}
	void Update ()
    {	
	}

    public void continueGame()
    {
        SceneManager.LoadScene(1);
    }
    //--------------------------------------------
    public void newGame()
    {
        newgame_window.SetActive(true);
    }
    public void newGameNO()
    {
        newgame_window.SetActive(false);
    }
    //--------------------------------------------
    public void settings()
    {
        settings_window.SetActive(true);
    }
    public void settingsNO()
    {
        settings_window.SetActive(false);
    }
    //--------------------------------------------
    public void quit()
    {
        quit_Window.SetActive(true);
    }
    public void quitYES()
    {

    }
    public void quitNO()
    {
        quit_Window.SetActive(false);
    }
}
