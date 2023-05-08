using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private Enemy[] _enemys;
    [SerializeField] private int _capacity;

    private List<Enemy> _pools = new List<Enemy>();

    protected void Initialize()
    {
        for (int i = 0; i < _capacity; i++)
        {
            int randomIndex = Random.Range(0, _enemys.Length);
            
            Enemy enemy = Instantiate(_enemys[randomIndex], _container.transform);
            
            enemy.gameObject.SetActive(false);

            _pools.Add(enemy);
        }
    }

    protected bool TryGetEnemy(out Enemy enemy)
    {
        enemy = _pools.FirstOrDefault(pool => pool.gameObject.activeSelf == false);

        return enemy != null;
    }
}
