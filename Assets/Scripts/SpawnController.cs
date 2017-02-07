using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    public float maxHeigth;
    public float minHeight;

    public float rateSpawn;
    public float currentRateSpawn;

    public GameObject pipesPreFab;

    public int maxSpawnPipes;

    public List<GameObject> pipes;

    void Start()
    {
        for (int i = 0; i < maxSpawnPipes; i++)
        {
            GameObject temp = Instantiate(pipesPreFab) as GameObject;
            pipes.Add(temp);
            temp.SetActive(false);
            currentRateSpawn = rateSpawn;
        }
    }

    void Update()
    {
        if (GameController1.status == 1)
        {
            currentRateSpawn += Time.deltaTime;
            if (currentRateSpawn > rateSpawn)
            {
                currentRateSpawn = 0;
                Spawn();
            }
        }
    }

    private void Spawn()
    {
        float randHeigth = Random.Range(minHeight, maxHeigth);
        GameObject pipe = null;
        for (int i = 0; i < maxSpawnPipes; i++)
        {
            if (pipes[i].activeSelf == false)
            {
                pipe = pipes[i];
                break;
            }
        }
        if (pipe != null)
        {
            pipe.transform.position = new Vector3(transform.position.x, randHeigth, 0);
            pipe.SetActive(true);
        }
    }
}
