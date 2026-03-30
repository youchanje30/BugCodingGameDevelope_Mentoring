using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance { get; private set; }
    private Stack<GameObject>[] _obstaclePools;
    [SerializeField] private GameObject[] _obstaclePrefabs;

    private void Awake()
    {
        RegisterSingleton();
        _obstaclePools = new Stack<GameObject>[_obstaclePrefabs.Length];
        for (int i = 0; i < _obstaclePools.Length; i++)
            _obstaclePools[i] = new Stack<GameObject>();
    }

    private void RegisterSingleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void ReturnToPool(GameObject obj, int index)
    {
        _obstaclePools[index].Push(obj);
    }

    public GameObject GetPool(int index)
    {
        GameObject pool = null;
        if (_obstaclePools[index].Count > 0)
            pool = _obstaclePools[index].Pop();
        else
            pool = Instantiate(_obstaclePrefabs[index]);
        return pool;
    }
}