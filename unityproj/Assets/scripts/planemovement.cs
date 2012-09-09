using UnityEngine;
using System.Collections;

public class planemovement : MonoBehaviour {

    /// <summary>
    /// The speed at which the plane travels every frame.
    /// </summary>
    public float moveSpeed = 10;

    /// <summary>
    /// A list of target to fly towards in, in the order provided.
    /// </summary>
    public Transform [] targets = new Transform[2];

    /// <summary>
    /// When at the furthest point from the target, this will be
    /// the turn speed.
    /// </summary>
    public float minTurnSpeed = 0.1f;

    /// <summary>
    /// When right on top of the target this will be the turn speed.
    /// Turn speed is interpolated between this and minTurnSpeed as
    /// the object gets closer to the current target.
    /// </summary>
    public float maxTurnSpeed = 1.0f;

    /// <summary>
    /// Tracks which target is currently being flown to. This
    /// is an index into targets.
    /// </summary>
    private int currentTargetIndex = 0;

    /// <summary>
    /// When the distance between this object and its current target
    /// is <= to this number, it will be considered "reached".
    /// </summary>
    private float minDist = 1.0f;

    /// <summary>
    /// The distance from the previous target to the current target.
    /// </summary>
    private float distFromPreviousToCurrent = 0.0f;
    
    // Use this for initialization
    void Start () 
    {
        distFromPreviousToCurrent = Vector3.Distance(transform.position, targets[currentTargetIndex].position);
    }
    
    // Update is called once per frame
    void Update () 
    {
        // Get the current target.
        Transform currentTarget = targets[currentTargetIndex];
        
        // Get a vector from the current position to the target.
        // This is the vector we want to move our forward vector towards.
        Vector3 lookDirection = currentTarget.position - transform.position;

        // Calculate the rotation needed for this target look vector.
        Quaternion rot = Quaternion.LookRotation(lookDirection.normalized);
        
        // Get the current distance between the object and its target.
        float dist = Vector3.Distance(transform.position, currentTarget.position);
        
        // Normalize the distance.
        float norm = dist / distFromPreviousToCurrent;
        
        // Based on how much distance has been covered, increase the turn 
        // speed, so that as it gets really close it can make sharp turns to hit
        // the target.
        // TODO: This fails in the case where the plane is headed away from the 
        //         target. In those cases, even though it might be far away, we
        //         should increase the turn speed too.
        float finalTurnSpeed = Mathf.Lerp(maxTurnSpeed, minTurnSpeed, norm);
        
        // Rotate towards that target rotation based on the turn speed.
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * finalTurnSpeed);
        
        // With the rotation complete, just move forward.
        transform.Translate(new Vector3(0,0,moveSpeed) * Time.deltaTime);
        
        // If we get close to the target, switch to the next target.
        if( Vector3.Distance(transform.position, currentTarget.position) < minDist )
        {
            currentTargetIndex++;
            
            // Loop around to the first target when reaching the end of the list.
            if( currentTargetIndex >= targets.Length )
            {
                currentTargetIndex = 0;
            }

            // We have a new target so update to distance stored.
            distFromPreviousToCurrent = Vector3.Distance(transform.position, targets[currentTargetIndex].position);
        }
    }
}
