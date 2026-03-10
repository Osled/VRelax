using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class DroneUIVIew : MonoBehaviour, ViewCommands
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

        viewModel = new DroneViewModel(controller, this);

        viewModel.OnUIUpdated += UpdateUI;
        viewModel.SetCameraCount(cameras.Length);

        toggleButton.onClick.AddListener(() => viewModel.TogglePanel());
        restartButton.onClick.AddListener(() => viewModel.RequestRestart());
        quitButton.onClick.AddListener(() => viewModel.RequestQuit());
        camSwitchButton.onClick.AddListener(() => viewModel.NextCamera());

        jobDropdown[0].onValueChanged.AddListener(i =>
        {
            if (i > 0) viewModel.AssignjobtoDrone(i - 1, 0);
        });

        jobDropdown[1].onValueChanged.AddListener(i =>
        {
            if (i > 0) viewModel.AssignjobtoDrone(i - 1, 1);
        });

        jobDropdown[2].onValueChanged.AddListener(i =>
        {
            if (i > 0) viewModel.AssignjobtoDrone(i - 1, 2);
        });
    }

    public void RequestRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RequestQuit()
    {
        Application.Quit();
    }

    public void RequestCameraSwitch(int index)
    {
        for (int i = 0; i < cameras.Length; i++)
            cameras[i].enabled = (i == index);
    }

    public void RequestPanelVisibility(bool visible)
    {
        mainPanel.SetActive(visible);
    }

    private void UpdateUI()
    {
        for (int i = 0; i < DroneStatus.Length; i++)
        {
            if (i < viewModel.droneStatuses.Count)
                DroneStatus[i].text = viewModel.droneStatuses[i];
            else
                DroneStatus[i].text = "Idle";
        }

        for (int i = 0; i < JobStatus.Length; i++)
        {
            if (i < viewModel.jobStatuses.Count)
                JobStatus[i].text = viewModel.jobStatuses[i];
            else
                JobStatus[i].text = "Pending";
        }
    }
}
