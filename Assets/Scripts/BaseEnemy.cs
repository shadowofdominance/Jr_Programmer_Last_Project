using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected Rigidbody enemyRb;
    public float moveSpeed;

    protected virtual void Awake()
    {
        enemyRb = GetComponent<Rigidbody>();
    }
    
    protected abstract void Move();
}
