using UnityEngine;

public abstract class ObstacleBase : MonoBehaviour
{
    private float _destroyX = -20f;
    [SerializeField] private int _index = 0;

    private void OnEnable()
    {
        SetPosition();  // 활성화될 때 Y 위치 설정 (CactusObstacle, BirdObstacle에서 오버라이드)
    }

    private void Update()
    {
        Move();
        DestroyOutOfScreen();
    }

    private void Move()
    {
        transform.Translate(Vector2.left * Time.deltaTime * GameManager.Instance.GetSpeed());
    }

    private void DestroyOutOfScreen()
    {
        if (transform.position.x < _destroyX)
        {
            gameObject.SetActive(false);
            PoolManager.Instance.ReturnToPool(gameObject, _index);
        }
    }

    protected virtual void SetPosition()
    {
        
    }
}
