using UnityEngine;
using Zenject;

public class Drone : MonoBehaviour
{
    //Drone information, might not use both ID and name, two options just incase
    [Header("DroneInfo")]
    public string droneName;
    public string droneID;
    
    
    [Header("DroneStatus")]
    public DroneState state { get; set; }
    public DroneJobPhase jobPhase { get; set; }
    

    //Get and set of the JobManager to be injected 
    [Header("JobManagement")]
    [Inject] private JobManager jobManager;
    public Job currentJob { get; set; }
    [Tooltip("Get And Set JobManager")]
    public JobManager JobManager => jobManager;


    [Inject]
    public void Construct(JobManager manager)
    {
        jobManager = manager;
        jobManager.AddDrone(this);
    }
}
