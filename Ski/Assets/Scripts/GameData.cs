using UnityEngine;
using System.Collections.Generic;

public class GameData : MonoBehaviour
{
    private static GameData instance; // var tikt no jebkura scripta 
    public List<float> bestTimes = new List<float>(); // List ladējas lenāk, var izmentot "public float[] bestTimeArray;"
    public static GameData Instance
    {
        get { return instance; }
    }
    public string leaderboardKey = "LVL1-";

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //Neiznicina objektu, glaba piem laiku
        }
        LoadLeaderboard();
    }

    void LoadLeaderboard()
    {
        for (int i = 0; i < 5; i++)
        {
            float time = PlayerPrefs.GetFloat(leaderboardKey + i,999.99f);
            bestTimes.Add(time);
        }
    }

    void SaveLeaderboard()
    {
        for (int i = 0; i < 5; i++)
        {
            if(bestTimes.Count >= i)
                PlayerPrefs.SetFloat(leaderboardKey + i,bestTimes[i]);
        }
    }

    public void AddTime(float time)
    {
        bestTimes.Add(time);
        bestTimes.Sort();
        SaveLeaderboard();
    }
}
