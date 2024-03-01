using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public void EndRun(int index)
    {
        SaveSystem.Instance.ResetSaveState();
        GameManager.Instance.ChangeScene(index);
    }
}
