using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text Text;

    public void GameOver()
    {
        Text.text = "GAME OVER";
        gameObject.SetActive(true);
    }

    public void Finish()
    {
        Text.text = "YOU WON";
        gameObject.SetActive(true);
    }

    public void Restart()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
