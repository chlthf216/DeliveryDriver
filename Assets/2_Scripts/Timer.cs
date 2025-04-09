using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLimit = 30f; // ���� �ð� (�� ����)
    private float timeRemaining;
    public Text timerText; // UI �ؽ�Ʈ�� �ð� ǥ��

    private bool isRunning = true;

    public static Timer Instance;

   

    void Awake()
    {
        Instance = this;
    }

    // Ÿ�̸� ���� ���� �Լ�
    public void ForceEnd()
    {
        timeRemaining = 0;
        isRunning = false;
        GameOver();
    }

    public GameOverUIManager gameOverUI;
    public int currentScore = 0; // ��޸��� 200���� �ø� �� ���� ����

    void GameOver()
    {
        Debug.Log("�ð� �ʰ�! ���� ����!");
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

