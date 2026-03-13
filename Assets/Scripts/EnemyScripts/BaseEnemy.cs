using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected Rigidbody enemyRb;
    protected Transform playerTransform;
    
    public float moveSpeed;

    protected virtual void Awake()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerTransform = GameObject.FindWithTag("Player").transform;
    }
    
    protected abstract void Move();

    protected virtual void FixedUpdate()
    {
        Move();
    }
}
