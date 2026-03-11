using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class DroneUIView : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown[] jobDropdown;
    [SerializeField] private TMP_Text[] DroneStatus;
    [SerializeField] private TMP_Text[] JobStatus;

    [SerializeField] private JobAssignmentController controller;

    [SerializeField] private GameObject mainPanel;
    [SerializeField] private Button toggleButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button camSwitchButton;

    [SerializeField] private Camera[] cameras;

    private DroneViewModel viewModel;

    private IEnumerator Start()
    {
        yield return null;

        viewModel = new DroneViewModel(controller);

        viewModel.OnUIUpdated += UpdateUI;
        viewModel.SetCameraCount(cameras.Length);

        toggleButton.onClick.AddListener(() => viewModel.TogglePanel());
        restartButton.onClick.AddListener(() => RestartScene());
        quitButton.onClick.AddListener(() => QuitApplication());
        camSwitchButton.onClick.AddListener(() => viewModel.NextCamera());

        jobDropdown[0].onValueChanged.AddListener(i =>
        {
            if (i > 0) viewModel.AssignJobToDrone(i - 1, 0);
        });

        jobDropdown[1].onValueChanged.AddListener(i =>
        {
            if (i > 0) viewModel.AssignJobToDrone(i - 1, 1);
        });

        jobDropdown[2].onValueChanged.AddListener(i =>
        {
            if (i > 0) viewModel.AssignJobToDrone(i - 1, 2);
        });

        UpdateUI();
    }

    private void UpdateUI()
    {
        // Panel visibility
        mainPanel.SetActive(viewModel.IsUIVisible);

        // Camera switching
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].enabled = (i == viewModel.CurrentCameraIndex);
        }

        // Drone statuses
        for (int i = 0; i < DroneStatus.Length; i++)
        {
            if (i < viewModel.droneStatuses.Count)
                DroneStatus[i].text = viewModel.droneStatuses[i];
            else
                DroneStatus[i].text = "Idle";
        }

        // Job statuses
        for (int i = 0; i < JobStatus.Length; i++)
        {
            if (i < viewModel.jobStatuses.Count)
                JobStatus[i].text = viewModel.jobStatuses[i];
            else
                JobStatus[i].text = "Pending";
        }
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void QuitApplication()
    {
        Application.Quit();
    }

    private void OnDestroy()
    {
        if (viewModel != null)
            viewModel.OnUIUpdated -= UpdateUI;
    }
}