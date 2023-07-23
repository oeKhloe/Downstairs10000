using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    [SerializeField] GameObject[] floorPrefabs;
    public void SpawnFloor()
    {
        int nextFloor = Random.Range(0, floorPrefabs.Length);
        GameObject floor = Instantiate(floorPrefabs[nextFloor], transform);
        floor.transform.position = new Vector3(Random.Range(-3.52f, 3.76f), -6f, 1f);
    }
}
