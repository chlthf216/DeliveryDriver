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
        if (servedCustomers >= totalCustomers)
        {
            Timer.Instance.ForceEnd(); // 타이머 강제 종료
        }
    }

    public void GameOver(float timeRemaining)
    {
        int deliveryScore = ScoreManager.Instance.GetScore();
        int timeBonus = Mathf.FloorToInt(timeRemaining) * 10;
        int totalScore = deliveryScore + timeBonus;

        gameOverPanel.SetActive(true);
        finalScoreText.text = $"배달 점수: {deliveryScore}\n보너스: {timeBonus}\n총점: {totalScore}";
    }
}
