using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public static ObstacleManager Instance { get; private set; }
    private ObstacleSpawnTimer _spawnTimer = new ObstacleSpawnTimer();
    private int _cactusObstacleCnt = 3;
    private int _birdObstacleCnt = 1;
    
    private void Awake()
    {
        RegisterSingleton();
        _spawnTimer.Reset();
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

    private void Update()
    {
        _spawnTimer.Tick(Time.deltaTime);

        if (_spawnTimer.ShouldSpawn())
        {
            SpawnObstacle();
            _spawnTimer.OnSpawned();
        }
    }

    private void SpawnObstacle()
    {
        float currentSpeed = GameManager.Instance.GetSpeed();
        GameObject obstacle = GetRandomPrefab(currentSpeed);
        obstacle.transform.position = new Vector2(20f, 0f);
        obstacle.SetActive(true);
    }

    private GameObject GetRandomPrefab(float speed)
    {
        int cnt = _cactusObstacleCnt + (speed < 8f ? 0 : _birdObstacleCnt);
        int randomIndex = Random.Range(0, cnt);
        return PoolManager.Instance.GetPool(randomIndex);
    }
}

// 장애물 스폰 타이머
public class ObstacleSpawnTimer
{
    private float _timer;
    private float _spawnInterval;

    public void Reset()
    {
        _timer = 0f;
        _spawnInterval = 3f;
    }

    public void Tick(float deltaTime)
    {
        _timer += deltaTime;
    }

    public bool ShouldSpawn()
    {
        return _timer >= _spawnInterval;
    }

    public void OnSpawned()
    {
        _timer = 0f;

        float speed = GameManager.Instance.GetSpeed();
        float minInterval = 10f / speed;
        float maxInterval = minInterval * 1.5f;
        _spawnInterval = Random.Range(minInterval, maxInterval);
    }
}
