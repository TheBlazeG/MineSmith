using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.EditorTools;
using UnityEngine;
public class Clicker : MonoBehaviour
{
    public float moneyGained=1;
    public AudioSource ClickingSound;
    [SerializeField] public GameObject MegaMineral;
    [SerializeField] public GameObject Dmoney;
    [SerializeField] public GameObject DPunish;

    public static Clicker instance { get; private set; }

    private void Start()
    {
        if (instance == null && !CompareTag("Upgrade"))
        {
            instance = this;

        }
        else
        {
            if(!CompareTag("Upgrade"))
            Destroy(gameObject);
        }
    }
    // Mouse up as button, basicamente jala como botón ahora xd
    private void OnMouseUpAsButton()
    {
        Money.instance.UpdateMoney(moneyGained);
        gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        ClickingSound.Play();
    }
    //mouseenter y exit sirven para efectos de hover como hacer el objeto mas grande o que brille
    private void OnMouseEnter()
    {
        gameObject.transform.localScale = new Vector3(1.2f,1.2f,1.2f);
    }
    private void OnMouseDown()
    {
        gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
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
