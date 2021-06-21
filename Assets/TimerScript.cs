using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class TimerScript : MonoBehaviour
{
    public int _time = 60;

    public Gamekit2D.DialogueCanvasController _dialogueBox;

    public Gamekit2D.PlayerCharacter _player;

    private bool active = false;

    private float activatedTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (active)
        {
            int delta = (int)System.Math.Floor(Time.time - activatedTime);

            int displayTimer = _time - delta;

            if (displayTimer <= 0)
            {
                _dialogueBox.DeactivateCanvasWithDelay(0.1f);
                active = false;
                _player.StartCoroutine(_player.DieRespawnCoroutine(true, false));
                return;
            }

            _dialogueBox.ActivateCanvasWithText("THE RELIC WAS A LIE! GET OUT OF THERE BEFORE THE CAVE COLLAPSES! REMAINING TIME: " +
                                                        (_time - delta).ToString() + " SECONDS LEFT");
        }
    }

    public void Activate()
    {
        active = true;
        activatedTime = Time.time;
    }
}
