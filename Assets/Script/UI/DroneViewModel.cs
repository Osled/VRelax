using System;
using System.Collections.Generic;

public class DroneViewModel
{
    private readonly JobAssignmentController controller;

    public List<string> droneStatuses { get; } = new();
    public List<string> jobStatuses { get; } = new();

    public event Action OnUIUpdated;

    public bool IsUIVisible { get; private set; }
    public int CurrentCameraIndex { get; private set; }

    private int cameraCount;

    public DroneViewModel(JobAssignmentController controller)
    {
        this.controller = controller;

        controller.OnDroneStatusChanged += RefreshUI;
        controller.OnJobStatusChanged += RefreshUI;
    }

    public void SetCameraCount(int count)
    {
        cameraCount = count;
    }

    public void TogglePanel()
    {
        IsUIVisible = !IsUIVisible;
        OnUIUpdated?.Invoke();
    }

    public void NextCamera()
    {
        CurrentCameraIndex = (CurrentCameraIndex + 1) % cameraCount;
        OnUIUpdated?.Invoke();
    }

    public void AssignJobToDrone(int droneIndex, int jobIndex)
    {
        controller.AssignJob(droneIndex, jobIndex);
        RefreshUI();
    }

    public void RefreshUI()
    {
        droneStatuses.Clear();
        jobStatuses.Clear();

        foreach (var data in controller.drones)
            droneStatuses.Add($"{data.drone.droneName}: {data.status}");

        for (int i = 0; i < controller.jobs.Count; i++)
        {
            var job = controller.JobManager.GetJobByID(i);
            jobStatuses.Add($"{controller.jobs[i].jobName}: {job.state}");
        }

        OnUIUpdated?.Invoke();
    }
}