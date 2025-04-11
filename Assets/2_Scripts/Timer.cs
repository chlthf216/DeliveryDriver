using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLimit = 30f; // 제한 시간 (초 단위)
    private float timeRemaining;
    public Text timerText;

    private bool isRunning = true;
    public static Timer Instance;

    void Awake()
    {
        Instance = this;
    }

    public void ForceEnd()
    {
        isRunning = false;
        Debug.Log($"[ForceEnd] timeRemaining: {timeRemaining}");
        GameController.Instance.GameOver(timeRemaining);
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
                ForceEnd(); // << 여기로 교체!
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

