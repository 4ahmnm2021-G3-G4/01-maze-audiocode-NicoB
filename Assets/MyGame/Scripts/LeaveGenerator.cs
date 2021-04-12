using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveGenerator : MonoBehaviour
{
    Vector3[] colliderVertexPos;
    List<Vector3> contactPoints = new List<Vector3>();

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
        // Draws the Light bulb icon at position of the object.
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
        Debug.Log("Collision stay");
    }
    void OnCollisionExit(Collision collision)
    {
        contactPoints.Clear();
    }

}
