using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;
    public GameObject gameOverUI;

    void Update()
    {
        // Restart anytime 'R' is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");

            if (gameOverUI != null)
            {
                gameOverUI.SetActive(true);
            }
        }
    }

    public void Restart()
    {
        // Reloads the current scene, resetting player position and score
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}