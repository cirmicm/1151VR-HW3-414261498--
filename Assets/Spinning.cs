using UnityEngine;
using UnityEngine.InputSystem;

public class Spinning : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;

    private float rotSpeed;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0f;
    }

    private void Start()
    {
        Application.targetFrameRate = 100;
    }

    private void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            rotSpeed = 30f;
            audioSource.PlayOneShot(clickSound);
        }

        transform.Rotate(0f, 0f, rotSpeed);

        rotSpeed *= 0.96f;
    }
}
