using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
   // private Enemy _enemy;
    [SerializeField] private Enemy[] _enemys;
    [SerializeField] private int _capacity;

    private List<GameObject> _pools = new List<GameObject>();

    //protected void Initialize()
    //{
    //    for (int i = 0; i < _capacity; i++)
    //    {
    //        GameObject spawned = Instantiate(_enemy.gameObject, _container.transform);
            
    //        spawned.SetActive(false);

    //        _pools.Add(spawned);
    //    }
    //}

    protected void Initialize()
    {
        for (int i = 0; i < _capacity; i++)
        {
            int randomIndex = Random.Range(0, _enemys.Length);
            
            GameObject spawned = Instantiate(_enemys[randomIndex].gameObject, _container.transform);
            
            spawned.SetActive(false);

            _pools.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pools.FirstOrDefault(pool => pool.activeSelf == false);

        return result != null;
    }
}
