using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathController : ChestController {

    public GameObject damageImage; //connected to object via the inspector
    private Image img;

    void Start()
    {
        img = damageImage.GetComponent<Image>();
        img.color = new Color(1f, 0f, 0f, 0.1f); //hide red initially!
    }

    void OnTriggerEnter(Collider other)
    {
        img.color = new Color(1f, 0f, 0f, 1.0f); //show red!!!!
    }
}
