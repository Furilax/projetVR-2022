using UnityEngine;

public class Consumable : MonoBehaviour
{
    [ContextMenu("Consume")]
    public void Consume()
    {
        Destroy(this);
    }
}
