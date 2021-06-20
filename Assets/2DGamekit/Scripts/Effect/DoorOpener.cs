using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    // number of pads needed to open the door
    private int pressurePads = 2;

    public Animator doorAnimator;

    private GameObject[] pads;

    private int i = 0;

    private bool invokedDelay = false;

    private bool delaying = false;

    private float startTime = 0.0f;

    private float Delay = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        pressurePads = 2;
        pads = new GameObject[pressurePads];
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
    public void SendSignal(GameObject pressurePad)
    {
        foreach (GameObject pad in pads)
            if (pad == pressurePad)
                return;

        pads[i++] = pressurePad;

        pressurePads--;
        if (pressurePads == 0)
            doorAnimator.Play("DoorOpening");
    }

    public void OpenWithDelay(float delay)
    {
        Delay = delay;
        invokedDelay = true;
        startTime = Time.time;
    }
}
