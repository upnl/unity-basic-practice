using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    //TODO: 일정 시간마다 적을 생성하는 스크립트를 작성해보자
    public GameObject enemy;

    private float _spawnTimeElapsed = 0f;
    public float spawnTime = 2f;
    
    private void Update()
    {
        _spawnTimeElapsed += Time.deltaTime;

        if (_spawnTimeElapsed >= spawnTime)
        {
            _spawnTimeElapsed = 0f;

            float randomX = Random.Range(-5f, 5f);
            Instantiate(enemy, transform.position + new Vector3(randomX, 0, 0), Quaternion.identity);
        }
    }
}
