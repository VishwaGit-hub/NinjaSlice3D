using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer),typeof(BoxCollider))]
public class ClickAndSwipe : MonoBehaviour
{
    private GameManager gameManager;
    private Vector3 mousePos;
    private Camera cam;
    private TrailRenderer trail;
    private BoxCollider col;
    private bool swiping = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGmaeActive)
        {
            if(Input.GetMouseButtonDown(0))
                {
                swiping = true;
                UpdateComponents();

            }
          else if(Input.GetMouseButtonDown(0))
            {
                swiping=false;
                UpdateComponents();
            }
            if(swiping)
            {
                UpdateMousePos();
            }
           
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Target>())
        {
            collision.gameObject.GetComponent<Target>().DestroyTarget();
        }
    }

    void UpdateMousePos()
    {
        mousePos= cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
Input.mousePosition.y, 10.0f));
        transform.position = mousePos;
    }


    void UpdateComponents()
    {
        trail.enabled = swiping;
        col.enabled = swiping;
    }
    void Awake()
    {
        cam = Camera.main;
        trail=GetComponent<TrailRenderer>();
        col = trail.GetComponent<BoxCollider>();
        trail.enabled = false;
        col.enabled = false;
        gameManager=FindObjectOfType<GameManager>();
    }
}
