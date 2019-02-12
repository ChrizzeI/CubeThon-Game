using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameHasEnded = false;

    public float restartDelay = 1f;

    public GameObject completeLevelUI;

    // function that will trigger whenever we complete a Level
    public void CompleteLevel ()
    {
        completeLevelUI.SetActive(true);
    }

    public void EndGame()
    {
        // Ensures The Game does only end once
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            // Build in a small delay before the game resets
            Invoke("Restart", restartDelay);
        }
    }

    // Restart Game
    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
