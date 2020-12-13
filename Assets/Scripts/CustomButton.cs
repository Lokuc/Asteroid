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
        on.SetActive(Active);
        off.SetActive(!Active);

    }

    // Update is called once per frame
    void Update()
    {
        setActive(Input.GetKey(key));
    }
}
