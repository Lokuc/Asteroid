using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Updates;

public class MainUpdaiter : MonoBehaviour
{

    public Minigun _minigun;

    public DounleGun _dounleGun;
    void Start()
    {
        
    }

    public enum Updates
    {
        MiniGun=0,
        DoubleGun
    }

    public Boolean getActive(Updates updates)
    {
        switch (updates)
        {
            case Updates.DoubleGun:
                return _dounleGun.active;
            case Updates.MiniGun:
                return _minigun.active;
        }

        return false;
    }

    public void activate(Updates updates)
    {
        switch (updates)
        {
            case Updates.DoubleGun:
                _dounleGun.activate();
                break;
            case Updates.MiniGun:
                _minigun.activate();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        _minigun.Updates();
        _dounleGun.Updates();
    }

    public void deActivate(Updates updates)
    {
        switch (updates)
        {
            case Updates.DoubleGun:
                _dounleGun.deActivate();
                break;
        }
    }
}
