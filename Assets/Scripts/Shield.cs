using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shield : MonoBehaviour
{
    public int maxShieldStrength = 5; // Maximum hits the shield can take
    private int currentShieldStrength;
    public float rechargeDelay = 3f; // Time in seconds before the shield recharges
    private bool isRecharging = false;

    public Slider shieldBar; // Reference to the UI Slider

    void Start()
    {
        // Initialize shield strength
        currentShieldStrength = maxShieldStrength;

        // Initialize shield bar
        if (shieldBar != null)
        {
            shieldBar.maxValue = maxShieldStrength;
            shieldBar.value = currentShieldStrength;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(collision.gameObject); // Destroy the asteroid

            if (currentShieldStrength > 0)
            {
                currentShieldStrength--; // Decrease shield strength
                UpdateShieldBar();

                // Start regeneration only when shield is completely depleted
                if (currentShieldStrength <= 0 && !isRecharging)
                {
                    StartCoroutine(RechargeShield());
                }
            }
        }
    }

    private IEnumerator RechargeShield()
    {
        isRecharging = true;
        Debug.Log("Shield depleted. Starting recharge...");
        yield return new WaitForSeconds(rechargeDelay);

        currentShieldStrength = maxShieldStrength;
        Debug.Log("Shield fully recharged.");
        UpdateShieldBar();
        isRecharging = false;
    }

    private void UpdateShieldBar()
    {
        if (shieldBar != null)
        {
            shieldBar.value = currentShieldStrength;
        }
    }
}
