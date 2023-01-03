using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class test1 : MonoBehaviour
{
    public Player player;
    public NavMeshAgent enemy;
    /*public Text pointxt;
    public int poin;*/
    float radi;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.transform.position);
       /* dir = (Vector3)transform.position - (Vector3)Player.instance.transform.position;
        radi = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 90 - radi, 0);*/
    }
    public void updateCube(int poin)
    {
        /*this.poin = poin;
        pointxt.text = " " + poin;*/
    }
}
