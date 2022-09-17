using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Obstacle Obstacle;

    public int ObstacleCount = 10;

    void Start()
    {
        GenerateLevel2();
    }

    public void GenerateLevel()
    {
        for (int i = 0; i < ObstacleCount; i++)
        {
            Instantiate(Obstacle, new Vector3(0.1f * Mathf.Pow(i+1, 2) + 5, 1, 0), Quaternion.identity);
        }
    }

    public void GenerateLevel2()
    {
        for (int i = 0; i < ObstacleCount; i++)
        {
            Instantiate(Obstacle, new Vector3(Random.Range(5, 18), 1, Random.Range(-0.5f, 0.5f)), Quaternion.identity);
        }
    }
}
