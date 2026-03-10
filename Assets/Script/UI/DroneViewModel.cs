using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DroneViewModel
{

    private JobAssignmentController controller;

    public List<string> droneOptions { get; private set; } = new List<string>();
    public List<string> droneStatuses { get; private set; } = new List<string>();
    public List<string> jobStatuses { get; private set; } = new List<string>();

    public event Action OnUIUpdated;



    public bool isUIVisable { get; private set; } = false;



    public event Action<int> OnCameraSwitch;
    private int currentCameraIndex = 0;
    private int cameraCount = 0;

    private bool usingCameraA = true;
    public DroneViewModel(JobAssignmentController controller)
    {

        this.controller = controller;

        controller.OnDroneStatusChanged += RefreashUI;
        controller.OnJobStatusChanged += RefreashUI;


    }

    public void LoadDroneOptions()
    {

        droneOptions.Clear();

        foreach(var data in controller.drones)
        {
            droneOptions.Add(data.drone.droneName);
        }
    }

    public void AssignjobtoDrone(int droneIndex, int jobIndex)
    {
        controller.AssignJob(droneIndex, jobIndex);
        RefreashUI();
    }

    public void RefreashUI()
    {
        droneStatuses.Clear();
        jobStatuses.Clear();


        foreach(var data in controller.drones)
        {

            droneStatuses.Add(data.drone.droneName+ ": "+ data.status);
            controller.UpdateDroneStatus(data.drone);
            
        }

        for (int i = 0; i < controller.jobs.Count; i++)
        {
            var job = controller.JobManager.GetJobByID(i);
            jobStatuses.Add(controller.jobs[i].jobName + ": " + job.state);
        }
        if(OnUIUpdated!= null)
        {
            OnUIUpdated();
        }
    }
    public void TogglePanel()
    {

        isUIVisable = !isUIVisable;
        if (OnUIUpdated != null)
        {
            OnUIUpdated();
        }
    }

    public void RestartAll() 
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitScene()
    {

        Application.Quit();
    }

    public void SetCameraCount(int count)
{
    cameraCount = count;
}

public void NextCamera()
{
    currentCameraIndex++;

    if (currentCameraIndex >= cameraCount)
        currentCameraIndex = 0;

    OnCameraSwitch?.Invoke(currentCameraIndex);
}
}
