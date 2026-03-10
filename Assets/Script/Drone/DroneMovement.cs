using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 4f;
    [SerializeField] private float tiltAngle = 2f;

    [Header("Obstacle Avoidance")]
    [SerializeField] private float avoidDistance = 2f;
    [SerializeField] private float sphereRadius = 0.6f;
    [SerializeField] private float avoidStrength = 4f;
    [SerializeField] private LayerMask obstacleMask;

    private Drone drone;
    private Rigidbody rb;

    private void Awake()
    {
        drone = GetComponent<Drone>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (drone.state != DroneState.ExecutingJob || drone.currentJob == null)
            return;

        Vector3 target = GetCurrentTarget();
        float dist = Vector3.Distance(transform.position, target);

       
        if (dist < 1f)
        {
            rb.linearVelocity = Vector3.zero;   
            rb.angularVelocity = Vector3.zero;

            AdvancePhase();
            return;
        }

        
        Vector3 direction = (target - transform.position).normalized;

       
        direction += AvoidObstacles();

        Move(direction);
    }

    Vector3 GetCurrentTarget()
    {
        if (drone.jobPhase == DroneJobPhase.GoingToPickUp)
            return drone.currentJob.startPosition;

        if (drone.jobPhase == DroneJobPhase.GoningToDropOff)
            return drone.currentJob.endPosition;

        return transform.position;
    }


   

    void Move(Vector3 direction)
    {
        rb.linearVelocity = direction.normalized * speed;

        if (direction.sqrMagnitude > 0.001f)
        {
            Quaternion targetRot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);

            float tilt = Mathf.Clamp(Vector3.Dot(direction, transform.right), -1f, 1f);
            transform.localRotation *= Quaternion.Euler(0, 0, -tilt * tiltAngle);
        }
    }




    void AdvancePhase()
    {
        if (drone.jobPhase == DroneJobPhase.GoingToPickUp)
        {
            drone.jobPhase = DroneJobPhase.GoningToDropOff;
            return;
        }

        if (drone.jobPhase == DroneJobPhase.GoningToDropOff)
        {
            drone.JobManager.MarkJobCompleted(drone.currentJob.jobID);
            drone.currentJob = null;
            drone.state = DroneState.Idle;
            drone.jobPhase = DroneJobPhase.None;
        }
    }



    Vector3 AvoidObstacles()
    {
        Vector3 avoidance = Vector3.zero;
        Vector3 origin = transform.position;

        Vector3[] dirs = GetDirections();

        Vector3[] GetDirections()
        {
            return new Vector3[]
            {
                transform.forward,
                -transform.forward,
                transform.right,
                -transform.right,
                Vector3.up,
                Vector3.down
            };
        }

        foreach (Vector3 dir in dirs)
        {
            if (Physics.SphereCast(origin, sphereRadius, dir, out RaycastHit hit, avoidDistance, obstacleMask))
            {
                Vector3 push = (origin - hit.point).normalized * avoidStrength;

                if (dir != Vector3.up && dir != Vector3.down)
                    push = Vector3.ProjectOnPlane(push, Vector3.up);

                avoidance += push;
            }
        }

        return avoidance;
    }
}
