using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gamekit2D
{

    public class DifficultySetter : MonoBehaviour
    {
        public float _platformSpeedMultiplier = 1;
        public int _enemyHealth = 1;
        public int _enemyDamage = 1;
        public int _escapeTime = 0;

        public GameObject _diffCanvas;

        public Gamekit2D.Damager _spitProjectile;

        private bool setTimer = false;

        private bool deactivate = false;

        private float deactTime;

        void OnEnable()
        {
            SceneManager.sceneLoaded += OnLevelFinishedLoading;
        }

        void OnDisable()
        {
            SceneManager.sceneLoaded -= OnLevelFinishedLoading;
        }

        private void FixedUpdate()
        {
            if (deactivate)
            {
                if (Time.time - deactTime > 0.5f)
                {
                    Gamekit2D.PlayerInput input = GameObject.FindObjectOfType<Gamekit2D.PlayerInput>();
                    input.ReleaseControl();
                    deactivate = false;
                }
            }
            
        }

        void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
        {
            SetDiffPlatSpeed(_platformSpeedMultiplier);
            SetDiffEnemHealth(_enemyHealth);
            SetDiffEnemDmg(_enemyDamage);
            SetTimer(_escapeTime);
        }

        private void Start()
        {
            _diffCanvas.SetActive(true);
            deactTime = Time.time;
            deactivate = true;
        }

        public void SetDiffPlatSpeed(float platSpeed)
        {
            _platformSpeedMultiplier = platSpeed;

            Gamekit2D.MovingPlatform[] platforms = GameObject.FindObjectsOfType<Gamekit2D.MovingPlatform>();

            foreach (Gamekit2D.MovingPlatform platform in platforms)
            {
                platform.speed *= platSpeed;
            }
        }

        public void SetDiffEnemHealth(int enemyHealth)
        {
            _enemyHealth = enemyHealth;

            GameObject obj = GameObject.Find("----- Enemies -----");
            Gamekit2D.Damageable[] enemyDmgs = obj.GetComponentsInChildren<Gamekit2D.Damageable>();

            foreach (Gamekit2D.Damageable enemyDmg in enemyDmgs)
            {
                enemyDmg.SetHealth(_enemyHealth);
            }
        }

        public void SetDiffEnemDmg(int enemyDamage)
        {
            _enemyDamage = enemyDamage;

            GameObject obj = GameObject.Find("----- Enemies -----");

            Gamekit2D.Damager[] enemyDmgs = obj.GetComponentsInChildren<Gamekit2D.Damager>();

            foreach (Gamekit2D.Damager enemyDmg in enemyDmgs)
            {
                enemyDmg.damage = _enemyDamage;
            }

            _spitProjectile.damage = _enemyDamage;
        }

        public void SetTimer(int timer)
        {
            _escapeTime = timer;

            GameObject Timer = GameObject.Find("Timer");

            if (Timer == null)
                return;

            if (!setTimer)
            {
                setTimer = true;

                Gamekit2D.TimerScript script = Timer.GetComponentInChildren<Gamekit2D.TimerScript>();

                script._time = script._time - _escapeTime;
            }
        }

        public void ActivatePlayer()
        {
            GameObject.FindObjectOfType<Gamekit2D.PlayerInput>().GainControl();
        }

        public void Restart()
        {
            Start();
        }
    }
}
