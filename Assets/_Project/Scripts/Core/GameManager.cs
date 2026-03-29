using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private const float InitialSpeed = 6f;
    private const float MaxSpeed = 13f;
    private const float SpeedAccelerationPerFrame = 0.001f;
    private const float FrameRate = 60f;
    private const float ScoreCoefficient = 0.025f;

    private float _score;
    private float _distanceRan;
    private float _speed = InitialSpeed;

    private void Awake()
    {
        RegisterSingleton();
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
        _speed = Mathf.Min(MaxSpeed, _speed + SpeedAccelerationPerFrame * FrameRate * Time.deltaTime);
        _distanceRan += _speed * Time.deltaTime * FrameRate;
        _score = Mathf.Round(Mathf.Ceil(_distanceRan) * ScoreCoefficient);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;  // 게임 전체를 멈춤
    }


    public float GetScore()
    {
        return _score;
    }

    public float GetSpeed()
    {
        return _speed;
    }
}
