using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTimer : MonoBehaviour
{
    public void PerformAction()
    {
        GameObject.FindObjectOfType<Gamekit2D.TimerScript>().Activate();
    }
}
