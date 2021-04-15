using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyController2 : MonoBehaviour
{

    //public Camera cam;

    public NavMeshAgent enemy;

    public GameObject player;

    public GameObject GameOver;

    public ThirdPersonCharacter character;

    //public static int score = 0;

    public float cooldown = -1f;

    void Start()
    {
        Time.timeScale = 1f;
        enemy.updateRotation = false;
        //score = 0;
    }
    
    void Update()
    {
        //Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;
        if (cooldown > -1)
            cooldown -= Time.deltaTime;

        enemy.SetDestination(player.transform.position);
           

        if (enemy.remainingDistance > enemy.stoppingDistance)
        {
            character.Move(enemy.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (cooldown < 0) {
                PlayerController2.lives--;
                cooldown = 3f + Time.deltaTime;
            }

            //other.gameObject.SetActive(false);
            if(PlayerController2.lives <= 0)
                EndGame();
        }
    }

    void EndGame()
    {
        GameOver.SetActive(true);
        Time.timeScale = 0f;
    }
}
