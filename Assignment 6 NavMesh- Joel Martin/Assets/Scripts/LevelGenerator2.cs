using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class LevelGenerator2 : MonoBehaviour {

    public NavMeshSurface surface;

	public int width = 10;
	public int height = 10;

	public GameObject wall;
	public GameObject Item;

    public static int goal = 50;

	private bool playerSpawned = false;

    public Text text;


	void Start () {
        goal = 0;

		GenerateLevel();

        surface.BuildNavMesh();
	}
	
	void GenerateLevel()
	{
        goal = 0;
		for (int x = 0; x <= width; x+=2)
		{
			for (int y = 0; y <= height; y+=2)
			{
				if (Random.value > .7f)
				{
					Vector3 pos = new Vector3(x - width / 2f, 1.7f, y - height / 2f);
					Instantiate(wall, pos, Quaternion.identity, transform);
				} else if(Random.value > 0.95f)
                { 
					Vector3 pos = new Vector3(x - width / 2f, 1.7f, y - height / 2f);
					Instantiate(Item, pos, Quaternion.identity);
                    goal += 10;
				}
			}
		}
        text.text = "Goal: " + goal.ToString();
	}

}
