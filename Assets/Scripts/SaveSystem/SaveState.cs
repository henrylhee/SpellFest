

[System.Serializable]
public class SaveState
{
    public int checkPointIndex;
    public float  playerSpawnX;
    public float playerSpawnY;
    public bool iceSpellUpgraded;
    public bool fireSpellUpgraded;


    public SaveState()
    {
        checkPointIndex = 0;
        playerSpawnX = 0;
        playerSpawnY = 0;
        iceSpellUpgraded = false;
        fireSpellUpgraded = false;
    }
}
