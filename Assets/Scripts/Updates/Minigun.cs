
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
                return 3f;
            }
         
        }

        public void activate()
        {
            if (active)
            {
                Asteroid.score += 50;
                UI.UI.getUI().setScore(Asteroid.score);
                return;
            }
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
                timer += Time.deltaTime;
                if (timer > time)
                {
                    active = false;
                }
            }
        }

        public void Updates()
        {
            Update();
        }
    }
}
