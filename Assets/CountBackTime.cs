﻿using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        total_sec = minutes * 60 + seconds;
    }

    private void Update()
    {
        float t = Time.time - startTime;
        int time_left = total_sec - (int)t;
        if (time_left >= 0)
        {
            string seconds = ((time_left) % 60).ToString("f0");
            string minutes = (time_left / 60).ToString();

            if (int.Parse(minutes) < 10) minutes = "0" + minutes;
            if (int.Parse(seconds) < 10) seconds = "0" + seconds;

            text.text = minutes + ":" + seconds;
        }
    }
}
