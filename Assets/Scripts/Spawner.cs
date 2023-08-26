using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject spikePrefab;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private float spikeTimer;
    [SerializeField] private float min;
    [SerializeField] private float max;

    private float timeCounter;

    private void Start()
    {
        timeCounter= 0.4f;
    }

    private void Update()
    {
        if (timeCounter <= 0)
        {
            GameObject newSpike = Instantiate(spikePrefab);
            newSpike.transform.position = spawnPosition.position;
            Destroy(newSpike, spikeTimer);
            timeCounter= Random.Range(min, max);
        }

        timeCounter-=Time.deltaTime;
    }
}
