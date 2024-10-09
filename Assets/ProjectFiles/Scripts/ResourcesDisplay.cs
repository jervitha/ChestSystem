using TMPro;
using UnityEngine;

public class ResourcesDisplay :MonobehaviourSingleton<ResourcesDisplay>
{
    private int coins;

    private int gems;
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
    public int GetCoins()
    {
        return coins;
    }
    public int GetGems()
    {
        return gems;
    }


    
}
