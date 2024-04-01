using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerSkill_SO[] playerSkill_SOs;
    public List<GameObject> enemies;


    private void Update()
    {
        InitializeEnemies();

        Attack();
    }
    public void InitializeEnemies()
    {
        // Clear the list before populating it to avoid duplicates
        enemies.Clear();

        foreach (EnemyController enemyController in FindObjectsOfType<EnemyController>())
        {
            // Check if the enemy is already in the list before adding
            if (!enemies.Contains(enemyController.gameObject))
            {
                enemies.Add(enemyController.gameObject);
            }
        }
    }


    public void Attack()
    {
        PlayerSkill_SO skill = playerSkill_SOs[0];
        
            Transform target = FindTarget();
            if (target != null)
            {
                Instantiate(skill.prefab, transform.position, Quaternion.identity);
                Vector2 targetPosition = new Vector2(target.position.x, target.position.y);
                skill.prefab.transform.Translate(targetPosition);
            }
        
    }

    public Transform FindTarget()
    {
        foreach (PlayerSkill_SO skill in playerSkill_SOs)
        {
            GameObject closestObject = null;
            float closestDistance = Mathf.Infinity;

                foreach (GameObject obj in enemies)
                {
                    float distance = Vector3.Distance(obj.transform.position, transform.position);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestObject = obj;
                    }
                }
            
            if (closestObject != null)
            {
                return closestObject.transform;
            }
        }
        return null;
    }
}
