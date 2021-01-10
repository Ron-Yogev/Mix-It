using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsOnClick : MonoBehaviour
{

    [SerializeField] Texture2D pointercurser = null;
    [SerializeField] GameObject volume_manager = null;
    bool volume_slide = false;

    // Start is called before the first frame update
    void Start()
    {
        int h = pointercurser.height;
        int w = pointercurser.width;
        Vector2 tmp = new Vector2(w * 0.2f, h * 0.2f);
        Cursor.SetCursor(pointercurser, tmp, CursorMode.ForceSoftware);
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

    public void openVolumeManager()
    {
        if (!volume_slide)
        {
            volume_manager.SetActive(true);
            volume_slide = true;
        }
        else
        {
            volume_manager.SetActive(false);
            volume_slide = false;
        }
    }

}
