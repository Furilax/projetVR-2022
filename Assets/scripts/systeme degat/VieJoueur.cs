using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VieJoueur : MonoBehaviour
{
    //pour voir les variables dans l'inspector
    [SerializeField]
    public int max_heal;
    public int cur_heal;
    public bool isAlive;


    private void Start()
    {
        cur_heal = max_heal;
        isAlive = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            takeDamage(10);
        }
    }

    public void takeDamage(int amount)
    {
        if (isAlive)
        {
            cur_heal -= amount;
            Debug.Log("prend un degat");
            isDead();
        }
    }

    private void isDead()
    {
        if (cur_heal <= 0)
        {
            isAlive = false;
            Debug.Log("le joueur est morte, y falais etre plus fort");
            gameObject.SetActive(false);
            FindObjectOfType<GameManager>().EndGame();

        }
    }
}
