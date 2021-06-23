using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAdder : MonoBehaviour
{
    public GameObject _door;

    public void AddSelf()
    {
        GameObject.FindObjectOfType<Gamekit2D.DoorPlatformMaintain>().AddTrigger(gameObject);
        if (_door != null)
            GameObject.FindObjectOfType<Gamekit2D.DoorPlatformMaintain>().AddTrigger(_door);
    }
}
