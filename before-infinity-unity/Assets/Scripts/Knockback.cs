using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{

    public float thrust;
    public float knockTime;
    public AudioSource audioSrc;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("GOLPE");
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemyInfo = other.GetComponent<Enemy>();
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if(enemy != null)
            {
                enemy.isKinematic = false;
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * thrust;
                enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockCo(enemy, enemyInfo));
            }
        }
    }

    private IEnumerator KnockCo(Rigidbody2D enemy, Enemy enemyInfo)
    {
        if(enemy != null)
        {
            enemyInfo.health -= 1;
            enemyInfo.audioSrcHurt.Play();
            if (enemyInfo.health <= 0)
            {
                enemyInfo.audioSrcDeath.Play();
                StartCoroutine(DestroyEnemy(enemy));
                
            }
            else
            {
                yield return new WaitForSeconds(knockTime);
                enemy.velocity = Vector2.zero;
                enemy.isKinematic = true;
            }
        }
    }

    private IEnumerator DestroyEnemy(Rigidbody2D enemy)
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(enemy.gameObject);
    }

}
