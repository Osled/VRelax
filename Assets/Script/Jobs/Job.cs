using UnityEngine;

public class Job 
{
    [Header("JobInfo")]
    public int jobID;

    [Header("JobDestenation")]
    public Transform jobStartPoint;
    public Transform jobEndpoint;

    [Tooltip("Get And Set Postions of the Jobs Start and End")]
    public Vector3 startPosition => jobStartPoint.position;
    public Vector3 endPosition => jobEndpoint.position;

    [Header("JobStatus")]
    public JobState state = JobState.Pending;



}
