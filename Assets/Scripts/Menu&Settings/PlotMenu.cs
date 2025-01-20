using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotMenu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    private GameObject towerObj;
    public TurretMenu turret;
    private Color startColor;

    private void Start()
    {
        startColor = sr.color;
    }

    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }

    private void OnMouseExit()
    {
        sr.color = startColor;
    }

    private void OnMouseDown()
    {
        if (UIManager.main.IsHoveringUI()) return;

        if (towerObj != null) return;

        Tower towerToBuild = BuildMenu.main.GetSelectedTower();

        if (towerToBuild.cost > LevelManager.main.money )
        {
            Debug.Log("Nie mozesz kupic tej wie¿y");
            return;
        }

        LevelManager.main.SpendMoney(towerToBuild.cost);

        towerObj = Instantiate(towerToBuild.prefab, transform.position + (Vector3.down*0.25f), Quaternion.identity);
        turret = towerObj.GetComponent<TurretMenu>();
        
    }
}
