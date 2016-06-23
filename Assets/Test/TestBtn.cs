using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	Button btn = (Button)gameObject.GetComponent("Button");		
	}


	public void btnClick(GameObject go_)
	{
		Debug.Log("btn clicked:" + go_.name);
	}
}
