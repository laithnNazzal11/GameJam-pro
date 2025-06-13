using UnityEngine;

public class SoundEffectsLayer : MonoBehaviour
{
  [SerializeField]  AudioSource audioSource;
  [SerializeField]  AudioSource SFXSource;

  public AudioClip backgroundMusic;
  public AudioClip deathSound;
  public AudioClip jumpSound;
  public AudioClip attackSound;
  public AudioClip damageSound;
  public AudioClip collectCoinSound;

  private void Start()
  {
    audioSource.PlayOneShot(backgroundMusic);
  }

  public void PlaySFX(AudioClip clip){
    SFXSource.PlayOneShot(clip);
  }
}
