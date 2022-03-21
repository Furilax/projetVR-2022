using UnityEngine;

public class VieEnnemie : MonoBehaviour
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

    public void takeDamage(int amount) 
    {
        if (isAlive)
        {
            cur_heal -= amount;
            isDead();
        }
    }

    private void isDead()
    {
        if(cur_heal <= 0)
        {
            isAlive = false;
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAH je suis mort dommage");
            gameObject.SetActive(false);
        }
    }
}
