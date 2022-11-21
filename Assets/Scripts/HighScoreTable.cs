using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;
    private void Awake()
    {
        
        entryContainer = transform.Find("HighScoreContainer");
        entryTemplate = entryContainer.Find("HighScoreEntry");
        
        entryTemplate.gameObject.SetActive(false);
        
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        
        for(int i = 0; i < highscores.highscoreEntriesList.Count; i++)
        {
            for(int j = i + 1; j < highscores.highscoreEntriesList.Count; j++)
            {
                if(highscores.highscoreEntriesList[j].score > highscores.highscoreEntriesList[i].score)
                {
                    HighscoreEntry tmp = highscores.highscoreEntriesList[i];
                    highscores.highscoreEntriesList[i]= highscores.highscoreEntriesList[j];
                    highscores.highscoreEntriesList[j] = tmp;
                }
            }
        }
        highscoreEntryTransformList = new List<Transform>();
        foreach(HighscoreEntry highscoreEntry in highscores.highscoreEntriesList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
       


    }
    private void CreateHighscoreEntryTransform(HighscoreEntry highscore, Transform container, List<Transform> transformList)
    {
        float templateHeight = 100f;

        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default: rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ST"; break;
            case 3: rankString = "3ST"; break;
        }

        entryTransform.Find("posText").GetComponent<Text>().text = rankString;

        int score = highscore.score
        ; entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        string name = highscore.name;

        entryTransform.Find("nameText").GetComponent<Text>().text = name;
        transformList.Add(entryTransform);
    }

    public static void AddHighscoreEntry(int score, string name)
    {//create highscore entry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name=name};

        //load saved highscore
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        //add new entry
        highscores.highscoreEntriesList.Add(highscoreEntry);
        //savced new entry
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }
    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntriesList;        
    }
    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
}
