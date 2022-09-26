using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float reloadSceneDelay = 0.5f;
    [SerializeField] ParticleSystem boardEffect;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    [HideInInspector] public bool hasCrashed;

    Collider2D headCollider;
    Collider2D boardCollider;

    void Start()
    {
        headCollider = player.GetComponent<CircleCollider2D>();
        boardCollider = player.GetComponent<CapsuleCollider2D>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == headCollider && !hasCrashed)
        {
            hasCrashed = true;
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            GetComponent<SurfaceEffector2D>().speed = 0;
            Invoke("ReloadScene", reloadSceneDelay);
        }
        else if (collision.collider == boardCollider && GetComponent<SurfaceEffector2D>().speed != 0)
        {
            boardEffect.Play();
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        boardEffect.Stop();
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
