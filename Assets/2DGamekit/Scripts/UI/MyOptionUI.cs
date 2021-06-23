using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gamekit2D
{
    public class MyOptionUI : MonoBehaviour
    {
        public void ExitPause()
        {
            PlayerCharacter.PlayerInstance.Unpause();
        }

        public void RestartLevel()
        {
            ExitPause();
            SceneManager.LoadScene(0);
            GameObject.FindObjectOfType<Gamekit2D.DifficultySetter>().Restart();
        }

        public static void StaticRestartLevel()
        {
            PlayerCharacter.PlayerInstance.Unpause();
            GameObject.FindObjectOfType<Gamekit2D.DifficultySetter>().Restart();
            GameObject.FindObjectOfType<Gamekit2D.DoorPlatformMaintain>().Restart();
            Gamekit2D.TimerScript timer = GameObject.FindObjectOfType<Gamekit2D.TimerScript>();
            if (timer != null)
                timer.DeActivate();
            SceneManager.LoadScene(0);
        }
    }
}