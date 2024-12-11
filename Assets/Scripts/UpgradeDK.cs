using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public float upgradeValue = 15;
    public float upgradeMultiplier = 1;
    public float upgradeCost;
    private float currentMoney;
    [SerializeField] private TextMeshProUGUI counter;
    public static Upgrade instance { get; private set; }

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
            instance.counter.text = instance.upgradeCost.ToString();
        instance.counter = counter;
    }

    // Update is called once per frame
    void Update()
    {
        currentMoney = Money.instance.money;
        upgradeCost = upgradeValue * upgradeMultiplier;
        instance.counter.text = instance.upgradeCost.ToString();
    }

    public void UpgradeClick()
    {
        Debug.Log("Buying upgrade, current money: " + currentMoney);
        if (currentMoney >= upgradeCost)
        {
            Money.instance.money -= upgradeValue;
            upgradeMultiplier += 1f;
            GameObject.FindWithTag("Clicker").GetComponent<Clicker>().moneyGained++;
            instance.counter.text = instance.upgradeCost.ToString();
        }
    }
}
