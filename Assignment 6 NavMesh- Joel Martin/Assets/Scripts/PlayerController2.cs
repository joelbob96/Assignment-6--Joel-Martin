using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController2 : MonoBehaviour
{

    public Camera cam;

    public Text text;

    public Text Lives;

    public NavMeshAgent agent;

    public ThirdPersonCharacter character;

    public static int score = 0;

    public static int lives = 3;

    public GameObject WinScreen;

    void Start()
    {
        agent.updateRotation = false;
        score = 0;
        lives = 3;
        DisplayScore();

    }
    
    void Update()
    {
        Lives.text = "Lives: " + lives.ToString();

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Item")
        {
            other.gameObject.SetActive(false);
            score += 10;
            DisplayScore();
            if (score >= 50)
                //LevelGenerator2.goal = 50;
                YouWin();
        }
    }

    void DisplayScore()
    {
        text.text = "Current Score:" + score.ToString();
    }
    void YouWin()
    {
           WinScreen.SetActive(true);
           Time.timeScale = 0f;

    }
}
