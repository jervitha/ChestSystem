using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="ChestSO",menuName ="ScriptableObject/Chest")]
public class ChestSO : ScriptableObject
{
    public int minCoins;
    public int maxCoins;
    public int minGems;
    public int maxGems;
    public float timerDuration;
    public int gemsToOpen;
    
    public Sprite lockedChest;
    public string chestName;
    public Sprite unlockedChest;
    
    
}
