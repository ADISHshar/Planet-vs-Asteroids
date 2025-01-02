using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Function to load the Game scene
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    // Function to exit the game
    public void ExitGame()
    {
        Debug.Log("Exiting Game..."); 
        Application.Quit();
    }
}
