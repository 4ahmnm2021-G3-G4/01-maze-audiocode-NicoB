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
        }
    }
    IEnumerator SwitchKeyOnAndOff()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("1");
        keyHighlightGO.SetActive(false);
        yield return new WaitForSeconds(1);
        Debug.Log("2");
        keyHighlightGO.SetActive(true);
        StartCoroutine("SwitchKeyOnAndOff");
    }
}
