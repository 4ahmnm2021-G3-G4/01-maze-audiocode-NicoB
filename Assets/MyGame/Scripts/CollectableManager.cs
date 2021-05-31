using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    int coinCounter;
    bool keyCollected;
    [SerializeField]
    AudioSource pickUpAudioS;
    [SerializeField]
    GameObject door2GO;
    public void ItemCollected(bool isKey)
    {
        if (isKey)
        {
            keyCollected = true;
        }
        else
        {
            coinCounter++;
        }
        pickUpAudioS.Play();
        if (keyCollected && coinCounter == 3)
        {
            door2GO.GetComponent<MoveDoor>().openDoor = true;
        }
    }
}
