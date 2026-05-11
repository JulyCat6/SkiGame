using Unity.VisualScripting;
using UnityEngine;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{
    public DateTime raceStart;
    private TimeSpan raceTime;
    private TimeSpan penaltyTime;
    private TimeSpan bestTime;
    private bool racing = false;
    public delegate void TimerEvent();
    [SerializeField] private int penaltyTimeVal = 3;
    [SerializeField] private TMP_Text raceTimeText, bestTimeText;
    [SerializeField] private string bestTimeKey = "LVL1BestTime";
    
    
    private void OnEnable()
    {
        StartGate.StartRace += OnRaceStart;
        FinishGate.FinishRace += OnRaceEnd;
        SlalomFlag.RacePenalty += AddRacePenalty;
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(bestTimeKey))
        {
            int bestTimeTicks = PlayerPrefs.GetInt(bestTimeKey);
            bestTime = new TimeSpan (bestTimeTicks);
            bestTimeText.text = "BEST TIME: " + bestTime.ToString("ss\\:ff");
        }
        else
        {
            bestTime = new TimeSpan(int.MaxValue);
            bestTimeText.text = "BEST TIME: --:--";
        }
        //PlayerPrefs.DeleteKey(bestTimeKey);
        //PlayerPrefs.DeleteAll();
    }

    void AddRacePenalty()
    {
        penaltyTime += new TimeSpan(0, 0, penaltyTimeVal);
    }

    void OnRaceStart()
    {
        racing = true;
        raceStart = DateTime.Now;
        Debug.Log("Race started");
    }

    void OnRaceEnd()
    {
        racing = false;
        if (raceTime < bestTime)
        {
            bestTime = raceTime;
            bestTimeText.text = "BEST TIME: " + bestTime.ToString("ss\\:ff");
            bestTimeText.color = Color.yellowNice;
            PlayerPrefs.SetInt(bestTimeKey, (int)bestTime.Ticks);
            PlayerPrefs.Save();
        }
    }

    private void Update()
    {
        if(racing)
            raceTime = DateTime.Now - raceStart + penaltyTime;
        //Debug.Log("Race time " + raceTime);
        raceTimeText.text = "Time:" +  raceTime.ToString("ss\\:ff");
    }
}
