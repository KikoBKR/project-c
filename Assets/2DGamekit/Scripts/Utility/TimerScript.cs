using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;
using UnityEngine.SceneManagement;

namespace Gamekit2D
{

    public class TimerScript : MonoBehaviour
    {
        public int _time = 180;

        private Gamekit2D.DialogueCanvasController _dialogueBox;

        private Gamekit2D.PlayerCharacter _player;

        private bool active = false;

        private float activatedTime;

        void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }


        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            _dialogueBox = GameObject.FindObjectOfType<Gamekit2D.DialogueCanvasController>(true);
            Debug.Log(_dialogueBox);
            _player = GameObject.FindObjectOfType<Gamekit2D.PlayerCharacter>();
            Debug.Log(_player);
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

}