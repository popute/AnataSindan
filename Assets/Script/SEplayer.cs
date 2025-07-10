using UnityEngine;

public class SEplayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public AudioSource seSource;
    public AudioClip clickSound;

    public void PlayClickSound()
    {
        seSource.PlayOneShot(clickSound);
    }

}
