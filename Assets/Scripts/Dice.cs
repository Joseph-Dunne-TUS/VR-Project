using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Dice : MonoBehaviour
{
    [Header("Dice Settings")]
    [SerializeField] public Transform diceModel;
    [SerializeField] public float rollCooldown = 0.5f;
    [SerializeField] public float resetHeight = -0.5f;

    [Header("Dice Result")]
    [SerializeField] public int diceResult;
    [SerializeField] public TMP_Text resultText;

    [Header("Audio")]
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioClip rollSound;
    [SerializeField] public AudioClip sixSound;

    [Header("Dice Events")]
    public UnityEvent onDiceRolled;
    public UnityEvent onRolledSix;

    public Rigidbody rb;
    public Vector3 startPosition;
    public Quaternion startRotation;
    public Quaternion modelStartRotation;
    public float nextRollTime;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();

        startPosition = transform.position;
        startRotation = transform.rotation;

        if (diceModel != null)
        {
            modelStartRotation = diceModel.localRotation;
        }

        if (resultText != null)
        {
            resultText.text = "Roll the dice!";
        }
    }

    public void Update()
    {
        if (transform.position.y < resetHeight)
        {
            ResetDice();
        }
    }

    public void RollDice()
    {
        // Prevent rapid repeated rolls.
        if (Time.time < nextRollTime)
        {
            return;
        }

        nextRollTime = Time.time + rollCooldown;

        // Generate a number between 1 and 6.
        diceResult = Random.Range(1, 7);

        Debug.Log("Dice rolled: " + diceResult);

        UpdateDiceRotation();
        UpdateResultUI();

        PlaySound(rollSound);

        onDiceRolled?.Invoke();

        if (diceResult == 6)
        {
            PlaySound(sixSound);
            onRolledSix?.Invoke();

            Debug.Log("You rolled a six!");
        }
    }

    public void UpdateDiceRotation()
    {
        if (diceModel == null)
        {
            return;
        }

        Vector3 faceDirection = Vector3.up;

        switch (diceResult)
        {
            case 1:
                faceDirection = Vector3.up;
                break;

            case 2:
                faceDirection = Vector3.forward;
                break;

            case 3:
                faceDirection = Vector3.right;
                break;

            case 4:
                faceDirection = Vector3.left;
                break;

            case 5:
                faceDirection = Vector3.back;
                break;

            case 6:
                faceDirection = Vector3.down;
                break;
        }

        diceModel.rotation =
            Quaternion.FromToRotation(
                diceModel.TransformDirection(faceDirection),
                Vector3.up
            ) * diceModel.rotation;
    }

    public void UpdateResultUI()
    {
        if (resultText == null)
        {
            return;
        }

        if (diceResult == 6)
        {
            resultText.text = "You rolled a SIX!";
        }
        else
        {
            resultText.text = "You rolled: " + diceResult;
        }
    }

    public void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public void ResetDice()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.position = startPosition;
        transform.rotation = startRotation;

        if (diceModel != null)
        {
            diceModel.localRotation = modelStartRotation;
        }
    }

    public int GetDiceResult()
    {
        return diceResult;
    }
}