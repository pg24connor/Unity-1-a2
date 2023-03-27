using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    private float _spawnTimeMin = 0.5f;

    [SerializeField]
    private float _spawnTimeMax = 3f;

    [SerializeField]
    private float _spawnRadius = 60f;

    [SerializeField]
    private GameObject _asteroidPrefab;

    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            SpawnAsteroid();
            yield return new WaitForSeconds(GetRandomSpawnDelay());
        }
    }

    private void SpawnAsteroid()
    {
        Vector3 startPosition = GetRandomPointAroundCircle();
        Vector3 endPosition = GetRandomPointAroundCircle();

        GameObject asteroid = Instantiate(_asteroidPrefab, startPosition, Quaternion.identity);
        asteroid.transform.LookAt(endPosition);
    }

    private Vector3 GetRandomPointAroundCircle()
    {
        Vector2 point2D = Random.insideUnitCircle * _spawnRadius;

        return new Vector3(point2D.x, 0f, point2D.y);
    }

    private float GetRandomSpawnDelay()
    {
        return Random.Range(_spawnTimeMin, _spawnTimeMax);
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(gameObject.transform.position, _spawnRadius);
    //}
}
