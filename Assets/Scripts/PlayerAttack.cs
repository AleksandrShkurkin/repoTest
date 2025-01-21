using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackHitbox;
    public float attackDuration = 0.2f;
    public float attackCooldown = 10f;
    private bool canAttack = true;
    public int attackDamage = 10;

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && canAttack)
        {
            Debug.Log("Attack");
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        canAttack = false;
        attackHitbox.GetComponent<Collider2D>().enabled = true;
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackHitbox.transform.position, attackHitbox.GetComponent<BoxCollider2D>().size, 0f, LayerMask.GetMask("Enemy"));
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyTemplate>().InflictDamage(attackDamage);
        }

        yield return new WaitForSeconds(attackDuration);

        attackHitbox.GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(attackCooldown);

        canAttack = true;
    }
}
