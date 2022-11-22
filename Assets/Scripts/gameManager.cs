using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    
    [SerializeField] Text score;
    [SerializeField] Text timer;
    [SerializeField] GameObject endUI;
    [SerializeField] Text endText;
    [SerializeField] RectTransform rectTransfo;
    [SerializeField] float timeRemaining = 60;
    [SerializeField] Image blur;
    [SerializeField] int BombPoint = -50;
    [SerializeField] int FishPoint = 20;
    [SerializeField] float respawnTimer = 2f;
    [SerializeField] InputField playerName;


    private int Score = 0;
    private float TimeTop = 0;
    private bool IsSpeedUp = false;
    private HighScoreTable HighScoreTable;
    
    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        
    }
    void Start()
    {
        Time.timeScale = 1;
        blur.DOFade(1, 0.5f).SetLoops(-1, LoopType.Yoyo).SetId("blurEffect");
        rectTransfo.DOScale(1.1f,0.5f).SetLoops(-1,LoopType.Yoyo).SetId("timeBump");
        
    }
    public float getRespawnTimer()
    {
        return respawnTimer;
    }
    public int getBombPoint()
    {
        return BombPoint;
    }public int getFishPoint()
    {
        return FishPoint;
    }
    public int getScore()
    {
        return Score;
    }
    public void setScore(int newScore)
    {
       Score = Math.Clamp(newScore,0,99999);
       score.text = Score.ToString();
    }
    public float getTime()
    {
        return TimeTop;
    }
    public void setTime(float newTime)
    {
        TimeTop = Math.Clamp(newTime, 0, 99999);
        double timetemp = System.Math.Round(TimeTop, 1);
        timer.text = "Time : " + timetemp.ToString();
    }
    void SpeedUp()
    {
        DOTween.Play("blurEffect");
        DOTween.Play("timeBump");
        IsSpeedUp = true;
        FishPoint = FishPoint * 2;
        respawnTimer = 1;
        
    }
    void End()
    {      
        Time.timeScale = 0;
        
        endUI.SetActive(true);
        endText.text = "Your Score\n\n" + Score.ToString(); 
    }
    public  void Restart()
    {
        ;
        HighScoreTable.AddHighscoreEntry(Score, playerName.text);
        SceneManager.LoadScene("Menu");  
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            setTime(timeRemaining);
            if (timeRemaining < 10 && !IsSpeedUp)
            {         
                    SpeedUp();
            }
        }
        
        else
        {
            End();
            timeRemaining = 0;
        }
        

    }
}
