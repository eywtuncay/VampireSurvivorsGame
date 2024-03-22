using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/Enemy", order = 1)]
public class EnemyData_SO : ScriptableObject
{
    public Sprite sprite;
    public float moveSpeed;
    public float health;
    public float damage;
}
