using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMaker : MonoBehaviour {

    public float offset = 0.707f;
    public Vector3 lastpost = Vector3.zero;
    public GameObject wallprefab;
    int counter=0;
    public Transform player;
	void Start () {
		
	}
	
    public void WallCreater()
    {
        InvokeRepeating("CreateWall", 1, Time.deltaTime);
    }

    private void CreateWall()
    {
        float distance = Vector3.Distance(player.position, lastpost);
        float screenHight = Camera.main.orthographicSize;

        if (distance > screenHight + 5) return;

        int change = Random.Range(0, 101);

        Vector3 newpos;


        if (change < 50)
        {
            newpos = new Vector3(lastpost.x - offset, lastpost.y, lastpost.z + offset);
        }

        else
        {
            newpos = new Vector3(lastpost.x + offset, lastpost.y, lastpost.z + offset);
        }

        GameObject wall = Instantiate(wallprefab, newpos, Quaternion.Euler(0, 45, 0), transform);

        lastpost = wall.transform.position;

        counter++;

        if (counter % Random.Range(4, 9) == 0)
        {
            wallprefab.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    

}
