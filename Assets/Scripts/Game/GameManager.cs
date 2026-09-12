using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    private bool isGameActive;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI gameWonText;
    [SerializeField] private GameObject endButtons;
    private float timeLeftSeconds;
    private float enemiesLeft = 3f;
    // Starts the game
    void Start()
    {
        StartGame();
    }

    // Checks if the game is over and updates time
    void Update()
    {
        if(enemiesLeft <= 0)
        {
            GameWon();
        }
        if(timeLeftSeconds <= 0)
        {
            GameOver();
        }
        UpdateTime();
    }
    // Simple timer counting down
    public void UpdateTime()
    {
        if (isGameActive)
        {
            timeText.text = "Timer: " + Mathf.Max(Mathf.Round(timeLeftSeconds), 0) + "s";
            timeLeftSeconds -= Time.deltaTime;
        }
    }
    // Locks the mouse and starts the game
    public void StartGame()
    {
        DeactivateMouse();
        isGameActive = true;
        timeLeftSeconds = 60;
    }
    // Displays game over message
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        GameEnd();
    }
    // Displays game won message
    public void GameWon()
    {
        gameWonText.gameObject.SetActive(true);
        GameEnd();
    }
    // Abstraction
    // Handles game ending both victory or loss
    private void GameEnd()
    {
        endButtons.SetActive(true);
        isGameActive = false;
        ActivateMouse();
    }
    // Handles an enemy dying
    public void EnemyDied()
    {
        enemiesLeft = enemiesLeft - 1;
    }
    // Activates the mouse
    private void ActivateMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }  
    // Deactivates the mouse
    private void DeactivateMouse() { 
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    // Encapsulation
    // Returns the game state
    public bool GetGameState()
    {
        return isGameActive;
    }
    

}

