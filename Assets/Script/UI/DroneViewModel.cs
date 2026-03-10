using System;
using System.Collections.Generic;

public class DroneViewModel
{
    private readonly JobAssignmentController controller;
    private readonly ViewCommands ui;

    public List<string> droneStatuses { get; } = new List<string>();
    public List<string> jobStatuses { get; } = new List<string>();

    public event Action OnUIUpdated;

    private bool isUIVisible;
    public bool IsUIVisible => isUIVisible;

    private int currentCameraIndex;
    private int cameraCount;

    public DroneViewModel(JobAssignmentController controller, ViewCommands uiCommands)
    {
        this.controller = controller;
        this.ui = uiCommands;

        controller.OnDroneStatusChanged += RefreshUI;
        controller.OnJobStatusChanged += RefreshUI;
    }

    public void SetCameraCount(int count)
    {
        cameraCount = count;
    }

    public void AssignjobtoDrone(int droneIndex, int jobIndex)
    {
        controller.AssignJob(droneIndex, jobIndex);
        RefreshUI();
    }

    public void TogglePanel()
    {
        isUIVisible = !isUIVisible;
        ui.RequestPanelVisibility(isUIVisible);
        OnUIUpdated?.Invoke();
    }

    public void RefreshUI()
    {
        droneStatuses.Clear();
        jobStatuses.Clear();

        foreach (var data in controller.drones)
        {
            droneStatuses.Add($"{data.drone.droneName}: {data.status}");
            controller.UpdateDroneStatus(data.drone);
        }

        for (int i = 0; i < controller.jobs.Count; i++)
        {
            var job = controller.JobManager.GetJobByID(i);
            jobStatuses.Add($"{controller.jobs[i].jobName}: {job.state}");
        }

        OnUIUpdated?.Invoke();
    }

    public void RequestRestart()
    {
        ui.RequestRestart();
    }

    public void RequestQuit()
    {
        ui.RequestQuit();
    }

    public void NextCamera()
    {
        currentCameraIndex++;

        if (currentCameraIndex >= cameraCount)
            currentCameraIndex = 0;

        ui.RequestCameraSwitch(currentCameraIndex);
    }
}
