using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    private RectTransform healthbar;
    public int health;
     public int curHealth;

	// Use this for initialization
	void Start () {
        healthbar = GameObject.FindGameObjectWithTag("Healthbar").GetComponent<RectTransform>();
        curHealth = health;
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void TakeDamage(int damage)
    {


        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        healthbar.localScale = new Vector3((float)curHealth/(float)health, healthbar.localScale.y, healthbar.localScale.z);
    }

}
