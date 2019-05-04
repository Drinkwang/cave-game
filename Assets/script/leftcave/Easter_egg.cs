using UnityEngine;
using System.Collections;

public class Easter_egg : MonoBehaviour {

    private Game game;
	// Use this for initialization
	void Start () {
        game = Game._instant;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown() {
        game.Arrouce.SetActive(true);
        game.changetext("这是一张扑克10？...");
        game.one.SetActive(false);
        game.baiduyun.SetActive(true);
        Destroy(this.gameObject);
       
     
    }

}
