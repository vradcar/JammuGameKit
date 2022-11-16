using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemCollection : MonoBehaviour
{
    private int coins = 0;

    public Animator animatorflag;
    public Animator animatorDeath;

    [SerializeField] public Text coinsText;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectibles"))
        {
            Destroy(collision.gameObject);
            coins++;
            coinsText.text = "Coins : " + coins;
        }

        if (collision.gameObject.CompareTag("EndFlag"))
        {
            animatorflag.SetBool("Win", true);
        }

        if (collision.gameObject.CompareTag("Traps"))
        {
            animatorDeath.SetBool("Death", true);
            RestartLevel();
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
