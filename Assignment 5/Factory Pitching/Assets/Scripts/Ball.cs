/*******************************
 * Author: Connor Wolf
 * File: Ball.cs
 * Date: 2/18/20
 * Description: Ball abstract class 
 ******************************/
using UnityEngine;

public abstract class Ball : MonoBehaviour
{
    protected float speed;
    protected bool curve;
    protected bool sink;
    protected KeyCode targetKey;
    private float hitSkew;
    private bool canHit;

    private void Start()
    {
        canHit = false;
    }

    public void Pitch()
    {
        if (!curve) transform.Translate(Vector3.back * Time.deltaTime * speed);
        if (curve) transform.Translate(new Vector3(0.2f*Mathf.Sin(Time.time*4), 0, -1) * Time.deltaTime * speed);
    }

    private void Update()
    {
        if (speed > 0) Pitch();

        if (Input.GetKeyDown(targetKey) && speed > 0 && canHit)
        {
            speed = -10;
            hitSkew = Random.Range(-2f, 2f);
            canHit = false;
        }

        if (speed < 0)
        {
            transform.Translate(new Vector3(hitSkew, -1, -1) * speed * Time.deltaTime);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            canHit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            if (canHit == true)
            {
                canHit = false;
                BattingPractice.instance.CallStrike();
                Debug.Log("Strike");
            } else
            {
                BattingPractice.instance.CallHit();
                Debug.Log("Hit");
            }
        }
    }
}
