using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{

    public GameObject light, pistol;
    public bool pistolCan, keyCan;
    bool played = false;
    public float timeforplay = 0;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (pistol.GetComponent<Pistol>().cooldown <= 0)
            {
                light.SetActive(true);
                pistol.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (pistolCan)
            {
                light.SetActive(false);
                pistol.SetActive(true);
            }
        }
        if (pistol.GetComponent<Pistol>().hitMonster != 0 && !keyCan)
        {
            if (!played)
            {
                timeforplay += Time.deltaTime;
                if (timeforplay > 70)
                {
                    var p = FindObjectsOfType<Phrase>().ToList().Find(x => x.phraseID == 7);
                    p.audioSource.PlayOneShot(p.audioSource.clip);
                    played = true;
                }
            }
        }
    }
}
