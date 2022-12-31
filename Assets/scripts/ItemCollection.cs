using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollection : MonoBehaviour
{
    private int item_type1_amount=0;
    [SerializeField] private Text ItemType1_UI_Counter;
    [SerializeField] private AudioSource CollectSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("item_type1")){
            Destroy(collision.gameObject);
            item_type1_amount++;
            ItemType1_UI_Counter.text = "ItemType1 amount:" + item_type1_amount;
            CollectSound.Play();


        }
    }
}
