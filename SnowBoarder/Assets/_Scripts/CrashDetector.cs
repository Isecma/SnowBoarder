using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float reloadSceneDelay = 0.5f;
    [SerializeField] ParticleSystem boardEffect;
    [SerializeField] ParticleSystem crashEffect;

    Collider2D headCollider;
    Collider2D boardCollider;

    void Start()
    {
        headCollider = player.GetComponent<CircleCollider2D>();
        boardCollider = player.GetComponent<CapsuleCollider2D>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == headCollider)
        {
            crashEffect.Play();
            var surfaceEffector = this.GetComponent<SurfaceEffector2D>();
            surfaceEffector.speed = 0;
            Invoke("ReloadScene", reloadSceneDelay);
        }
        else if (collision.collider == boardCollider)
        {
            boardEffect.Play();
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
