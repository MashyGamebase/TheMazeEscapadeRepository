using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForEntities : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyAI>().Die();
        }
    }
}