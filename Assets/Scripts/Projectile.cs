using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;

    public GameObject explosionEffect;  // Particle effect prefab
    public GameObject EarthexplosionEffect; 
    public AudioClip generalCollisionSound; // Sound for shield/player collisions
    public AudioClip earthCollisionSound;   // Sound for Earth collision

    private AudioSource audioSource;

    void Start()
    {
        // Attach or get AudioSource component
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        // Move the projectile forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroid"))
        {
            Destroy(other.gameObject); // Destroy asteroid
            Destroy(gameObject); // Destroy projectile
            return;
        }

        // Handle collision with Earth
        if (other.CompareTag("Earth"))
        {
            HandleCollisionEffect(earthCollisionSound); // Use Earth-specific sound
            Destroy(gameObject);
            return;
        }

        // Handle collision with shield or player
        if (other.CompareTag("Shield") || other.CompareTag("Player"))
        {
            HandleCollisionEffect(generalCollisionSound); // Use general collision sound
            Destroy(gameObject);
        }
    }
    private void HandleCollisionEffect(AudioClip sound)
    {
        // Play particle effect
        if (EarthexplosionEffect != null)
        {
            Debug.Log("Its a Big one Hold on!");    
            GameObject BigExplosion = Instantiate(EarthexplosionEffect, transform.position, Quaternion.identity); 
            
        }
        
        if (explosionEffect != null)
        {
            GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);

            // Destroy the particle effect after it has finished playing
            Destroy(explosion, explosion.GetComponent<ParticleSystem>().main.duration);
        }
        // Play sound effect
        if (sound != null)
        {
            PlaySoundAtLocation(sound, transform.position);
        }
    }
    
    private void PlaySoundAtLocation(AudioClip clip, Vector3 position)
    {
        // Create a temporary GameObject to play the sound
        GameObject soundObject = new GameObject("TemporaryAudio");
        soundObject.transform.position = position;
    
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();
    
        // Destroy the temporary GameObject after the sound finishes
        Destroy(soundObject, clip.length);
    }
}
