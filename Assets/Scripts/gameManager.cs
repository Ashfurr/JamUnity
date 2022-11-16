using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.Timers;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    
    [SerializeField] GameObject score;
    [SerializeField] GameObject timer;
    //[SerializeField] GameObject fish;

    private int Score = 0;
    private float TimeTop = 0;
    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }
    void Start()
    {
            
        
        
            
        
        // Instantiate(fish, new Vector3(this.transform.position.x, this.transform.position.y + 0.5f, this.transform.position.z), Quaternion.identity);

    }
    public int getScore()
    {
        return Score;
    }
    public void setScore(int newScore)
    {
       Score = Math.Clamp(newScore,0,99999);
       score.GetComponent<Text>().text = Score.ToString();
    }
    public float getTime()
    {
        return TimeTop;
    }
    public void setTime(float newTime)
    {
        TimeTop = Math.Clamp(newTime, 0, 99999);
        double timetemp = System.Math.Round(TimeTop, 1);
        timer.GetComponent<Text>().text = "Time : " + timetemp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
