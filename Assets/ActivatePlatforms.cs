using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePlatforms : MonoBehaviour
{
    public Gamekit2D.MovingPlatform[] _platforms;

    bool done = false;

    // Start is called before the first frame update
    void Start()
    {
        done = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PerformAction()
    {
        if (!done)
        {
            foreach (Gamekit2D.MovingPlatform plat in _platforms)
                plat.StartMoving();
            done = true;
        }
    }
}
