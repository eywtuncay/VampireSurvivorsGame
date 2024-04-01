using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    private float moveSpeed;
    private float health;
    private float damage;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public ObjectPool enemyPool;


    public EnemyData_SO enemyData;

    private Transform target;

    private void Start()
    {
        health = enemyData.health;
        damage = enemyData.damage;
        moveSpeed = enemyData.moveSpeed;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = enemyData.sprite;
        
        animator = GetComponent<Animator>();
        animator.Play(enemyData.walkAnimation.name);
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

    public void ReturnEnemyToPool()
    {
        enemyPool.ReturnObjectToPool(gameObject);
    }
}
