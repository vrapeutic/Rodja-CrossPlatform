using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class WayPointsPath : MonoBehaviour
{
    [SerializeField]
    List<WayPoint> wayPoints;
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
        wayPoints = this.GetComponentsInChildren<WayPoint>().ToList();
        //wayPoints.RemoveAt(0);
        pointIndex = 0;
        CanAgentMove = true;
    }
    public void Constractor(List<WayPoint> _waypoints)
    {
        wayPoints = _waypoints;
    }
    public void MoveAgentToNextPoint()
    {
        if (pointIndex < wayPoints.Count)
        {
            arrivedEvent.Raise();
            CanAgentMove = true;
            // Debug.Log("move to next point");
        }
    }
    public void AgentArrivedAtNoneStopPoint()
    {
        if (pointIndex < wayPoints.Count - 1) pointIndex++;
        else CanAgentMove = false;
    }
    public void AgentArrivedAtStopPoint()
    {
        moveToNextPoint.Raise();
        CanAgentMove = false;
        if (pointIndex < wayPoints.Count - 1) pointIndex++;
        else
        {
            winEvent.Raise();
            TovaDataGet.ReturnTovaData().SetSessionEnd(true);
        }

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
            wayPointsAgent.transform.position += GetAgentDirection() * agentSpeed * Time.fixedDeltaTime;
            //wayPointsAgent.transform.LookAt(GetAgentDirection());
            wayPointsAgent.transform.rotation = Quaternion.Slerp(wayPointsAgent.transform.rotation, Quaternion.LookRotation(GetAgentDirection()), 0.55f);
        }
    }
    private Vector3 GetAgentDirection()
    {
        // Debug.Log("get agent Direction");
        Vector3 dir;
        Vector3 dirNormalized;
        dir = wayPoints[pointIndex].myPosition - wayPointsAgent.transform.position;
        dirNormalized = dir.normalized;
        return dirNormalized;
    }
}