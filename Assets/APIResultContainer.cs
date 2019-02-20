using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class APIResultContainer
{
	public bool success;
	public string terms;
	public string privacy;
	public int timestamp;
	public string source;
	public Quotes quotes;
}
