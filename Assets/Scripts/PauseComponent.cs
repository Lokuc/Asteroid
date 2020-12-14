using UnityEngine;


public class PauseComponent : MonoBehaviour
{

    public GameObject[] gameObjects;

    private bool p = false;
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (p != (Player.State==Player.States.Pause))
        {
            p = Player.State == Player.States.Pause;
            foreach (GameObject go in gameObjects)
            {
                go.SetActive(p);
            }
        }
    }

    private void LateUpdate()
    {
        FixedUpdate();
    }
}
