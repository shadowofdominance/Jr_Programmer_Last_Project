using UnityEngine;

public class FastEnemy : BaseEnemy
{
    protected override void Move()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        enemyRb.AddForce(direction * moveSpeed * 2);
    }
}
