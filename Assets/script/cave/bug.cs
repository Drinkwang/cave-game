using UnityEngine;
using System.Collections;

public class bug : MonoBehaviour {
    public GameObject xbug;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnDestroy() { Destroy(xbug); }
}
