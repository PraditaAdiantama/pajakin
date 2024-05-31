using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject obstacle;

    public float spawInterval = 2f;
    public float spawnHeightMin = -3f;
    public float spawnHeightMax = 3f;

    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawInterval){
            SpawnObject();
            timer = 0f;
        }
    }

    void SpawnObject(){
        float spawnY = Random.Range(spawnHeightMin, spawnHeightMax);
        Vector3 spawnPosition = new Vector3(transform.position.x, spawnY, 0);
        Instantiate(obstacle, spawnPosition, Quaternion.identity);
    }
}
