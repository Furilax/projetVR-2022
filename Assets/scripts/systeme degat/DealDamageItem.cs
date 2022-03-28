using UnityEngine;

public class DealDamageItem : MonoBehaviour
{
    //pour voir les variables dans l'inspector
    [SerializeField]
    public BoxCollider damageCollider;
    public int nbDegat;
    private bool isTouch = false;

    //private void OnTriggerEnter(Collider collision)
    //{
    //    if (collision.CompareTag("Enemie"));
    //    {
    //        doDamage();
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemie") && isTouch == false)
        {
            isTouch = true;
            collision.gameObject.GetComponent<VieEnnemie>().takeDamage(nbDegat);
            //Debug.Log("touche ");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemie") && isTouch == true)
        {
            isTouch = false;
            //Debug.Log("touche plus");
        }
    }
}
