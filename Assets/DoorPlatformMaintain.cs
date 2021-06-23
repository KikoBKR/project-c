using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gamekit2D
{

    public class DoorPlatformMaintain : MonoBehaviour
    {
        private List<string>[] _doors;

        private List<string>[] _triggers;

        private void Awake()
        {
            _doors = new List<string>[2];
            _triggers = new List<string>[2];

            for (int i = 0; i < 2; i++)
            {
                _doors[i] = new List<string>();
                _triggers[i] = new List<string>();
            }
        }

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
            int currentScene = scene.buildIndex;

            if (currentScene < 2)
            {
                foreach (string doorName in _doors[currentScene])
                    GameObject.Find(doorName).SetActive(false);

                foreach (string triggerName in _triggers[currentScene])
                    GameObject.Find(triggerName).SetActive(false);
            }
        }
        public void AddDoor(GameObject door)
        {
           int currentScene = SceneManager.GetActiveScene().buildIndex;
            if (!_doors[currentScene].Contains(door.name))
                _doors[currentScene].Add(door.name);
        }

        public void AddTrigger(GameObject trigger)
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            if (!_doors[currentScene].Contains(trigger.name))
                _doors[currentScene].Add(trigger.name);
        }


        public void Restart()
        {
            Awake();
        }
    }

}