using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthManager : MonoBehaviour
{
    public static UnityAction<float> OnPlayerTakeDamage;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyData_SO enemyData = collision.gameObject.GetComponent<EnemyController>().enemyData;
            OnPlayerTakeDamage?.Invoke(enemyData.damage);
        }
    }
}
