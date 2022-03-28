using UnityEngine;

public class Consumable : MonoBehaviour
{
    [SerializeField]
    public int drinkIncrease, eatIncrease;
    [ContextMenu("Consume")]
    public void Consume()
    {
        Destroy(this);
    }
}
