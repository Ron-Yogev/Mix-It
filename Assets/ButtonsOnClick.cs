using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsOnClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void startGame()
    {
        SceneManager.LoadScene("TreeLevel");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
