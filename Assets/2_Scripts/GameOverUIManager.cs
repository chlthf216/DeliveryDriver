using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private Text scoreText;

    public void ShowGameOver(int score)
    {
        gameOverCanvas.SetActive(true);
        scoreText.text = "최종 점수: " + score + "점";
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
