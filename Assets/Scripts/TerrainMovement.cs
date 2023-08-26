using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMovement : MonoBehaviour
{
    [SerializeField] private float startSpeed;
    [SerializeField] private float boostSpeed;
    private float currentSpeed;

    private void Start()
    {
        currentSpeed = startSpeed;
    }

    void Update()
    {
        for(int childId = 0; childId < transform.childCount; childId++)
        {
            transform.GetChild(childId).transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        }
    }

    public void SetSpeed(float newSpeed)
    {
        currentSpeed = newSpeed;
    }

    private IEnumerator SpeedBoost(float boosTime)
    {
        yield return new WaitForSeconds(boosTime);
    }
}
