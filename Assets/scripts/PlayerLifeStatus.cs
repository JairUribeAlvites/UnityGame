using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeStatus : MonoBehaviour
{
    [SerializeField] private AudioSource DeathSound;

    private Animator animator_component;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        animator_component = GetComponent<Animator>();   
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
            DeathSound.Play();
        }
    }
    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        animator_component.SetTrigger("Death");
    }
     public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
