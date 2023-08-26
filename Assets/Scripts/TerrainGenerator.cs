using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> terrainsList;
    [SerializeField] private GameObject roof;
    private List<GameObject> pool;




    [Header("Roof")]
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;

    [SerializeField] private float minHeigth;
    [SerializeField] private float maxHeigth;

    [SerializeField] private float minScale;
    [SerializeField] private float maxScale;

    [SerializeField] private float destroyTime;

    private float timeCounter;

    private void Start()
    {
        pool = new List<GameObject>();
        timeCounter = 0.4f;
    }

    private void Update()
    {
        if (timeCounter <= 0)
        {
            SpawnRoof();
            timeCounter = Random.Range(minTime, maxTime);
        }

        timeCounter -= Time.deltaTime;
    }


    private void SpawnRoof()
    {
        GameObject newRoof = Instantiate(roof);
        newRoof.transform.position = new Vector3(13, Random.Range(minHeigth, maxHeigth), 0);
        newRoof.transform.localScale = new Vector3(Random.Range(minScale,maxScale), 7, 1);

        newRoof.transform.parent = transform; 
        //newRoof.AddComponent<MoveLeft>();
        //newRoof.GetComponent<MoveLeft>().SetSpeed(3f);

        Destroy(newRoof, destroyTime);
    }

    private GameObject GetRandomTerrain()
    {
        return terrainsList[Random.Range(0, terrainsList.Count)];
    }
}
