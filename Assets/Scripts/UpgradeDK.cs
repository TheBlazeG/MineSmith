using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public AudioSource upgradeSoundpickaxe;
    public float upgradeMultiplier = 1;
    public float upgradeCost;
    private Money moneyManager;
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
            instance.counter.text = instance.upgradeCost.ToString("C", new CultureInfo("en-US"));
        instance.counter = counter;

        moneyManager = FindObjectOfType<Money>();
        if (moneyManager == null)
        {
            Debug.LogError("Money script not found in the scene!");
        }
    }

    private void OnMouseEnter()
    {
        gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }
    private void OnMouseDown()
    {
        gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        TryUpgrade();
    }
    private void OnMouseUpAsButton()
    {
        gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }

        private void OnMouseExit()
    {
        gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    private void TryUpgrade()
    {
        if (moneyManager != null && moneyManager.money >= upgradeCost)
        {
            moneyManager.SubtractCurrency(upgradeCost);

            upgradeCost = Mathf.CeilToInt(upgradeCost * upgradeMultiplier);
            GameObject.FindWithTag("Clicker").GetComponent<Clicker>().moneyGained++;
            instance.counter.text = instance.upgradeCost.ToString("C", new CultureInfo("en-US"));
            upgradeSoundpickaxe.Play();
        }
        else
        {
            Debug.Log("Not enough currency to upgrade");
        }
    }
}
