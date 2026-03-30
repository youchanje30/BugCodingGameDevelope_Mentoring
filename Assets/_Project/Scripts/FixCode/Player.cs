using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D _collider2D;
    private Animator _animator;

    [SerializeField] private GameObject _spriteObject;
    [SerializeField] private LayerMask _groundLayer;

    [SerializeField] public float jumpForce = 10f;
    [SerializeField] public float highJumpForce = 30f;

    private void Awake()
    {
        _collider2D = GetComponent<BoxCollider2D>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    public bool IsGrounded()
    {
        return true;
    }

    private void Dead()
    {
        GameManager.Instance.GameOver();
    }

    public void SetJump()
    {
        
    }

    public void SetSlide()
    {
        _spriteObject.transform.localRotation = new quaternion(0, 0, -1f, 1);
        _spriteObject.transform.localPosition = new Vector3(-0.5f, 0.3f, 0);
        _spriteObject.transform.localScale = new Vector3(.5f, 1, 1);
    }

    public void SetIdle()
    {
        _spriteObject.transform.localPosition = new Vector3(0, 0, 0);
        _spriteObject.transform.localRotation = new quaternion(0, 0, 0, 1);
        _spriteObject.transform.localScale = Vector3.one;

        _collider2D.size = new Vector2(0.65f, 0.9f);
        _collider2D.offset = new Vector2(0.01f, 0.5f);
    }
    
}
