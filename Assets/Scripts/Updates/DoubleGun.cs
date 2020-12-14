using UnityEngine;

namespace Updates
{
    public class DoubleGun : MonoBehaviour, Updaiter
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
                return -1f;
            }
         
        }

        public void deActivate()
        {
            active = false;
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
        
        public void Updates()
        {
            Update();
        }

        // Update is called once per frame
        void Update()
        {
            if (active&&time>0f)
            {
                timer++;
            }

            if (timer > time&&time>0f)
            {
                active = false;
            }
        }
    }
}
