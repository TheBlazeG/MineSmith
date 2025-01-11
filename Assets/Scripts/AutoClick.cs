using UnityEngine;

public class AutoClick : MonoBehaviour
{
    public int currencyIncrement = 1; // Amount of currency to add per click
    public float clickInterval = 1f; // Time between automatic clicks
    public float rotationAngle = 10f; // Angle of rotation for the click animation
    public float backwardSpeed = 1f; // Speed of backward rotation
    public float forwardSpeed = 5f; // Speed of forward rotation

    private Money moneyManager; // Reference to the Money script
    private bool isActive = false; // Determines if the script is active

    public void Start()
    {
        moneyManager = FindObjectOfType<Money>();
        if (moneyManager == null)
        {
            Debug.LogError("Money script not found in the scene!");
        }
        InvokeRepeating(nameof(AutoClicker), clickInterval, clickInterval);
    }

    public void AutoClicker()
    {
        if (moneyManager != null)
        {
            // Add currency
            moneyManager.UpdateMoney(currencyIncrement);

            // Rotate animation
            StartCoroutine(RotatePickaxe());
        }
    }

    private System.Collections.IEnumerator RotatePickaxe()
    {
        float currentRotation = 0f;

        // Rotate backward
        while (currentRotation > -rotationAngle)
        {
            currentRotation -= backwardSpeed * Time.deltaTime;
            transform.localEulerAngles = new Vector3(0, 0, currentRotation);
            yield return null;
        }

        // Rotate forward
        while (currentRotation < 0f)
        {
            currentRotation += forwardSpeed * Time.deltaTime;
            transform.localEulerAngles = new Vector3(0, 0, currentRotation);
            yield return null;
        }
    }
}
