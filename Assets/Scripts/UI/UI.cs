using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UI : MonoBehaviour
    {

        public Text score;
        public Text addScoText;
        private bool anim;
        private int addNumForAnim;
        private static UI ui;
        private float time;
        private int animStatus;
        //private bool forAnim;
        private Color color;

        public static UI getUI()
        {
            return ui;
        }
    
        void Start()
        {
            color = addScoText.color;
            color.a = 0;
            addScoText.color = color;
            ui = this;
            anim = false;
            animStatus = 0;
            time = 0f;
        }

        public void setScore(int scr)
        {
            //addScoreAnim(scr-Convert.ToInt32(score.text));
            score.text = scr + "";
        
        }


        // private void addScoreAnim(int scor)
        // {
        //     anim = true;
        //     addNumForAnim = scor;
        // }
    

    
        void Update()
        { 
            if (anim)
            {
                time += Time.deltaTime;
                switch (animStatus)
                {
                    case 0:
                        addScoText.text = "+"+addNumForAnim;
                        color.a = 0;
                        addScoText.color = color;
                        //forAnim = true;
                        animStatus = 1;
                        time = 0f;
                        break;
                    case 1:
                        color.a += time/3f  > 255 ? 255 : time/3f ;
                        addScoText.color = color;
                        if (color.a > 253)
                        {
                            animStatus = 2;
                            time = 0f;
                        }
                        break;
                    case 2:
                        Debug.Log(animStatus);
                        Vector2 vector = addScoText.transform.position;
                        vector.y += time;
                        color.a -= time/4f < 255 ? 0 : time /4f;
                        addScoText.color = color;
                        addScoText.transform.position = vector;
                        if (time /4f < 0)
                        {
                            vector = addScoText.transform.position;
                            vector.y = 487.3f;
                            addScoText.transform.position=vector;
                            time = 0f;
                            animStatus = 0;
                            anim = false;
                        }
                        break;
                
                }
            }

        
        }
    }
}
