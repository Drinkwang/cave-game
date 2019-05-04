using UnityEngine;
using System.Collections;

public class knock : MonoBehaviour {
    public GameObject hammer;
	// Use this for initialization
	void Start ()
    {
        print(Vector3.Distance(hammer.transform.position, this.transform.position));


    }
	
	// Update is called once per frame
	void Update () {if (Vector3.Distance(hammer.transform.position, this.transform.position) < 30)
        {
            transform.parent.GetComponent<AudioSource>().PlayScheduled(1);
                transform.parent.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(transform.parent.GetComponent<RectTransform>().anchoredPosition3D.x, -29.7f, 0);
            Game._instant.score++;
            this.enabled=false;
        }
     
	}
   

}
