using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private int deadTime;
    [SerializeField]
    private float bulletDamage;

    private void Awake() => Destroy(gameObject, deadTime);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyController enemy = other.GetComponent<EnemyController>();

            if (!enemy.IsTakingDamage)
                StartCoroutine(enemy.TakeDamage(bulletDamage));
        }
    }
}
