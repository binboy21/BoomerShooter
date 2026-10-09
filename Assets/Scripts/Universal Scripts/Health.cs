using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int health;
    [SerializeField] private bool isPlayer;

    [SerializeField] private TMP_Text healthText;
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            if (isPlayer) PlayerDeath();
            else Destroy(this.gameObject);
        }

        if (isPlayer) healthText.text = health.ToString() + "/" + maxHealth.ToString();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void GainHealth(int healing)
    {
        health += healing;
        if (health > maxHealth) health = maxHealth;
    }

    private void PlayerDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
