using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySetter : MonoBehaviour
{
    public float _platformSpeedMultiplier = 1;
    public int _enemyHealth = 1;
    public int _enemyDamage = 1;
    public int _escapeTime = 0;

    public Gamekit2D.Damager _spitProjectile;

    private bool setTimer = false;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
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
        Debug.Log("Hey");
        // disable the Player Input
        GameObject.FindObjectOfType<Gamekit2D.PlayerInput>().ReleaseControl();
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
}
