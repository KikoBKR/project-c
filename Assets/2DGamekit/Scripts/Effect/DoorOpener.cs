using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    // number of signals needed to open the door
    public int _signals = 2;

    private int counter;

    public Animator doorAnimator;

    private GameObject[] signalers;

    private int i = 0;

    private bool invokedDelay = false;

    private bool delaying = false;

    private float startTime = 0.0f;

    private float Delay = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        counter = _signals;
        signalers = new GameObject[_signals];
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (invokedDelay)
        {
            invokedDelay = !invokedDelay;
            delaying = true;
        }

        if (delaying)
        {
            if (Time.time - startTime >= Delay)
            {
                delaying = false;
                doorAnimator.Play("DoorOpening");
            }
        }
    }

    // A platform sends a signal, so decrease the number of needed pads remaining
    public void SendSignal(GameObject Signal)
    {
        foreach (GameObject signal in signalers)
            if (Signal == signal)
                return;

        signalers[i++] = Signal;

        counter--;
        if (counter == 0)
        {
            doorAnimator.Play("DoorOpening");
            Gamekit2D.DoorPlatformMaintain manager = GameObject.FindObjectOfType<Gamekit2D.DoorPlatformMaintain>();
            manager.AddDoor(gameObject);
        }
    }

    public void OpenWithDelay(float delay)
    {
        Delay = delay;
        invokedDelay = true;
        startTime = Time.time;
    }
}
