using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoor : MonoBehaviour
{
    float t;
    bool moveDownB = false;
    public bool openDoor;
    bool stateChanged;
    void Update()
    {
        if (transform.position.y < 5f && !moveDownB && openDoor)
        {
            MoveUp();
            if (stateChanged == false)
            {
                GetComponent<AudioSource>().Play();
                stateChanged = true;
            }
        }
        if (transform.position.y > 1.7f && moveDownB)
        {
            MoveDown();
        }
    }
    void MoveUp()
    {
        transform.position += new Vector3(0, Mathf.Lerp(0, 0.4f, t), 0);
        t += 0.04f * Time.deltaTime;
    }
    void MoveDown()
    {
        transform.position -= new Vector3(0, Mathf.Lerp(0, 0.4f, t), 0);
        t += 0.04f * Time.deltaTime;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            moveDownB = true;
            t = 0;
        }
    }
}
