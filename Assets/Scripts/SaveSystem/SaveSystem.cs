using System;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance { get; private set; } = null;


    private SaveState saveState;


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found another object with a LevelManager script.");
            Destroy(gameObject);
            return;
        }

        Instance = this;

        Initialize();
    }

    public void Initialize()
    {
        saveState = new SaveState();
    }

    public void ResetSaveState()
    {
        saveState = new SaveState();
    }

    public Vector3 GetPlayerStartPosition()
    {
        return new Vector3(saveState.playerSpawnX, saveState.playerSpawnY, 0);
    }

    public void SetPlayerStartPosition(Vector2 playerStartPosition)
    {
        saveState.playerSpawnX = playerStartPosition.x;
        saveState.playerSpawnY = playerStartPosition.y;
    }

    public int GetCurrentCheckPointIndex()
    {
        return saveState.checkPointIndex;
    }

    public void SetCurrentCheckPointIndex(int checkPointIndex)
    {
        saveState.checkPointIndex = checkPointIndex;
    }

    public void UpgradeFireSpell()
    {
        saveState.fireSpellUpgraded = true;
    }

    public bool IsFireSpellUpgraded()
    {
        return saveState.fireSpellUpgraded;
    }

    public void UpgradeIceSpell()
    {
        saveState.iceSpellUpgraded = true;
    }

    public bool IsIceSpellUpgraded()
    {
        return saveState.iceSpellUpgraded;
    }
}
