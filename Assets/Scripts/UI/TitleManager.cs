using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleManager : MonoBehaviour
{
    // Loads the main game scene
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
        SceneManager.UnloadScene("TitleScreen");
    }
}
