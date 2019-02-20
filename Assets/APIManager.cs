using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class APIManager : MonoBehaviour
{
	public Text ResultText;
	
	public API api;

	WWW shootapi;

	string URL;

	public GameObject apiCatcher;

	public void StartAPI()
	{
		string finalhttp;
		
		finalhttp = api.http;
		if (api.attributes != null) {
			finalhttp = api.http + "?";
			foreach (APIAttribute attribute in api.attributes)
			{
				if (attribute != api.attributes[api.attributes.Length - 1])
				{
					finalhttp = finalhttp + attribute.name + "=" + attribute.value + "&";
				}
				else {
					finalhttp = finalhttp + attribute.name + "=" + attribute.value;
				}
			}
		}

		ResultText.text = "URL :\n"+ finalhttp;
		URL = finalhttp;

		StartCoroutine(ShootAPI());
		Debug.Log("API Coroutine has started");

	}

	IEnumerator ShootAPI()
	{
		shootapi = new WWW(URL);
		yield return shootapi;
		string vResult = shootapi.text;
		if (vResult != "")
		{
			ResultText.text = ResultText.text + "\n\nJSON Result: \n" + vResult;
			apiCatcher.GetComponent<APICatcher>().apiResultContainer = JsonUtility.FromJson<APIResultContainer>(vResult);
		}
		else
		{
			Debug.Log("Uji coba gagal");
		}
	}

	
}
