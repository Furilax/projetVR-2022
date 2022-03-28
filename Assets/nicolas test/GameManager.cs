using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    bool gameHasEnd = false;
    public void EndGame ()
    {
        if(gameHasEnd == false)
        {
            Debug.Log("Game Over");
            Restart();
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
