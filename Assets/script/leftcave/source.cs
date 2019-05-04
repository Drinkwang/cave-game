using UnityEngine;
using System.Collections;

public class source : MonoBehaviour {

    private Game game;
	// Use this for initialization
	void Start () {
        game = Game._instant;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown() {
        if (game.ITEM[5].activeSelf == true && game.ITEM[0].activeSelf == true)
        {
            game.Arrouce.SetActive(true);
            game.changetext("我将水桶和绳子结合在一起，最终取得了水");
            game.ITEM[4].SetActive(true);
            game.ITEM[5].SetActive(false);
            game.one.SetActive(false);
            GetComponent<AudioSource>().Play();
        }

        else if (game.ITEM[5].activeSelf == false)
        {
            game.Arrouce.SetActive(true);
            game.changetext("这个有口水井，散发着一股奇迹般的力量，然而并没有任何卵用，我并没有任何东西可以取得.....");
            game.one.SetActive(false);
        }
        else if (game.ITEM[5].activeSelf == true && game.ITEM[0].activeSelf == false)
        {
            game.Arrouce.SetActive(true);
            game.changetext("这个有口水井，散发着一股奇迹般的力量，我也有水壶，然而并没有任何卵用，手的长度根本无法取出水.....");
            game.one.SetActive(false);
        }


    }

}
