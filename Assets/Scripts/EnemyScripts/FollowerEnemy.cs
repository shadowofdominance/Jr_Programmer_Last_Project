using UnityEngine;

public class FollowerEnemy : BaseEnemy
{
    protected override void Move()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        enemyRb.AddForce(direction * moveSpeed);
    }
}
