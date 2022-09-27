using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrusters : MonoBehaviour
{
    private ParticleSystem ps;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        var main = ps.main;
        main.startSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        var main = ps.main;
        main.startSpeed = Input.GetAxis("Vertical") * speed + speed;
    }
}
