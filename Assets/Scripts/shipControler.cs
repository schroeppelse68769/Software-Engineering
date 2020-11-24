using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipControler : MonoBehaviour
{
    public float maxSpeed = 12f;
    // instantane Bewegung oder mit Beschleunigung
    public bool analog = true;

    // Rand berührt
    private bool hitleft;
    private bool hitright;
    private bool hitup;
    private bool hitdown;

    private float xAchse = 0f;
    private float yAchse = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Tastatur abfrage
        if (!analog)
        {
            // Raw -> wenn über Nullpunkt hinaus -> 1
            xAchse = Input.GetAxisRaw("Horizontal");
            yAchse = Input.GetAxisRaw("Vertical");
        }
        else
        {
            // Wert auf Achsen
            xAchse = Input.GetAxis("Horizontal");
            yAchse = Input.GetAxis("Vertical");
        }

        // wenn innherhalb der Spielgrenzen
        if (!hitleft && !hitright)
        {
            // deltaTime -> Zeit zwischen letztem Frame und jetzt
            transform.Translate(Vector3.right * Time.deltaTime * maxSpeed * xAchse, Space.World);
        }
        else
        {
            // Bewegung nach rechts 
            if (hitleft && xAchse > 0f)
            {
                hitleft = false;
            }
            if (hitright && xAchse < 0f)
            {
                hitright = false;
            }
        }

        if (!hitup && !hitdown)
        {
            transform.Translate(Vector3.up * Time.deltaTime * maxSpeed * yAchse, Space.World);
        }
        else
        {
            if (hitup && yAchse < 0f)
            {
                hitup = false;
            }
            if (hitdown && yAchse > 0f)
            {
                hitdown = false;
            }
        }
    }

    // Abfrage ob Collider getroffen (wenn Trigger berührt)
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("right"))
        {
            hitright = true;
        }
        if (other.CompareTag("left"))
        {
            hitleft = true;
        }
        if (other.CompareTag("up"))
        {
            hitup = true;
        }
        if (other.CompareTag("down"))
        {
            hitdown = true;
        }
    }
}
