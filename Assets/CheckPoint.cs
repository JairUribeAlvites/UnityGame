using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{
    private AudioSource FinishSound;
    // Start is called before the first frame update
    void Start()
    {
        FinishSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerSprite")
        {
            FinishSound.Play();
            //CompleteLevel();
            Invoke("CompleteLevel", 2f);
                
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
