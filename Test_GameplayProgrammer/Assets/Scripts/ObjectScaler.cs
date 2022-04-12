using UnityEngine;

public class ObjectScaler : Interactable
{
    [SerializeField] private float scalingSpeed = 10f;
    [SerializeField] private float scalingPercentage = 50f;
    private float startingScaleX;
    private float minScaleX;
    private float maxScaleX;

    private void Awake()
    {
        float scalePercentage = transform.localScale.x * scalingPercentage / 100;
        startingScaleX = transform.localScale.x;
        minScaleX = startingScaleX - scalePercentage;
        maxScaleX = startingScaleX + scalePercentage;
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
}
