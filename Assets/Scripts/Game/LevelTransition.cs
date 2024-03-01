using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    [SerializeField]
    private int levelToLoad;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.ChangeScene(levelToLoad);
    }
}
