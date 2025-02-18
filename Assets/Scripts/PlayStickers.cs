using UnityEngine;

public class PlayStickers : MonoBehaviour
{
    
    public AudioSource audioSource;
    public Animator anim;

    public void PlayAnimationWithAudio()
    {
               
        anim.SetTrigger("Trigger");
        audioSource.Play();
        StartCoroutine(StopAnimationWhenAudioEnds());
    }

    System.Collections.IEnumerator StopAnimationWhenAudioEnds()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        anim.SetTrigger("Trigger");
    }
}
