using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    private AudioSource audioSource;  // AudioSource component
    public float triggerRange = 40f;   // Set the range you consider as "close enough"

    private void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource component not found on the GameObject. Disabling script.");
            this.enabled = false;  // Disable the script if no AudioSource is found
        }
    }

    private void Update()
    {
        // Assuming the player has a tag "Player"
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null && audioSource != null)
        {
            // Check distance between this GameObject and the player
            if (Vector3.Distance(transform.position, player.transform.position) <= triggerRange)
            {
                // Play the audio if the player is close and audio is not already playing
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
            else
            {
                // Optional: Stop the audio if the player moves out of range
                if (audioSource.isPlaying)
                {
                    audioSource.Stop();
                }
            }
        }
    }
}
