using Assets.Scripts.SceneScripts.Level4;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public GameObject level;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        // The only thing that is possible to collide is the user
        var lvl = level.GetComponent<LevelState>();
        lvl.WinLevel();
        lvl.StartCoroutine(lvl.StartRandomLevel());
    }

}
