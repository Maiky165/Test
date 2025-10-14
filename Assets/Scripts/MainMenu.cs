using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Loads the "Game" Scene (starts the game)
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }
    
    //closes the game
    //doesn't work in the editor (Log for checking)
    public void QuitGame()
    {
        Debug.Log("Game got closed");
        Application.Quit();
    }
}
