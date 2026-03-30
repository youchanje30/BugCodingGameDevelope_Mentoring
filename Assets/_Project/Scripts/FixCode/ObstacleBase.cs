using UnityEngine;

public abstract class ObstacleBase : MonoBehaviour
{
    private float _destroyX = -20f;
    [SerializeField] private int _index = 0;

    private void OnEnable()
    {
        SetPosition();
    }

    private void Update()
    {
        Move();
        DestroyOutOfScreen();
    }

    private void Move()
    {
        transform.Translate(Vector2.left * GameManager.Instance.GetSpeed());
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
