using UnityEngine;

namespace Updates
{
    public class Minigun : MonoBehaviour, Updaiter
    {
    

        public float timer
        {
            get;
            private set;
        }
        public bool active
        {
            get;
            private set;

        }
        public float time
        {
            get
            {
                return 2f;
            }
         
        }

        public void activate()
        {
            active = true;
            timer = 0f;
        }

        // Start is called before the first frame update
        void Start()
        {
            active = false;
            timer = 0f;
        }

        // Update is called once per frame
        void Update()
        {
            if (active)
            {
                timer++;
            }

            if (timer > time)
            {
                active = false;
            }
        }

    
    }
}
