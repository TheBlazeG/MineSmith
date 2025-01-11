using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    public float money = 0,multiplier = 1;
    public static Money instance { get; private set; }
    [SerializeField] private TextMeshProUGUI counter;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
        instance = this;
        
        } 
        else
        {
            Destroy(gameObject);
        }
        if (PlayerPrefs.HasKey("PlayerMoney"))
        {
            money=PlayerPrefs.GetFloat("PlayerMoney");
            instance.counter.text = instance.money.ToString();
        }
        instance.counter = counter;
    }

    // Update is called once per frame
    void Update()
    {
        instance.counter.text = instance.money.ToString();
    } 
    
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("PlayerMoney", money);
    }

    public void UpdateMoney(float gain)
    {
        instance.money += gain*multiplier;
        instance.counter.text = instance.money.ToString();
    }
}
