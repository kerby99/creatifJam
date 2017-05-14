using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour {

    private GameObject[] characterList;
    private int index;

	// Use this for initialization
	void Start () {

        index = PlayerPrefs.GetInt("characterSelected");

        characterList = new GameObject[transform.childCount];
       
        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }
        foreach (GameObject go in characterList)
        {
            go.SetActive(false);
        }
        if (characterList[index])
        {
            characterList[index].SetActive(true);
        }
        if (Input.GetButton("Start"))
        {
            confirm();
        }
	}
	
    public void toggleLeft()
    {
        characterList[index].SetActive(false);

        index--;
        if(index < 0)
        {
            index = characterList.Length - 1;
        }

        characterList[index].SetActive(true);
    }

    public void toggleRight()
    {
        characterList[index].SetActive(false);

        index++;
        if (index == characterList.Length)
        {
            index = 0;
        }

        characterList[index].SetActive(true);
    }

    public void confirm()
    {
        PlayerPrefs.SetInt("characterSelected", index);
        SceneManager.LoadScene("scene1");
    }

    // Update is called once per frame
    void Update () {
	
	}
}
