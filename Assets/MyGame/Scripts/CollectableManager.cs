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
    [SerializeField]
    GameObject keyGO;
    [SerializeField]
    GameObject keyHighlightGO;
    bool openDoor;
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
        if (coinCounter == 3)
        {
            keyGO.SetActive(true);
            StartCoroutine("SwitchKeyOnAndOff");
        }
        if (keyCollected && coinCounter == 3)
        {
            door2GO.GetComponent<MoveDoor>().openDoor = true;
            openDoor = true;
        }
    }
    IEnumerator SwitchKeyOnAndOff()
    {
        if (openDoor)
        {
            yield return new WaitForSeconds(1);
            keyHighlightGO.SetActive(false);
            yield return new WaitForSeconds(1);
            keyHighlightGO.SetActive(true);
            StartCoroutine("SwitchKeyOnAndOff");
        }
    }
}
