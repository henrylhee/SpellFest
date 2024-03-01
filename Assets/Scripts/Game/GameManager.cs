using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } = null;


    private const string startScenePath = "Scenes/Menus/MainMenu";

    private SceneLoader sceneLoader;

    private Coroutine pauseTimer;


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found another object with a GameManager script: " + Instance.gameObject.name);
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        sceneLoader = new SceneLoader();
        SaveSystem.Instance.Initialize();
    }

    public void ChangeScene(int scene)
    {
        sceneLoader.ChangeScene(scene);
    }

    public void PauseGame(float duration)
    {
        StopCoroutine(pauseTimer);
        pauseTimer = StartCoroutine(PauseTimer(duration));
    }

    public IEnumerator PauseTimer(float duration)
    {
        Time.timeScale = 0;
        yield return new WaitForSeconds(duration);
        Time.timeScale = 1;
    }
}
