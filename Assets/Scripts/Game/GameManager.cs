using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI gameWonText;
    private float timeLeftSeconds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeftSeconds <= 0)
        {
            GameOver();
        }
        UpdateTime();
        
    }
    public void UpdateTime()
    {
        if (isGameActive)
        {
            timeText.text = "Timer: " + Mathf.Max(Mathf.Round(timeLeftSeconds), 0) + "s";
            timeLeftSeconds -= Time.deltaTime;
        }
    }
    public void StartGame()
    {
        isGameActive = true;
        timeLeftSeconds = 60;
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }
}
