using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSkill", menuName = "ScriptableObjects/PlayerSkill", order = 1)]
public class PlayerSkill_SO : ScriptableObject
{
    public PlayerAttackTypes attackType; 
    public Transform target;
    public GameObject prefab;
    public float moveSpeed;
    public float attackRate;
    public float damage;

}
