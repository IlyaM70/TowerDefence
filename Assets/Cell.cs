using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private Material MainMaterial, CanMaterial, CantMaterial;
    [SerializeField] private bool canBuild;
    [SerializeField] private Transform towerPrefab;

    private Resources rs;

    private void Start()
    {
        rs = FindObjectOfType<Resources>();
    }
    private void OnMouseOver()
    {
        if (canBuild)
            GetComponent<Renderer>().material = CanMaterial;
        else
            GetComponent<Renderer>().material = CantMaterial;
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material = MainMaterial;
    }

    private void OnMouseUp()
    {
        if(canBuild && rs.Gold >= rs.TowerCost)
        {
            Instantiate(towerPrefab, transform.position, Quaternion.Euler(0,Random.Range(0,360), 0));
            rs.BuildTower();
            canBuild = false;
        }
    }
}
