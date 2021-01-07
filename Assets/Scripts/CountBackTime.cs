using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountBackTime : MonoBehaviour
{
    [SerializeField] int minutes = 1;
    [SerializeField] int seconds = 30;
    [SerializeField]
    TMP_Text text;
    int total_sec;
    private float startTime;
    private bool running = true;
    calculateResult showScore;

    // Start is called before the first frame update
    void Start()
    {
        //initializing the class fields
        running = true;
        startTime = Time.time;
        total_sec = minutes * 60 + seconds;// casting the time to seconds
        showScore = GameObject.FindGameObjectWithTag("final_score").GetComponent<calculateResult>();
    }

    /*
     * Function that caculate The seconds that have passed since the start of the game and show the clock text 
     */
    private void Update()
    {
        float t = Time.time - startTime;
        int time_left = total_sec - (int)t;
        if (time_left >= 0 && running)
        {
            string seconds = ((time_left) % 60).ToString("f0");
            string minutes = (time_left / 60).ToString();

            if (int.Parse(minutes) < 10) minutes = "0" + minutes;
            if (int.Parse(seconds) < 10) seconds = "0" + seconds;

            text.text = minutes + ":" + seconds;
        }
        // if the time is over - show the score to the player
        else
        {
            running = false;
            showScore.setScore();
            
        }
    }

    /*
     * Function that returns if the game is running
     */
    public bool isRunning()
    {
        return running;
    }

    /*
     * Function that assign false to running field
     */
    public void setNoRunning()
    {
        running = false;
    }
}
