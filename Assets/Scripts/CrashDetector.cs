using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
     [SerializeField] float delay=1f;
     [SerializeField] ParticleSystem crashEffect;
     [SerializeField] AudioClip crashSFX;
     bool hasCrashed = false;
   void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Ground" && !hasCrashed) {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControl();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene",delay);
        }
    }
     void ReloadScene(){
            hasCrashed = false;
            SceneManager.LoadScene(0);
        }
}
