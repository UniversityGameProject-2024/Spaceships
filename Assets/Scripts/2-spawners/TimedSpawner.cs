﻿using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
/**
*This component spawns the given object at fixed time ntervals at its object position
*/

public class TimedSpawner : MonoBehaviour
{
    [SerializeField] Mover prefabToSpawn;
    [SerializeField] Vector3 velocityOfSpawnedObject;
    [SerializeField] float secondsBetweenSpawns = 1f;
    void Start()
    {
        SpawnRoutine();
        Debug.Log("Start finished");
    }

    async void SpawnRoutine()
    {
        while (true)
        {
            GameObject newObject = Instantiate(prefabToSpawn.gameObject, transform.position, Quaternion.identity);
            newObject.GetComponent<Mover>().SetVelocity(velocityOfSpawnedObject);
            await Awaitable.WaitForSecondsAsync(secondsBetweenSpawns);
            // See here for more options: https://docs.unity3d.com/6000.0/Documentation/Manual/async-awaitable-introduction.html
        }
    }
}
