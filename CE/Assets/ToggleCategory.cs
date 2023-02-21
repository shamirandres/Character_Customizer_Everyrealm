using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCategory : MonoBehaviour
{
    public List<GameObject> ToggleOn;
    public GameObject container;
    public List<GameObject> menus;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < container.transform.childCount; i++) {
            menus.Add(container.transform.GetChild(i).gameObject);
        }
        EnableCategory();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableCategory()
    {
        
        foreach (GameObject option in menus) {
            if (ToggleOn.Contains(option))
            {
                option.SetActive(true);
                Debug.Log(option.name + "Activated");
            }
            else {
                option.SetActive(false);
                Debug.Log(option.name + "Deactivated");
            }

        }
    }
}
