using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup screenOverlay;
    [SerializeField] private float fadeSpeed = 2;
    [SerializeField] private GameObject raceOverPanel;
    [SerializeField] private int nextLevelIndex = 1;
    [SerializeField] private TMP_Text LeaderTimeText;
    [SerializeField] private TMP_Text GameTimeText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        screenOverlay.gameObject.SetActive(true);
        raceOverPanel.SetActive(false);
        StartCoroutine(FadeOutOverlay());
    }

    private void OnEnable()
    {
        FinishGate.FinishRace += OnRaceFinished;
    }

    private void OnDisable()
    {
        FinishGate.FinishRace -= OnRaceFinished;
    }

    private void OnRaceFinished()
    {
        raceOverPanel.SetActive(true);
        UpdateLeaderTimeUI();
        UpdateGameTimeUI();
    }

    private IEnumerator FadeOutOverlay()
    {
        while (screenOverlay.alpha > 0)
        {
            screenOverlay.alpha -= fadeSpeed * Time.deltaTime;
            yield return null;
        }
    }
    
    private IEnumerator FadeInOverlay()
    {
        while (screenOverlay.alpha < 1)
        {
            screenOverlay.alpha += fadeSpeed * Time.deltaTime;
            yield return null;
        }
    }

    public void Restart()
    {
        StartCoroutine(RestartCoroutine());
    }

    private IEnumerator RestartCoroutine()
    {
        Debug.Log("Restart");
        yield return StartCoroutine(FadeInOverlay());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void NextLevel()
    {
        StartCoroutine(NextLevelCoroutine());
    }

    private IEnumerator NextLevelCoroutine()
    {
        yield return StartCoroutine(FadeInOverlay());
        SceneManager.LoadScene(nextLevelIndex);
    }
    
    public void Quit()
    {
        StartCoroutine(QuitCoroutine());
    }

    private IEnumerator QuitCoroutine()
    {
        yield return StartCoroutine(FadeInOverlay());
        Application.Quit();
    }

    private void UpdateLeaderTimeUI()
    {
        if (GameData.Instance == null) return;

        List<float> times = GameData.Instance.bestTimes;

        string text = "TOP PLAYERS\n\n";

        int count = Mathf.Min(3, times.Count);

        for (int i = 0; i < count; i++)
        {
            float t = times[i];
            text += $"{i + 1}. Player - {t:F2}s\n";
        }

        LeaderTimeText.text = text;
    }

    private void UpdateGameTimeUI()
    {
        if (GameData.Instance == null) return;
        float time = GameData.Instance.GameTime;
        GameTimeText.text = "Time Race : " + time.ToString("F2") + "s";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
