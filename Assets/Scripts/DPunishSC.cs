using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPunishSC : MonoBehaviour
{
    float time;
    private void Start()
    {
        time = Time.time;

    }
    private void Update()
    {
        if (Time.time - time > 5)
        {
            Money.instance.UpdateMoney(Clicker.instance.moneyGained * 2);
            Destroy(gameObject);
        }
    }

    private void OnMouseEnter()
    {
        gameObject.transform.localScale = new Vector3(3.2f, 3.2f, 3.2f);
    }
    private void OnMouseDown()
    {
        gameObject.transform.localScale = new Vector3(3f, 3f, 3f);
    }

    private void OnMouseExit()
    {
        gameObject.transform.localScale = new Vector3(3f, 3f, 3f);
    }

    private void OnMouseUpAsButton()
    {

        Money.instance.UpdateMoney(Clicker.instance.moneyGained * -10);
        Debug.Log("monke");
        gameObject.transform.localScale = new Vector3(3.2f, 3.2f, 3.2f);
        Destroy (gameObject);
    }
}
