using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    private Sprite sprite;

    private float moveSpeed;
    private float health;
    private float damage;

    [HideInInspector] public EnemyData_SO enemyData;

    private Transform target;

    private void Start()
    {
        moveSpeed = enemyData.moveSpeed;
        health = enemyData.health;
        damage = enemyData.damage;
        sprite = enemyData.sprite;

    }

    private void Awake()
    {
        target = FindObjectOfType<PlayerMovement>().transform;
    }

    private void Update()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

    }

}
