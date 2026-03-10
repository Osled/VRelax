
//States of Drones, will be assigned to the drone on event execution


public enum DroneState
{

    Idle,
    ExecutingJob

}

//State of jobs based on their current status. every jub starts with pending until assigned a drone to it
public enum JobState
{
    Pending,
    Assigned,
    Completed
}

// After the drone is assigned, 
// it will transfare to the starting point of the job ( that represents picking up up objects) point A ( GoingToStart ), 
//afterwards the drone will reach to the end point B ( GoingToEnd ).
public enum DroneJobPhase
{
    None,
    GoingToPickUp,
    GoningToDropOff
}