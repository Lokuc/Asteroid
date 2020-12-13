using UnityEngine;

public class Ulta : MonoBehaviour
{

    private Vector2 _vector2;
    void Start()
    {
        _vector2=new Vector2(0.06f,0.06f);
    }

    

    private void FixedUpdate()
    {
        if (Player.State == Player.States.Live)
        {
            _vector2.x += 2*Time.deltaTime;
            _vector2.y += 2*Time.deltaTime;
            gameObject.transform.localScale = _vector2;
            if (_vector2.x > 4)
            {
                Destroy(gameObject);
            }
        }
    }
}
