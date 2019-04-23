using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitControler : MonoBehaviour
{
    public Transform objectPosition;
    public Transform Sun;
    public SphereCollider objectColider;

    public bool Colided=false;
    public float otherPlanetSize=0;

    private Ellipse path;
    private float period;

    private float EllipseX;
    private float EllipseY;

[Range(0f, 1f)]
    public float progress = 0f;
    public bool active = true;
    public float MaxEllipseX = 100f;
    public float MaxEllipseY = 100f;
    public float MaxPeriod = 20f;
    public float MinPeriod = 5f;
    public float MaxSize = 15f;
    public float MinSize = 1f;


    // Start is called before the first frame update
    void Start()
    {
       RandomizeItem();
        if (objectPosition == null)
            {
           active = false;
           return;
            }
        setObjectPosition();
        
        StartCoroutine(animateOrbit());
        //set orbiting object position
        //if (active) start animation
    }

    // Update is called once per frame
    void Update()
    {
        this.path = new Ellipse(EllipseX, EllipseY, Sun.position);
    }

    public void RandomizeItem()
    {
        EllipseX = Random.Range(Sun.localScale.x, MaxEllipseX);
        EllipseY = Random.Range(Sun.localScale.y, MaxEllipseY);

        this.path = new Ellipse(EllipseX, EllipseY, Sun.position);
        this.period = Random.Range(MinPeriod, MaxPeriod);
        //Transform model = GetComponentInChildren<Transform>();
        float newScale = Random.Range(MinSize, MaxSize);
        objectColider.radius = newScale;
        objectPosition.localScale = new Vector3(newScale, newScale, newScale);
    }

    void setObjectPosition()
    {
        Vector2 pos = path.Evaluate(progress);
        objectPosition.localPosition = new Vector3(pos.x, 0, pos.y);
    }

    IEnumerator animateOrbit()
    {
        if (period < 0.1f)
            period = 0.1f;
        float orbitSpeed = 1f / period;
        while (active)
        {
            progress += Time.deltaTime * orbitSpeed;
            progress = progress % 1f;

            setObjectPosition();
            yield return null;
        }
    }

    void OnTriggerEnter(SphereCollider other)
    {

        Colided = true;
        otherPlanetSize = other.radius;
        

    }



}
