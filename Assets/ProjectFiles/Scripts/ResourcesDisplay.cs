using TMPro;
using UnityEngine;

public class ResourcesDisplay :MonobehaviourSingleton<ResourcesDisplay>
{
    public int coins { get; private set; } = 0;
    public int gems { get; private set; } = 0;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI gemsText;

    public void AddCoins(int amount)
    {
        coins += amount;
        
        UpdateUI();
    }

    public void AddGems(int amount)
    {
        gems += amount;
        
        UpdateUI();
    }

    
    private void UpdateUI()
    {
        coinsText.text = "Coins: " + coins.ToString();
        gemsText.text = "Gems: " + gems.ToString();

    }
    
}
