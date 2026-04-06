using UnityEngine;

public class CloudController : MonoBehaviour
{
    private float _speed;


    private void Awake()
    {
        _speed = Random.Range(0.5f, 1f);
    }

    private void Update()
    {
        transform.Translate(Vector2.left * (_speed * Time.deltaTime));
    }
}
