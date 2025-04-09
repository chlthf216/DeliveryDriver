using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLimit = 30f; // 제한 시간 (초 단위)
    private float timeRemaining;
    public Text timerText; // UI 텍스트에 시간 표시

    private bool isRunning = true;

    public static Timer Instance;

   

    void Awake()
    {
        Instance = this;
    }

    // 타이머 강제 종료 함수
    public void ForceEnd()
    {
        timeRemaining = 0;
        isRunning = false;
        GameOver();
    }

    public GameOverUIManager gameOverUI;
    public int currentScore = 0; // 배달마다 200점씩 올릴 때 여기 증가

    void GameOver()
    {
        Debug.Log("시간 초과! 게임 오버!");
        gameOverUI.ShowGameOver(currentScore);
    }

    void Start()
    {
        timeRemaining = timeLimit;
    }

    void Update()
    {
        if (isRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                isRunning = false;
                GameOver();
            }
        }
    }
    void UpdateTimerDisplay(float time)
    {
        time = Mathf.Clamp(time, 0, Mathf.Infinity);
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (time < 10f)
        {
            timerText.color = Color.red;
        }
        else
        {
            timerText.color = Color.white;
        }
    }

}

