using UnityEngine;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{
    private InputSystem_Actions controls;
    [SerializeField] private GameObject tutorialPanel;

    void Awake()
    {
        controls = new InputSystem_Actions();
    }
    private void OnEnable()
    {
        controls.UI.Enable();
    }
    private void OnDisable()
    {
        controls.UI.Disable();
    }
    // Handles the input for the tutorial screen
    void Update()
    {
        if (controls.UI.TutorialToggle.WasPressedThisFrame())
        {
            ToggleTutorial();
        }
    }
    // Toggles the tutorial screen
    private void ToggleTutorial()
    {
        if (tutorialPanel.activeSelf)
        {
            tutorialPanel.SetActive(false);
        }
        else
        {
            tutorialPanel.SetActive(true);
        }
    }
    // Re-loads the game scene
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    // Loads the main menu scene
    public void MainMenu()
    {
        SceneManager.UnloadScene("Game");
        SceneManager.LoadScene("TitleScreen");
    }
}
