using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyAI;


public class MeleeDamage : MonoBehaviour
{
    public float meleeDamage = 0f;
    public float meleeModifier = 1f;
    public float meleeRange = 1f;
    public Transform meleeOrigin;  
    public LayerMask shotMask;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            meleeDamage += meleeModifier * Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(0))
        {
            MeleeHit();
            meleeDamage = 0;
        }
    }

    void MeleeHit()
    {
        if (Physics.Raycast(meleeOrigin.position, meleeOrigin.forward, out RaycastHit hit, meleeRange, shotMask))
        {
            //laserLine.SetPosition(1, hit.point);

            // Call the damage behaviour of target if exists.
            if (hit.collider)
                hit.collider.SendMessageUpwards("HitCallback", new HealthManager.DamageInfo(hit.point, meleeOrigin.forward, meleeDamage, hit.collider), SendMessageOptions.DontRequireReceiver);
        }
    }
}
