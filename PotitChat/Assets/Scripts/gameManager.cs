using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    
    [SerializeField] GameObject ui;
    private int Score = 0;

    void Start()
    {

    }
    public int getScore()
    {
        return Score;
    }
    public void setScore(int newScore)
    {
       Score = Math.Clamp(newScore,0,99999);
       ui.GetComponent<Text>().text = "Score : "+Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
