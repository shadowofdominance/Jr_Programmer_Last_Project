using UnityEngine;

public class ChargingEnemy : BaseEnemy
{
    private float chargeForce = 80;
    private float chargeCooldown = 3f;
    private float timer;
    
    protected override void Move()
    {
        timer += Time.fixedDeltaTime;

        if (timer >= chargeCooldown)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            enemyRb.AddForce(direction * chargeForce, ForceMode.Impulse);
            timer = 0f;
        }
    }
}
