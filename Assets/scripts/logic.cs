using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class logic : MonoBehaviour
{
    public TextMeshProUGUI canvas;
    public int score;
    public GameObject screen;

    public void addPoint()
    {
        score++;
        canvas.text = score.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        screen.SetActive(true);
    }

}