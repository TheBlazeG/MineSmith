using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    public float moneyGained=1;

    // Mouse up as button, basicamente jala como botón ahora xd
    private void OnMouseUpAsButton()
    {
        if (this.CompareTag("Upgrade"))
        {
            Upgrade.instance.UpgradeClick();
        }
        else Money.instance.UpdateMoney(moneyGained);
        Debug.Log("monke");
    }
    //mouseenter y exit sirven para efectos de hover como hacer el objeto mas grande o que brille
    private void OnMouseEnter()
    {
        gameObject.transform.localScale = new Vector3(1.2f,1.2f,1.2f);
    }

    private void OnMouseExit()
    {
        gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
