using UnityEngine;

public class Consumable : MonoBehaviour
{

    //how much eating this increase the thirst and hunger bar
    [SerializeField]
    public int drinkIncrease, eatIncrease;

    [ContextMenu("Consume")]
    public void Consume()
    {
        Destroy(gameObject);
    }
}
