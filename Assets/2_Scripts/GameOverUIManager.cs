using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private Text scoreText;

    public static GameOverUIManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public void ShowGameOver(float timeRemaining)
    {
        gameOverCanvas.SetActive(true);
        int deliveryScore = ScoreManager.Instance.GetScore();
        int timeBonus = Mathf.FloorToInt(timeRemaining) * 10;
        int totalScore = deliveryScore + timeBonus;
        scoreText.text = $"Delivery Score: {deliveryScore}\nBonus: {timeBonus}\nFinal Score: {totalScore}";
        //scoreText.text = "Final Score: " + score + "Jum";
        Time.timeScale = 0f; // 게임 정지
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
