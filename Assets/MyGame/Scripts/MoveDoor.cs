using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoor : MonoBehaviour
{
    float t;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 5f)
        {
            MoveUp();
        }
    }
    void MoveUp()
    {
        transform.position += new Vector3(0, Mathf.Lerp(0, 0.4f, t), 0);

        t += 0.04f * Time.deltaTime;
    }
}
