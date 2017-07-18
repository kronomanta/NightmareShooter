using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int StartingHealth = 100;
    public int CurrentHealth { get; private set; }
    public Slider HealthSlider;
    public Image DamageImage;
    public AudioClip DeathClip;
    public float FlashSpeed = 5f;
    public Color FlashColour = new Color(1f, 0f, 0f, 0.1f);


    Animator _anim;
    AudioSource _playerAudio;
    PlayerMovement _playerMovement;
    PlayerShooting _playerShooting;
    bool _isDead;
    bool _isDamaged;


    void Awake()
    {
        _anim = GetComponent<Animator>();
        _playerAudio = GetComponent<AudioSource>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerShooting = GetComponentInChildren<PlayerShooting>();
        CurrentHealth = StartingHealth;
    }


    void Update()
    {
        if (_isDamaged)
        {
            DamageImage.color = FlashColour;
        }
        else
        {
            DamageImage.color = Color.Lerp(DamageImage.color, Color.clear, FlashSpeed * Time.deltaTime);
        }
        _isDamaged = false;
    }


    public void TakeDamage(int amount)
    {
        _isDamaged = true;

        CurrentHealth -= amount;

        HealthSlider.value = CurrentHealth;

        _playerAudio.Play();

        if (CurrentHealth <= 0 && !_isDead)
            Death();
    }


    void Death()
    {
        _isDead = true;

        _playerShooting.DisableEffects();

        _anim.SetTrigger("Die");

        _playerAudio.clip = DeathClip;
        _playerAudio.Play();

        _playerMovement.enabled = false;
        _playerShooting.enabled = false;
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
