using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    [SerializeField] GameObject creatorsTxt = null;
    [SerializeField] GameObject menuButton = null;

    // Start is called before the first frame update
    void Start()
    {
        creatorsTxt.SetActive(false);
        menuButton.SetActive(false);
        SoundManagerScript.PlaySound("crowd_panik");
        StartCoroutine(wait3Sec());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("Menu");

    }

    private IEnumerator wait3Sec()
    {
        yield return new WaitForSeconds(3);
        creatorsTxt.SetActive(true);
        menuButton.SetActive(true);

    }
}
