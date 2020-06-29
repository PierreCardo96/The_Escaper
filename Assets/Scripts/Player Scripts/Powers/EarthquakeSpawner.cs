using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeSpawner : MonoBehaviour
{
    [SerializeField]
    BasicPlayerDamage earthquakePrefab;

    [SerializeField]
    Transform parentTransform;

    private void Start()
    {
        earthquakePrefab.damage = 500;
    }
    public void Spawn()
    {
        BasicPlayerDamage prefab = Instantiate(earthquakePrefab, parentTransform.position + parentTransform.forward, Quaternion.identity);
        prefab.transform.rotation = parentTransform.rotation;
        PlayEarthquakeSound();
    }

    private void PlayEarthquakeSound()
    {
        FindObjectOfType<AudioManager>().Play("Earthquake");
    }

    public EarthquakeDamage GetEarthquakePrefab()
    {
        return earthquakePrefab.GetComponent<EarthquakeDamage>();
    }

    public void IncreaseDamageOfPower(int factor)
    {
        earthquakePrefab.damage *= factor;
    }
}
