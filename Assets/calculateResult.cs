using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class calculateResult : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score_txt = null;
    [SerializeField] List<Renderer> rend_3d = null;
    [SerializeField] List<SpriteRenderer> rend_2d = null;
    [SerializeField] int size = 0;
    [SerializeField] const int MAX_SCORE = 100;
    

    private float score = MAX_SCORE;


    public int getScore()
    {
        score = MAX_SCORE;
        float decrease = size * 765 / MAX_SCORE;
        float R = 0, G = 0, B = 0;
        for (int i = 0; i < size; i++)
        {
            R = Mathf.Abs(rend_3d[i].material.color.r - rend_2d[i].color.r)*255;
            G = Mathf.Abs(rend_3d[i].material.color.g - rend_2d[i].color.g)*255;
            B = Mathf.Abs(rend_3d[i].material.color.b - rend_2d[i].color.b)*255;
            float err = R + G + B;
            score -= err / decrease;
            
        }
        return (int)score;
    }

    public void setScore()
    {
        score_txt.SetText("Your score is :" + getScore());
    }
}
