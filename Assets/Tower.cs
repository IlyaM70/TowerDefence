using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float fireDelay, radius, damage;
    [SerializeField] private Transform bulletPrefab;
    [SerializeField] private LayerMask enemyLayer;
    private float timeToFire;
    private Transform cannon, enemy, firePoint;
    void Start()
    {
        timeToFire = fireDelay;

        cannon = transform.GetChild(0);
        firePoint = cannon.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToFire > 0)
            timeToFire -= Time.deltaTime;
        else if(enemy)
            Fire();
        if(enemy)
        {
            Vector3 lookAt = enemy.position;
            lookAt.y = cannon.position.y;
            cannon.rotation = Quaternion.LookRotation(lookAt - cannon.position );

            if (Vector3.Distance(transform.position, enemy.position) > radius)
                enemy = null;
        }
        else
        {
            Collider[] colls = Physics.OverlapSphere(transform.position, radius, enemyLayer);
            if (colls.Length > 0)
                enemy = colls[0].transform;

        }
    }

    private void Fire()
    {
        Transform bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.LookAt(enemy.GetChild(0));
        bullet.GetComponent<Bullet>().Damage = damage;
        timeToFire = fireDelay;
    }
}
