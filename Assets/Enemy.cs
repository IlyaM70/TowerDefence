using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] Points;
    public float Speed, RotationSpeed;
    [HideInInspector] public float HP;
    private Resources rs;

    private int index;
    private Transform currentPoint;
    private Vector3 direction;
    void Start()
    {
        index = 0;
        currentPoint = Points[index];
        rs = FindObjectOfType<Resources>();
    }
    
    
    void Update()
    {
        direction = currentPoint.position - transform.position;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, RotationSpeed * Time.deltaTime, 0);

        transform.rotation = Quaternion.LookRotation(newDirection);

        transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, Speed*Time.deltaTime);

        if(transform.position == currentPoint.position)
        {
            index++;
            if(index>=Points.Length)
            {
                rs.MissEnemy();
                Destroy(gameObject);

            }
            else
            {
               currentPoint = Points[index];
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            HP -= other.GetComponent<Bullet>().Damage;

            if(HP <=0)
            {
                rs.KillEnemy();
                Destroy(gameObject);

            }
        }
    }
}
