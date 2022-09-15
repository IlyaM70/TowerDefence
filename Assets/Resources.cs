using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resources : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI GoldTxt, LivesTxt;
    public int Gold, TowerCost, EnemyCost, Lives;

    [SerializeField] private GameObject PanelResources, DeathPanel;

    private void Start()
    {
        DeathPanel.SetActive(false);
        GoldTxt.text = "Gold:" + Gold;
        LivesTxt.text = "Lives:" + Lives;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MissEnemy()
    {
        Lives--;
        LivesTxt.text = "Lives:" + Lives;
        if (Lives <=0)
        {
            PanelResources.SetActive(false);
            DeathPanel.SetActive(true);
        }
    }

    public void BuildTower()
    {
        Gold -= TowerCost;
        GoldTxt.text = "Gold:" + Gold;
    }

    public void KillEnemy()
    {
        Gold += EnemyCost;
        GoldTxt.text = "Gold:" + Gold;
    }
}
