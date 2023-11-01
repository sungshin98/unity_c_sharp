using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnPoint;

    void Start()
    {
        // Start 함수에서 지연 생성 호출
        Invoke("SpawnObject", 0.5f);
    }

    void SpawnObject()
    {
        // objectToSpawn 프리팹을 spawnPoint 위치에 생성
        Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity);
    }
}