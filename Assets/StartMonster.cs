using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMonster : MonoBehaviour
{
    public GameObject monster;
    public Transform[] points;
    public Transform player;
    public float time;
    public float maxTime;



    private void Update()
    {
        time += Time.deltaTime;
        if (time > maxTime) {
            float max = -99999;
            int id = -1;
            for (int i = 0; i < points.Length; i++)
            {
                var dist = Vector3.Distance(player.position, points[i].position);
                if (dist > max)
                {
                    max = dist;
                    id = i;
                }
            }
            monster.transform.position = points[id].transform.position;
            monster.SetActive(true);
            Destroy(gameObject);
        }
    }






}
