using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] GameObject player;
    Collider2D headCollider;

    void Start()
    {
        headCollider = player.GetComponent<CircleCollider2D>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == headCollider)
        {
            SceneManager.LoadScene(0);
        }   
    }
}
