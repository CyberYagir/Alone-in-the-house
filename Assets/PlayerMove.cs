using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float normalspeed;
    public float JumpForce;
    public float StopForce;
    public float sens;
    public Rigidbody Rigidbody;
    public bool isJumped;
    public GameObject Camera;
    public Quaternion LastRot;
    float rotationY = 0f;
    public bool jumpCooldown;
    public float slope = 0;
    public float stamina, maxStamina;
    public bool run;
    public float magn;
    public AudioSource steps;
    private void Start()
    {
        normalspeed = speed;
    }
    void FixedUpdate()
    {
        magn = new Vector3(Rigidbody.velocity.x, 0 , Rigidbody.velocity.z).magnitude;
        steps.pitch = 1 + (magn / 30);
        if (magn > 1)
        {
            if (!steps.isPlaying)
            {
                steps.PlayOneShot(steps.clip);
            }
        }
        RaycastHit hit;
        if (Physics.Raycast(transform.position - new Vector3(0, GetComponent<CapsuleCollider>().height / 2, 0), transform.forward, out hit, 4f))
        {
            if (hit.collider.isTrigger == false)
            {
                if (Vector3.Angle(Vector3.up, hit.normal) <= 75f)
                {
                    slope = (Vector3.Angle(Vector3.up, hit.normal));
                }
                else
                {
                    slope = 0;
                }
            }
            else
            {
                slope = 0;
            }
        }
        else
        {
            slope = 0;
        }
        bool freezed = false;
        Debug.DrawRay(transform.position - new Vector3(0, GetComponent<CapsuleCollider>().height / 2, 0), Vector3.down);
        if (!Physics.Raycast(transform.position - new Vector3(0, GetComponent<CapsuleCollider>().height / 2, 0), Vector3.down, out hit, 2.8f))
        {
            if (magn <= 0.05f)
            {
                freezed = true;
            }
            Rigidbody.AddForce(Vector3.down * 5000 * Time.deltaTime);
            isJumped = true;
        }
        else
        {
            isJumped = false;
        }
        speed = normalspeed *(freezed ? 5 : 1);
        run = Input.GetKey(KeyCode.LeftShift);
        if (run)
        {
            if (stamina > 0)
            {
                speed = normalspeed * 2.5f;
                stamina -= Time.deltaTime*2f;
            }
        }
        else
        {
            if (stamina < maxStamina)
            {
                stamina += Time.deltaTime;
            }
        }



        Rigidbody.AddRelativeForce(Vector3.forward * Input.GetAxisRaw("Vertical") * (speed + (slope*2)));
        Rigidbody.AddRelativeForce(Vector3.right * Input.GetAxisRaw("Horizontal") * (speed + (slope*2)));


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJumped)
            {
                Rigidbody.AddForce(Vector3.up * 800 * Time.deltaTime, ForceMode.Impulse);
            }
        }
    }
    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        float yrot = Input.GetAxisRaw("Mouse X");
        Vector3 rot = new Vector3(0, yrot, 0f) * sens;
        transform.rotation = (transform.rotation * Quaternion.Euler(rot));

        rotationY += Input.GetAxis("Mouse Y") * sens;
        rotationY = Mathf.Clamp(rotationY, -80, 80);

        Camera.transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
    }


    public float upDist()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Vector3.up, out hit))
        {
            if (hit.collider != null)
            {
                return Vector3.Distance(hit.point, Camera.transform.position);
            }
            else
            {
                return -2;
            }
        }
        return -1;
    }

    IEnumerator jumpWait()
    {
        jumpCooldown = true;
        yield return new WaitForSeconds(1);
        jumpCooldown = false;
    }
}