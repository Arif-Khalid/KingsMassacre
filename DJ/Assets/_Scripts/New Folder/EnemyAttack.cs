using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackDamage = 1f;
    public float attackInterval = 1;
    IEnumerator ieObject;
    PlayerManager playerManager;

    private void OnCollisionEnter2D(Collision2D other)
    {
        // if collision with player
        if (other.gameObject.tag == "Player")
        {
            playerManager = other.gameObject.GetComponent<PlayerManager>();
            // Debug.Log("collision with player");
            ieObject = Attack();
            StartCoroutine(ieObject);
            // add take damage to player
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        // if no more collision with player
        if (other.gameObject.tag == "Player")
        {
            // Debug.Log("no collision with player");
            StopCoroutine(ieObject);
            // stop take damage to player
        }
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        // if collision with player
        if (other.gameObject.tag == "Player") {
            // Debug.Log("collision with player");
            ieObject = Attack();
            StartCoroutine(ieObject);
            // add take damage to player
        }
    }
    void OnTriggerExit2D(Collider2D other) 
    {
        // if no more collision with player
        if (other.gameObject.tag == "Player") {
            // Debug.Log("no collision with player");
            StopCoroutine(ieObject);
            // stop take damage to player
        }
    }
    IEnumerator Attack() {
        while (attackInterval != 0) {
            // attack function call
            playerManager.TakeDamage(attackDamage);
            Debug.Log("attacking player");
            yield return new WaitForSeconds(attackInterval);
        }
    }
    
}
/*
Enemy attack:
- does damage to player based on attackDamage
- 

*/