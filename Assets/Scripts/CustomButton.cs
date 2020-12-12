using System;
using UnityEngine;

public class CustomButton : MonoBehaviour
{

    public GameObject on;
    public GameObject off;
    [SerializeField]
    private KeyCode key;
    private bool isActive;


    // Start is called before the first frame update
    void Start()
    {
        setActive(false);
    }

    private void setActive(bool Active)
    {
        if (Active == isActive)
        {
            return;
        }
        isActive = Active;
        if (isActive)
        {
            on.SetActive(true);
            off.SetActive(false);
        }
        else
        {
            on.SetActive(false);
            off.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        setActive(Input.GetKey(key));
    }
}
