using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public float cooldown;
    public GameObject light;
    public int bullets;
    float lighttime;
    public TMP_Text bulletsT;
    public int hitMonster;
    public GameObject m3, m4;
    public GameObject actions;
    public GameObject key;
    private void Update()
    {
        bulletsT.text = bullets.ToString("00");
        lighttime -= Time.deltaTime;
        cooldown -= Time.deltaTime;
        light.SetActive(lighttime > 0);
        if (Input.GetKey(KeyCode.Mouse0))
        {
		if (actions.active) return;
            if (bullets > 0)
            {
                if (cooldown <= 0)
                {
                    GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
                    lighttime = 0.1f;
                    cooldown = 0.2f;
                    GetComponent<Animator>().Play("Shoot");
                    RaycastHit hit;
                    if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
                    {
                        print(hit.transform.name);
                        if (hit.transform.tag == "Monster")
                        {
                            var monst = FindObjectOfType<Monster>();
                            monst.hits++;
                            if (monst.hits >= monst.toStanHits)
                            {
                                FindObjectOfType<Monster>().bulletCooldown = 7f;
				monst.hits = 0;
				monst.toStanHits = Random.Range(2, 4);
                            }
                            if (hitMonster == 3)
                            {
                                m3.SetActive(false);
                                m4.SetActive(true);
                                var p = FindObjectsOfType<Phrase>().ToList().Find(x => x.phraseID == 5);
                                p.audioSource.PlayOneShot(p.audioSource.clip);
                                key.SetActive(true);
                            }
                            hitMonster++;
                        }
                        if (hit.transform.tag == "Zamok")
                        {
                            if (!FindObjectOfType<WeaponSwitch>().keyCan)
                            {
                                
                            }
                            hit.transform.GetComponent<Rigidbody>().isKinematic = false;
                        }
                    }

                    bullets -= 1;
                }
            }
        }
    }
}
