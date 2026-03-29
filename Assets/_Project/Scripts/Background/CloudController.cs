using UnityEngine;


public class CloudController : MonoBehaviour
{
    private float _speed;

    private const float LeftBound  = -10f;
    private const float RightBound =  20f;

    private void Awake()
    {
        _speed = Random.Range(0.5f, 1f);
    }

    private void Update()
    {
        transform.Translate(Vector2.left * (_speed * Time.deltaTime));

        if (transform.position.x <= LeftBound)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        float randomY = Random.Range(1f, 3.5f);
        transform.position = new Vector2(RightBound, randomY);
        _speed = Random.Range(0.5f, 1f);  // 재배치 시 속도도 새로 랜덤 설정
    }
}
