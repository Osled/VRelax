using UnityEngine;

public class Job 
{
    [Header("JobInfo")]
    public int jobID;

    [Header("JobDestenation")]
    public Transform jobPickUpPoint;
    public Transform jobDropOffpoint;

    [Tooltip("Get And Set Postions of the Jobs Start and End")]
    public Vector3 startPosition => jobPickUpPoint.position;
    public Vector3 endPosition => jobDropOffpoint.position;

    [Header("JobStatus")]
    public JobState state = JobState.Pending;



}
