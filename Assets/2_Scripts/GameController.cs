using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public GameObject gameOverPanel;
    public Text finalScoreText;
    public int totalCustomers = 7;
    private int servedCustomers = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void CustomerServed()
    {
        servedCustomers++;
        Debug.Log($"[GameController] 배달된 손님 수: {servedCustomers}");

        if (servedCustomers >= totalCustomers)
        {
            Debug.Log("[GameController] 모든 고객 배달 완료. ForceEnd 호출");
            Timer.Instance.ForceEnd();
        }
    }

    public void GameOver(float timeRemaining)
    {
        Debug.Log($"[GameController.GameOver] 호출됨. 남은 시간: {timeRemaining}");

        if (GameOverUIManager.Instance != null)
        {
            GameOverUIManager.Instance.ShowGameOver(timeRemaining);
        }
        else
        {
            Debug.LogError("GameOverUIManager.Instance is NULL!");
        }
    }
}
