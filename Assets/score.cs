using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{

    public Transform player;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        // Check if the game has ended. If it has, stop updating the score.
        if (FindObjectOfType<GameManager>().gameHasEnded)
        {
            return;
        }

        scoreText.text = player.position.z.ToString("0");
    }
}