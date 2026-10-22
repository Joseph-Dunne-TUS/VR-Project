using UnityEngine;

public class ClockMotion : MonoBehaviour
{
    public Transform hourHand;
    public Transform minuteHand;
    public Transform secondHand;

    private Vector3 hourInitialRotation;
    private Vector3 minuteInitialRotation;
    private Vector3 secondInitialRotation;

    void Start()
    {
        // Store the starting rotation of each hand set in the editor
        if (hourHand != null) hourInitialRotation = hourHand.localEulerAngles;
        if (minuteHand != null) minuteInitialRotation = minuteHand.localEulerAngles;
        if (secondHand != null) secondInitialRotation = secondHand.localEulerAngles;
    }

    void Update()
    {
        // Get current time
        System.DateTime currentTime = System.DateTime.Now;

        // Calculate rotations
        float hourRotation = (currentTime.Hour % 12) * 30f + currentTime.Minute * 0.5f;
        float minuteRotation = currentTime.Minute * 6f + currentTime.Second * 0.1f;
        float secondRotation = currentTime.Second * 6f;

        // Apply rotations while preserving initial offsets
        if (hourHand != null)
            hourHand.localRotation = Quaternion.Euler(hourInitialRotation.x + hourRotation, hourInitialRotation.y, hourInitialRotation.z);

        if (minuteHand != null)
            minuteHand.localRotation = Quaternion.Euler(minuteInitialRotation.x + minuteRotation, minuteInitialRotation.y, minuteInitialRotation.z);

        if (secondHand != null)
            secondHand.localRotation = Quaternion.Euler(secondInitialRotation.x + secondRotation, secondInitialRotation.y, secondInitialRotation.z);
    }
}