using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScript : MonoBehaviour
{
    public GameObject _victoryCanvas;

    private bool close = false;

    private float startTime;

    private float interval = 5.0f;

    private void FixedUpdate()
    {
        if (close)
        {
            if (Time.time - startTime > interval)
                Application.Quit();
        }
    }

    public void Victory()
    {
        Gamekit2D.TimerScript timer = GameObject.FindObjectOfType<Gamekit2D.TimerScript>();

        if (timer != null)
        {
            // if it is active, then it is still ticking
            if (timer.IsActivated())
            {
                timer.DeActivate();
                _victoryCanvas.SetActive(true);
                startTime = Time.time;
                close = true;
            }
        }
    }
}
