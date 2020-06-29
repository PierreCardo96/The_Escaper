using Assets.Scripts.Player_Scripts.Powers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowersHotkey : MonoBehaviour
{
    private EarthquakeSpawner earthquakeSpawner;    
    private ActionBar actionBar;
    private BallShooter ballShooter;

    private void Start()
    {
        actionBar = PlayerUI.Instance.GetActionBar();
        ballShooter = GetComponentInChildren<BallShooter>();
        earthquakeSpawner = GetComponentInChildren<EarthquakeSpawner>();
    }

    public void RespondToHotKey()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ProcessPowerPressed(PowerType.FireBall);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ProcessPowerPressed(PowerType.IceBall);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ProcessPowerPressed(PowerType.LightningBall);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ProcessPowerPressed(PowerType.Earthquake);
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            actionBar.SetAllKeysActivation(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            actionBar.SetAllKeysActivation(false);
        }
    }

    private void ProcessPowerPressed(PowerType powerType)
    {
        if (actionBar.IsPowerActive(powerType))
        {
            actionBar.UpdateSelection(powerType);
            if(powerType == PowerType.Earthquake)
            {
                GetComponent<PlayerAttacking>().ProcessEarthquake();
                float earthquakeTime = earthquakeSpawner.GetEarthquakePrefab().GetProcessTime();
                StartCoroutine(EarthquakeFinishedRoutine(earthquakeTime));
            }
            else
            {
                SetBallPowerType(powerType);
            }
        }
    }

    private IEnumerator EarthquakeFinishedRoutine(float time)
    {
        yield return new WaitForSeconds(time);
        actionBar.UpdateSelection(ballShooter.GetCurrentPowerType());
    }

    public void SetBallPowerType(PowerType powerType)
    {
        ballShooter.SetPower(powerType);
    }
}
