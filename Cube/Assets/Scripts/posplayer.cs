using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posplayer : MonoBehaviour
{
    public GameObject textPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textPlayer.transform.position = new Vector3(transform.position.x, Player.instance.transform.localScale.y+0.2f, transform.position.z);
    }
}
