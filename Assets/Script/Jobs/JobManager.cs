
using UnityEngine;
using System;
using System.Collections.Generic;

public class JobManager 
{
    [Header("Drones and Jobs List")]
    [Tooltip("Hosts all the jobs and Drones")]
    private readonly List<Job> jobs = new List<Job>();
    private readonly List<Drone> drones = new List<Drone>();




    // Swtich betweem job statues, will be used for UI change too
    public event Action OnJobStatusChanged;

    // Add Jobs to the list 
    public void AddJob(Job job)
    {
        jobs.Add(job);
    }
    public Job GetJobByID(int id)
    {
        return jobs[id];
    }


    //  Add Drones to the list by checking if they have Drone.cs inside them.
    public void AddDrone(Drone drone)
    {
        if (!drones.Contains(drone))
        {
            drones.Add(drone);
        }
    }


    //will be Executed using UI and will assign in the dropdown menu which Job will be assigned to which Drone 
    public void AssignJobToDrone(Drone drone, Job job)
    {
        drone.currentJob = job;
        drone.state = DroneState.ExecutingJob;
        drone.jobPhase = DroneJobPhase.GoingToStart;
        job.state = JobState.Assigned;

    }


    // After job completion will need to inform the UI that the job is completed. Therefore, we create a function which will trigger a completion status.


    public void MarkJobCompleted(int jobId)
    {

        Job job = GetJobByID(jobId);
        //if there is no job assigned after reaching the point then we consider the job as completed
        if (job != null) 
        {
            job.state = JobState.Completed;

            if(OnJobStatusChanged != null) 
            {
                OnJobStatusChanged.Invoke();
            }
           
        }

    }

  



}
