using UnityEngine;

public class ObjectScaler : Interactable
{
    [SerializeField] private float scalingSpeed = 10f;
    [SerializeField] private float scalingPercentage = 50f;
    private float startingScaleX;
    private float minScaleX;
    private float maxScaleX;

    public float ScalePercentage { get => scalingPercentage; set => CountScaleLimits(value); }

    private void Awake()
    {
        startingScaleX = transform.localScale.x;
        CountScaleLimits(scalingPercentage);
    }

    public override void Interact1()
    {
        float scaleAmount = scalingSpeed * Time.deltaTime;
        if (transform.localScale.x + scaleAmount < minScaleX || transform.localScale.x + scaleAmount > maxScaleX)
            return;

        transform.localScale = new Vector3(
            transform.localScale.x + scaleAmount,
            transform.localScale.y + scaleAmount,
            transform.localScale.z + scaleAmount);
    }

    public override void Interact2()
    {
        float scaleAmount = scalingSpeed * Time.deltaTime;
        if (transform.localScale.x - scaleAmount < minScaleX || transform.localScale.x - scaleAmount > maxScaleX)
            return;

        transform.localScale = new Vector3(
            transform.localScale.x - scaleAmount,
            transform.localScale.y - scaleAmount,
            transform.localScale.z - scaleAmount);
    }

    private void CountScaleLimits(float newScalePercentage)
    {
        scalingPercentage = newScalePercentage;
        float scalePercentage = startingScaleX * scalingPercentage / 100;
        minScaleX = startingScaleX - scalePercentage;
        maxScaleX = startingScaleX + scalePercentage;
    }
}
