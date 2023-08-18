using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    [SerializeField]
    Transform attackPoint;

    [SerializeField]
    float attackRadius = 2.0F;

    [SerializeField]
    LayerMask whatIsTarget;

    [SerializeField]
    float damage = 50.0F;

    [SerializeField]
    int attackRate = 2;

    Animator _animator;

    float _nextAttackTime = 0;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > _nextAttackTime)
        {
            _nextAttackTime = Time.time + 1.0F / attackRate;
            _animator.SetTrigger("attack");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    public void OnAttack()
    {
        Collider[] colliders =
            Physics.OverlapSphere(attackPoint.position, attackRadius, whatIsTarget);

        foreach (Collider collider in colliders)
        {
            HealthController controller = collider.GetComponent<HealthController>();
            if (controller != null)
            {
                controller.TakeDamage(damage);
            }
        }

        _animator.ResetTrigger("attack");
    }

   
}
