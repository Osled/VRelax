using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class DroneUIVIew : MonoBehaviour
{


    [SerializeField]private TMP_Dropdown[] jobDropdown;

    [SerializeField] private TMP_Text[] DroneStatus;
    [SerializeField] private TMP_Text[] JobStatus;

    [SerializeField] private JobAssignmentController controller;

    [SerializeField] private GameObject mainPanel;
    [SerializeField] private Button toggleButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button camSwitchButton;

    [SerializeField] private Camera[] cameras;




    [SerializeField] private DroneViewModel viewModel;


    private IEnumerator Start()
    {
        yield return null;

        viewModel = new DroneViewModel(controller);

        viewModel.OnUIUpdated += UpdateUI;

        viewModel.OnCameraSwitch += HandleCameraSwitch;

        viewModel.SetCameraCount(cameras.Length);

        toggleButton.onClick.AddListener(()=>viewModel.TogglePanel()) ;
        restartButton.onClick.AddListener(()=>viewModel.RestartAll()) ;
        quitButton.onClick.AddListener(()=>viewModel.QuitScene()) ;
        camSwitchButton.onClick.AddListener(()=>viewModel.NextCamera()) ;


        jobDropdown[0].onValueChanged.AddListener(delegate (int i)
        {
            if (i == 0) return;
            viewModel.AssignjobtoDrone(i - 1, 0);
        });

        jobDropdown[1].onValueChanged.AddListener(delegate (int i)
        {
            if (i == 0) return;
            viewModel.AssignjobtoDrone(i - 1, 1);
        });
        jobDropdown[2].onValueChanged.AddListener(delegate (int i)
        {
            if (i == 0) return;
            viewModel.AssignjobtoDrone(i - 1, 2);
        });

       // UpdateUI();
    }



    void UpdateUI()
    {
        mainPanel.SetActive(viewModel.isUIVisable);

        // Update drone statuses safely
        for (int i = 0; i < DroneStatus.Length; i++)
        {
            if (i < viewModel.droneStatuses.Count)
                DroneStatus[i].text = viewModel.droneStatuses[i];
            else
                DroneStatus[i].text = "Idle";
        }

        // Update job statuses safely
        for (int i = 0; i < JobStatus.Length; i++)
        {
            if (i < viewModel.jobStatuses.Count)
                JobStatus[i].text = viewModel.jobStatuses[i];
            else
                JobStatus[i].text = "Pending";
        }
    }

    private void HandleCameraSwitch(int index)
    {
        for (int i = 0; i < cameras.Length; i++)
            cameras[i].enabled = (i == index);
    }


}
