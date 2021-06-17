using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TriggerWon : MonoBehaviour
{
    [SerializeField]
    GameObject canvasWonGO;
    [SerializeField]
    GameObject player;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canvasWonGO.SetActive(true);
            player.GetComponent<Player>().enabled = false;
        }
    }
}
