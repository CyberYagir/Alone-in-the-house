using DitzelGames.FastIK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public Transform[] points;

    public bool agred;
    public bool seePlayer;
    public NavMeshAgent agent;
    public GameObject player;
    public Transform currentTarget;
    public float timeWait;
    public float timeWaitUnAgr;
    public FastIKFabric HeadIK;
    public Transform IKHeadPoint;
    public Transform point;
    public AudioSource audio;
    public AudioClip arg, normal;
    public float bulletCooldown;
    public float deadDist;
    bool dead;
    public int toStanHits, hits;

    public GameObject[] listDes;
    private void Start()
    {
        toStanHits = Random.Range(2, 6);
        currentTarget = points[Random.Range(0, points.Length)];
        agent.SetDestination(currentTarget.position);
    }

    private void Update()
    {
	    audio.volume = 0.457f;
        agent.isStopped = false;
        if (bulletCooldown > 0)
        {
            timeWaitUnAgr += Time.deltaTime;
            bulletCooldown -= Time.deltaTime;
            HeadIK.Target = IKHeadPoint;
            GetComponentInChildren<Animator>().Play("CoolDown");
            agent.isStopped = true;
            audio.volume = 0;
            seePlayer = false;
            agent.SetDestination(currentTarget.position);
            return;
        }
        if (!dead)
        {
            if (agent.velocity.magnitude < 0.05f)
            {
                GetComponentInChildren<Animator>().Play("Idle");
            }
            else
            {
                GetComponentInChildren<Animator>().Play("Walk");
            }
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, player.transform.position - transform.position, out hit))
        {
            if (hit.transform == player.transform)
            {
                timeWaitUnAgr = 0;
                seePlayer = true;
                point.position = hit.point;
                HeadIK.Target = point;
                agent.speed = 12;
                agent.SetDestination(player.transform.position);
                if (audio.clip != arg)
                {
                    audio.clip = arg;
                    audio.Play();
                }
                agent.SetDestination(player.transform.position);
                if (Vector3.Distance(player.transform.position, transform.position) < deadDist)
                {
                    if (dead == false)
                    {
                        agent.isStopped = true;
                        player.SetActive(false);

                        HeadIK.Target = IKHeadPoint;
                        GetComponentInChildren<Animator>().Play("EatPlayer");
                        dead = true;
                        for (int i = 0; i < listDes.Length; i++)
                        {
                            listDes[i].SetActive(false);
                        }
                        StartCoroutine(waitDead());
                    }
                }
            }
            else
            {
                if (seePlayer)
                {
                    timeWaitUnAgr += Time.deltaTime;
                    if (timeWaitUnAgr > 15)
                    {
                        agent.SetDestination(currentTarget.position);
                        HeadIK.Target = IKHeadPoint;
                        seePlayer = false;
                        timeWaitUnAgr = 0;
                        agent.speed = 8;
                        audio.clip = normal;
                        audio.Play();
                    }
                    else
                    {
                        agent.SetDestination(player.transform.position);
                    }
                }
            }
        }
        if (agred == false)
        {
            if (seePlayer == false)
            {
                if (Vector3.Distance(transform.position, currentTarget.position) < 5f)
                {
                    if (timeWait < 4)
                    {
                        timeWait += Time.deltaTime;
                    }
                    if (timeWait >= 4)
                    {
                        timeWait = 0;
                        currentTarget = points[Random.Range(0, points.Length)];
                        agent.SetDestination(currentTarget.position);
                    }
                }
                else
                {
                    timeWait = 0;
                }
            }   
        }
    }

    IEnumerator waitDead()
    {
        yield return new WaitForSeconds(2.6f);
        Application.LoadLevel(0);
    }
}
