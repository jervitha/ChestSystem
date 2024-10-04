using UnityEngine;
using TMPro; // For updating the UI

public class ResourcesDisplay : MonoBehaviour
{
    // Singleton instance
    public static ResourcesDisplay Instance { get; private set; }

    // Variables for coins and gems
    private int coins = 0;
    private int gems = 0;

    // UI elements to display coins and gems
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI gemsText;

    private void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Ensures the object persists between scenes
        }
    }

    // Method to add coins
    public void AddCoins(int amount)
    {
        coins += amount;
        Debug.Log($"Added {amount} gems. Total gems: {gems}");
        UpdateUI();
    }

    // Method to add gems
    public void AddGems(int amount)
    {
        gems += amount;
        Debug.Log($"Added {amount} gems. Total gems: {gems}");
        UpdateUI();
    }

    // Update the UI with the latest values of coins and gems
    private void UpdateUI()
    {
        coinsText.text = "Coins: " + coins.ToString();
        gemsText.text = "Gems: " + gems.ToString();
        Debug.Log($"UI Updated - Coins: {coins}, Gems: {gems}");
    }

    // Optional: Methods to get current values of coins and gems
    public int GetCoins() => coins;
    public int GetGems() => gems;
}
