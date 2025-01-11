using TMPro;
using UnityEngine;

public class AutoClickUpgradeDK : MonoBehaviour
{
    public GameObject objectPrefab; // Prefab for the objects to instantiate
    public Transform rotationCenter; // Center of rotation for instantiated objects
    public float baseDistance = 2f; // Base distance multiplier for instantiating objects
    public int baseUpgradeCost = 10; // Initial cost of the upgrade
    public float upgradeCostMultiplier = 1.5f; // Multiplier for upgrade cost increase

    private int instantiatedCount = 0; // Current count of instantiated objects
    private int currentUpgradeCost; // Current cost of the next upgrade
    private Money moneyManager; // Reference to the Money script

    private float currentMoney;
    [SerializeField] private TextMeshProUGUI counter;
    public static AutoClickUpgradeDK instance { get; private set; }

    private void Start()
    {
        moneyManager = FindObjectOfType<Money>();
        if (moneyManager == null)
        {
            Debug.LogError("Money script not found in the scene!");
        }

        // Initialize the upgrade cost
        currentUpgradeCost = baseUpgradeCost;

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
            instance.counter.text = instance.currentUpgradeCost.ToString();
        }
    }

    private void OnMouseDown()
    {
        TryUpgrade();
    }

    private void TryUpgrade()
    {
        if (moneyManager != null && moneyManager.money >= currentUpgradeCost)
        {
            // Subtract the cost
            moneyManager.SubtractCurrency(currentUpgradeCost);

            // Increase the upgrade cost
            currentUpgradeCost = Mathf.CeilToInt(currentUpgradeCost * upgradeCostMultiplier);
            instance.counter.text = instance.currentUpgradeCost.ToString();

            // Instantiate the new object
            InstantiateObject();
        }
        else
        {
            Debug.Log("Not enough currency to upgrade!");
        }
    }

    private void InstantiateObject()
    {
        instantiatedCount++;

        // Calculate angle and distance
        float angle = instantiatedCount * (360f / 10f); // Spread objects evenly around the center
        float distance = baseDistance * rotationCenter.localScale.x; // Adjust distance by center's scale
        Vector3 positionOffset = Quaternion.Euler(0, 0, angle) * Vector3.right * distance; // Apply offset

        // Determine the new position
        Vector3 newPosition = rotationCenter.position + positionOffset;

        // Instantiate the new object
        GameObject newObject = Instantiate(objectPrefab, newPosition, Quaternion.identity);

        // Assign the rotation center for the new object
        AutoClickUpgradeDK newUpgrade = newObject.GetComponent<AutoClickUpgradeDK>();
        if (newUpgrade != null)
        {
            newUpgrade.rotationCenter = rotationCenter;
        }

        // Activate auto-click for the new object
        Clicker newClicker = newObject.GetComponent<Clicker>();
        if (newClicker != null)
        {
            newClicker.enabled = true; // Enable the Clicker script on the new object
        }
    }
}
