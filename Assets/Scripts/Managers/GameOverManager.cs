using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

    public PlayerHealth playerHealth;
    public float restartDelay = 5f;

    // Reference to the animator component.
    Animator anim;
    float restartTimer;

    void Awake() {
        ElementalSystem.Initialize();
        anim = GameObject.Find("PlayerUI").GetComponent<Animator>();
        playerHealth = FindObjectOfType(typeof(PlayerHealth)) as PlayerHealth;
    }

    void Update() {
        //trouve le joueur sur la scène 
 
        if (playerHealth.currentHealth <= 0) {
            anim.SetTrigger("GameOver");
            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
