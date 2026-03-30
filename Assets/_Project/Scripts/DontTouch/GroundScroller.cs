using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    [SerializeField] private Transform[] _grounds;
    private float _groundWidth;

    void Awake()
    {
        _groundWidth = _grounds[0].GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        foreach (Transform ground in _grounds)
        {
            ground.Translate(Vector2.left * (GameManager.Instance.GetSpeed() * Time.deltaTime));

            if (ground.position.x <= -_groundWidth - 9)
            {
                ground.position += Vector3.right * (_groundWidth * _grounds.Length);
            }
        }
    }
}
