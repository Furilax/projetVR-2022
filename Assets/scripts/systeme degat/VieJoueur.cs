using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VieJoueur : MonoBehaviour
{
    //pour voir les variables dans l'inspector
    [SerializeField]
    public int max_heal;
    public int cur_heal;
    public bool isAlive;

    private float thirst, hunger;

    [SerializeField]
    private Image thirstBar, hungerBar;

    [SerializeField]
    private float maxThirst = 100, maxHunger = 100;


    [SerializeField]
    private float thirstDecreaseSpeed = 1, hungerDecreaseSpeed = 1;

    private void Start()
    {
        cur_heal = max_heal;
        isAlive = true;
        hunger = maxHunger;
        thirst = maxThirst;
    }

    void Update()
    {
        thirst -= Time.deltaTime * thirstDecreaseSpeed;
        hunger -= Time.deltaTime * hungerDecreaseSpeed;
        hungerBar.rectTransform.localScale = new Vector3(hunger / maxHunger, 1, 1);
        thirstBar.rectTransform.localScale = new Vector3(thirst / maxThirst, 1, 1);

        hunger = Mathf.Clamp(hunger, 0, maxHunger);
        thirst = Mathf.Clamp(thirst, 0, maxThirst);

        if (hunger <= 0 || thirst <= 0)
        {
            cur_heal = 0;
            isDead();
        }

        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    takeDamage(10);
        //}
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

    public void eat(int food, int drink)
    {
        hunger += food;
        thirst += drink;
    }
}
