using System.Collections;
using UnityEngine;

public class Spawner : EnemyPool
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondBetweenSpawn;

    private void Start()
    {
       Initialize();
       StartCoroutine(SecondBetweenSpawn());
    }

    private void SetEnemy(Enemy enemy, Vector3 spawnPoint)
    {
        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;
    }

    private IEnumerator SecondBetweenSpawn()
    {
        var waitForSecond = new WaitForSeconds(_secondBetweenSpawn);

        while(true)
        {
            if (TryGetEnemy(out Enemy enemy))
            {
                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
            }

            yield return waitForSecond;
        }
    }
}
