using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyDifficulty : MonoBehaviour
{

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Difficulty Setting");

        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

}
