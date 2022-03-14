using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WayPointsPath : MonoBehaviour
{
    [SerializeField]
   List <Transform> wayPoints;
    [SerializeField]
    GameObject wayPointsAgent;
    [SerializeField]
    int agentSpeed;
    int pointIndex;
    bool CanAgentMove;
    void Start()
    {
        wayPoints = this.GetComponentsInChildren<Transform>().ToList();
        wayPoints.RemoveAt(0);
        pointIndex = 0;
        CanAgentMove = false;
    }

    public void Constractor(List<Transform> _waypoints)
    {
        wayPoints = _waypoints;
    }

     
    private void MoveAgentToNextPoint()
    {
        if(pointIndex < wayPoints.Count)
        {
            CanAgentMove = true;
            Debug.Log("move to next point");
        }       
    }

    private void AgentArrivedAtPoint()
    {
        throw new NotImplementedException();
    }

    public void AgentArrivedAtNoneStopPoint()
    {
        pointIndex++;
    }
   public void AgentArrivedAtStopPoint()
    {
        CanAgentMove = false;
        pointIndex ++;
        Debug.Log("agent arrived");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            MoveAgentToNextPoint();
    }

    private void FixedUpdate()
    {
        if (CanAgentMove)
        {
            wayPointsAgent.transform.position += GetAgentDirection() * agentSpeed *Time.fixedDeltaTime;
            wayPointsAgent.transform.LookAt(GetAgentDirection());
        }
    }

    private Vector3 GetAgentDirection()
    {
        Debug.Log("get agent Direction");
        Vector3 dir;
        Vector3 dirNormalized;
        dir = wayPoints[pointIndex].transform.position - wayPointsAgent.transform.position;
        dirNormalized = dir.normalized;
        return dirNormalized;
    }
}
