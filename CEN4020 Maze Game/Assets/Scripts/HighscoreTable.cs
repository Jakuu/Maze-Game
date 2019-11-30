/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class HighscoreTable : MonoBehaviour
{

    public Transform entryContainer;
    public Transform entryTemplate;
    public string tableName;
    public List<Transform> highscoreEntryTransformList;

    private void Awake()
    {
        updateTable();
    }


    public void ClearTable(List<Transform> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list.Remove(list[i]);
        }
    }


    public void updateTable()
    {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);



        string jsonString = PlayerPrefs.GetString(tableName);
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);


        if (highscores == null)
        {
            highscores = new Highscores()
            {
                highscoreEntryList = new List<HighscoreEntry>()
            };
            // There's no stored table, initialize
           //  Debug.Log("Initializing table with default value...");
             AddHighscoreEntry(-1, "---");
             // Reload
             jsonString = PlayerPrefs.GetString(tableName);
             highscores = JsonUtility.FromJson<Highscores>(jsonString);
         }


        // only keep the top ten
        if (highscores != null)
        {
            // Sort entry list by Score
            if (highscores.highscoreEntryList.Count > 1)
            {
                SortList(highscores);
            }

            int l = highscores.highscoreEntryList.Count - 1;

            // only > 10 here... not about to add another entry
            // compare to the add high score function, which needs >= 10
            while (highscores.highscoreEntryList.Count > 10)
            {
                Debug.Log("removing score");
                highscores.highscoreEntryList.Remove(highscores.highscoreEntryList[l--]);
            }

            highscoreEntryTransformList = new List<Transform>();
            foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
            {
                CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
            }
        }
        
        
    }

    private void SortList(Highscores highscores)
    {
        if (highscores.highscoreEntryList.Count > 1)
        {
            for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
            {
                for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
                {
                    if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                    {
                        // Swap
                        HighscoreEntry tmp = highscores.highscoreEntryList[i];
                        highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                        highscores.highscoreEntryList[j] = tmp;
                    }
                }
            }
        }
    }


    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 31f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("posText").GetComponent<Text>().text = rankString;

        int score = highscoreEntry.score;

        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<Text>().text = name;

        // Set background visible odds and evens, easier to read
        entryTransform.Find("background").gameObject.SetActive(rank % 2 == 1);

        // Highlight First
        if (rank == 1)
        {
            entryTransform.Find("posText").GetComponent<Text>().color = Color.green;
            entryTransform.Find("scoreText").GetComponent<Text>().color = Color.green;
            entryTransform.Find("nameText").GetComponent<Text>().color = Color.green;
        }

        // Set tropy
        switch (rank)
        {
            default:
                entryTransform.Find("trophy").gameObject.SetActive(false);
                break;
            case 1:
                entryTransform.Find("trophy").GetComponent<Image>().color = UtilsClass.GetColorFromString("FFD200");
                break;
            case 2:
                entryTransform.Find("trophy").GetComponent<Image>().color = UtilsClass.GetColorFromString("C6C6C6");
                break;
            case 3:
                entryTransform.Find("trophy").GetComponent<Image>().color = UtilsClass.GetColorFromString("B76F56");
                break;

        }

        transformList.Add(entryTransform);
    }

    public void AddHighscoreEntry(int score, string name)
    {
        // Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        // Load saved Highscores
        string jsonString = PlayerPrefs.GetString(tableName);
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
       
        if (highscores != null)
        {
            SortList(highscores);

            // score entry of -1 used to initialize
            // delete if it exists in the list
            for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
            {
                if (highscores.highscoreEntryList[i].score == -1)
                    highscores.highscoreEntryList.Remove(highscores.highscoreEntryList[i]);
            }

            // delete items if list is >= 10 --> only want the top ten scores (0 - 9)
            // need >= here because about to add another entry
            int l = highscores.highscoreEntryList.Count - 1;
            while (highscores.highscoreEntryList.Count >= 10)
            {
                Debug.Log("removing score");
                highscores.highscoreEntryList.Remove(highscores.highscoreEntryList[l--]);
            }

        }

        // There's no stored table, initialize
        else
        {
            highscores = new Highscores()
            {
                highscoreEntryList = new List<HighscoreEntry>()
            };
        }
     

        // Add new entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);

        // Sort entry list by Score
        if (highscores.highscoreEntryList.Count > 1)
        {
            SortList(highscores);
        }

        // Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString(tableName, json);
        PlayerPrefs.Save();

        // destroy existing gameobject entries
        foreach (Transform child in entryContainer)
        {
            if (child.CompareTag("highscoreEntryTemplate"))
            {
                if (child.gameObject.activeSelf == true)
                    Destroy(child.gameObject);
            }
            else
            {
                Debug.Log("not found");
            }
        }

        // clear the list
        highscoreEntryTransformList.Clear();

        foreach (HighscoreEntry entry in highscores.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(entry, entryContainer, highscoreEntryTransformList);
        }
    }




    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    /*
     * Represents a single High score entry
     * */
    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }

}
