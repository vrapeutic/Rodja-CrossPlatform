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
    [SerializeField]
    GameEvent arrivedEvent;
    [SerializeField]
    GameEvent winEvent;
    [SerializeField]
    GameEvent moveToNextPoint;
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
            moveToNextPoint.Raise();
            CanAgentMove = true;
           // Debug.Log("move to next point");
        }       
    }

   
    public void AgentArrivedAtNoneStopPoint()
    {
        if(pointIndex < wayPoints.Count-1) pointIndex++;
        else CanAgentMove = false;
    }
   public void AgentArrivedAtStopPoint()
    {
        arrivedEvent.Raise();
        CanAgentMove = false;
        if (pointIndex < wayPoints.Count - 1) pointIndex ++;
        else winEvent.Raise();
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
       // Debug.Log("get agent Direction");
        Vector3 dir;
        Vector3 dirNormalized;
        dir = wayPoints[pointIndex].transform.position - wayPointsAgent.transform.position;
        dirNormalized = dir.normalized;
        return dirNormalized;
    }
}
