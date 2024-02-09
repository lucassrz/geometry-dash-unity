using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class LevelFinishBehavior : MonoBehaviour
{
    AudioSource audioData;
    
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<PlayerBehavior>() is PlayerBehavior)
        {
            audioData = GetComponent<AudioSource>();
            audioData.Play(0);
            StartCoroutine(WaitBeforeEnd());
        }
    }
    
    IEnumerator WaitBeforeEnd()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(3);
    }
}
