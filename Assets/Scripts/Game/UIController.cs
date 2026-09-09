using UnityEngine;

public class UIController : MonoBehaviour
{
    private InputSystem_Actions controls;
    [SerializeField] private GameObject tutorialPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        controls = new InputSystem_Actions();
    }
    private void OnEnable()
    {
        controls.UI.Enable();
    }
    // Update is called once per frame
    void Update()
    {
        if (controls.UI.TutorialToggle.WasPressedThisFrame())
        {
            ToggleTutorial();
        }
    }
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
}
