﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                enemy.GetComponent<Enemy>().currentState = EnemyState.stagger;
                Vector2 diff = enemy.transform.position - transform.position;
                diff = diff.normalized * thrust;
                enemy.AddForce(diff, ForceMode2D.Impulse);
                StartCoroutine(KnockCo(enemy));
            }
        }

        if (collision.gameObject.CompareTag("breakable"))
        {
            if (collision.GetComponent<Deadbush>() != null)
            {
                collision.GetComponent<Deadbush>().Attacked();
            }
        }
    }

    private IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if (enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            enemy.GetComponent<Enemy>().currentState = EnemyState.idle;
        }
    }
}
