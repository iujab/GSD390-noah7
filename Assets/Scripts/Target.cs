using UnityEngine;

public class Target : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = Object.FindAnyObjectByType<GameManager>();
    }

    public void TakeHit()
    {
        if (gameManager != null)
        {
            gameManager.OnTargetDestroyed();
        }

        Destroy(gameObject); //Kill obj on one hit
    }
}