using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDestructables : MonoBehaviour
{
    public GameObject[] _deactivate;
    public GameObject[] _activate;

    private bool done = false;

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
            foreach (GameObject obj in _deactivate)
                obj.SetActive(false);
            foreach (GameObject obj in _activate)
                obj.SetActive(true);

            done = true;
        }
    }
}
