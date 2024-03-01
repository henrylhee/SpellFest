using System.Collections;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    private float shakeDuration = 2/5f;
    private float ShakeStrength;
    private bool isShaking = false;

    private Vector3 initialPosition;

    Coroutine shakeTimer;


    private void Start()
    {
        GlobalSettings.Instance.SetPixelWorldUnitRatio();
    }

    private void Update()
    {
        if(isShaking)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * ShakeStrength;
        }
    }

    public void TriggerShake(float shakeStrength)
    {
        this.ShakeStrength = shakeStrength;
        if (shakeTimer != null)
        {
            StopCoroutine(shakeTimer);
        }
        shakeTimer = StartCoroutine(ShakeTimer());
    }

    private IEnumerator ShakeTimer()
    {
        isShaking = true;
        initialPosition = transform.localPosition;

        yield return new WaitForSeconds(shakeDuration);

        isShaking = false;
        transform.localPosition = initialPosition;
    }
}
