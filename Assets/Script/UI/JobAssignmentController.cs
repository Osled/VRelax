using System.Collections.Generic;
using System;
using UnityEngine;
using Zenject;

public class JobAssignmentController : MonoBehaviour
{


    [Inject] private JobManager jobManager;

    public JobManager JobManager => jobManager;

    // list of all the drones and their status
    [System.Serializable]
    public class DroneData
    {
        public Drone drone;

        [Header("Runtime Status")]
        public DroneState status;
        public DroneJobPhase jobPhase;
        public Job currentJob;
    }

    //list of all the jobs and their position of A start B end
    [System.Serializable]
    public class JobData
    {
        public string jobName;
        public Transform startObject;
        public Transform endObject;
    }


    public List<DroneData> drones = new List<DroneData>();
    public List<JobData> jobs = new List<JobData>();

    // trigger on every Status Change
    public event Action OnDroneStatusChanged;
    public event Action OnJobStatusChanged;


    void Start()
    {
        AddJobs();
    }


    // Add jobs into the list with their status and start and end locations
    public void AddJobs()
    {
        for (int i = 0; i < jobs.Count; i++)
        {
            var jd = jobs[i];
            Job job = new Job
            {
                jobID = i,
                jobStartPoint = jd.startObject,
                jobEndpoint = jd.endObject,
            };
            jobManager.AddJob(job);
        }
        jobManager.OnJobStatusChanged += () => OnJobStatusChanged?.Invoke();
    }

    public void AssignJob(int droneIndex, int jobIndex)
    {
        if (droneIndex < 0 || droneIndex >= drones.Count) return;
        if (jobIndex < 0 || jobIndex >= jobs.Count) return;


        Drone drone = drones[droneIndex].drone;
        Job job = jobManager.GetJobByID(jobIndex);

        if (drone.state == DroneState.Idle && job.state == JobState.Pending)
        {
            //asssigne job to a drone
            jobManager.AssignJobToDrone(drone, job);
            //updates status of the drone
            UpdateDroneStatus(drone);
            if(OnDroneStatusChanged != null)
            {
                OnDroneStatusChanged();
            }
            if (OnJobStatusChanged != null)
            {
                OnJobStatusChanged();
            }
          
        }
    }
    // Expermenting with updating the and Collecting the status of the Drone
    public void UpdateDroneStatus(Drone drone)
    {
        var data = drones.Find(d => d.drone == drone);
        if (data != null) 
        {
            data.status = drone.state;
            data.jobPhase = drone.jobPhase;
            data.currentJob = drone.currentJob;

        }
    }

}
