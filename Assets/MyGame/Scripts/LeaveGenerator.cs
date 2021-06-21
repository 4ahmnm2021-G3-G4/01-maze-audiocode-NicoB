using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[ExecuteInEditMode]
public class LeaveGenerator : MonoBehaviour
{
    Vector3[] colliderVertexPos;
    [SerializeField]
    List<Vector3> contactPoints = new List<Vector3>();
    Vector3 startingPoint;
    [SerializeField]
    int generations = 1;
    int generationsCounter;
    float offsetY = 0.25f;
    void Start()
    {
        colliderVertexPos = GetColliderVertexPositions();
    }

    Vector3[] GetColliderVertexPositions()
    {
        BoxCollider b = GetComponent<BoxCollider>(); //retrieves the Box Collider of the GameObject called obj
        Vector3[] vertices = new Vector3[8];
        vertices[0] = transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f);
        vertices[1] = transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f);
        vertices[2] = transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, b.size.z) * 0.5f);
        vertices[3] = transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, b.size.z) * 0.5f);
        vertices[4] = transform.TransformPoint(b.center + new Vector3(-b.size.x, b.size.y, -b.size.z) * 0.5f);
        vertices[5] = transform.TransformPoint(b.center + new Vector3(b.size.x, b.size.y, -b.size.z) * 0.5f);
        vertices[6] = transform.TransformPoint(b.center + new Vector3(b.size.x, b.size.y, b.size.z) * 0.5f);
        vertices[7] = transform.TransformPoint(b.center + new Vector3(-b.size.x, b.size.y, b.size.z) * 0.5f);

        return vertices;
    }
    void OnDrawGizmos()
    {
        // Because we draw it inside OnDrawGizmos the icon is also pickable
        // in the scene view.
        colliderVertexPos = GetColliderVertexPositions();
        Gizmos.DrawIcon(colliderVertexPos[0], "Corner.png", true);
        Gizmos.DrawIcon(colliderVertexPos[1], "Corner.png", true);
        Gizmos.DrawIcon(colliderVertexPos[2], "Corner.png", true);
        Gizmos.DrawIcon(colliderVertexPos[3], "Corner.png", true);
        Gizmos.DrawIcon(colliderVertexPos[4], "Corner.png", true);
        Gizmos.DrawIcon(colliderVertexPos[5], "Corner.png", true);
        Gizmos.DrawIcon(colliderVertexPos[6], "Corner.png", true);
        Gizmos.DrawIcon(colliderVertexPos[7], "Corner.png", true);
        if (contactPoints != null)
        {
            foreach (Vector3 contactPoint in contactPoints)
            {
                Gizmos.DrawIcon(contactPoint, "Collision.png", true);
            }
        }
    }
    void OnCollisionStay(Collision collision)
    {
        contactPoints.Clear();
        for (int i = 0; i < collision.contactCount; i++)
        {
            contactPoints.Add(collision.GetContact(i).point);
        }
        GetStartPoint();
        GenerateBranches();
    }
    void OnCollisionExit(Collision collision)
    {
        contactPoints.Clear();
    }
    void GetStartPoint()
    {
        float highestY = 0;
        Vector3 centerPoint = this.transform.position;
        foreach (Vector3 v3 in contactPoints)
        {
            if (highestY < v3.y)
            {
                highestY = v3.y;
            }
        }
        startingPoint = new Vector3(centerPoint.x, highestY + offsetY, centerPoint.z);
    }
    void GenerateBranches()
    {
        if (generationsCounter == 0)
        {
            CreateEmpty(startingPoint);
            generationsCounter++;
        }
        if (generationsCounter < generations)
        {
            //build more
        }

    }
    void CreateEmpty(Vector3 pos)
    {
        var go = new GameObject("node");
        go.transform.position = pos;
        go.transform.SetParent(transform);
    }
}
