using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    [SerializeField] GameObject[] FloorPrefabs;
    public void SpawnFloor()
    {
        // Random.Range(0, floorPrefabs.length);
        // GameObject floor = Instantiate(floorPrefabs[r], transform);
        // floor.transform.position = new Vector3(Random.Range(-3.52f, 3.76f), -6f, 1f);
    }
}
