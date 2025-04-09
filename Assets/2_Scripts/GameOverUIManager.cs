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
        scoreText.text = "���� ����: " + score + "��";
        Time.timeScale = 0f; // ���� ����
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
