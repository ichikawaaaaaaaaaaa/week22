using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int hp = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hp--;

            if (hp <= 0)
            {

                // GameManager�ɒʒm
                FindObjectOfType<GameManager>().EnemyDefeated();

                Destroy(gameObject);
            }
        }
    }
}