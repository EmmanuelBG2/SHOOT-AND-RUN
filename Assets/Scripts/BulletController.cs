using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    float damage = 20.0F;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            HealthController controller = other.GetComponent<HealthController>();
            controller.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
