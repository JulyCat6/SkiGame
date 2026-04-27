using Unity.VisualScripting;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public DateTime raceStart;
    private TimeSpan raceTime;
    private bool racing;
    public delegate void TimerEvent();
    
    private void OnEnable()
    {
        StartGate.StartRace += OnRaceStart;
        FinishGate.FinishRace += OnRaceEnd;
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
        Debug.Log("Race ended");
    }

    private void Update()
    {
        if(racing)
            raceTime = DateTime.Now - raceStart;
        Debug.Log("Race time " + raceTime);
    }
}
