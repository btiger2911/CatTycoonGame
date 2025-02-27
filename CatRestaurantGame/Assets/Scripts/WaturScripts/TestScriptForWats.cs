using UnityEngine;
using UnityEngine.SceneManagement;
public class TestScriptForWats : MonoBehaviour
{
    Vector3 currentTarget;
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 2f;


    void Start()
    {
        currentTarget = player.transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, currentTarget) > .05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }
        else
        {
            transform.position = currentTarget;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
