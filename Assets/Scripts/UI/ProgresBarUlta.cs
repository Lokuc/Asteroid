using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ProgresBarUlta : MonoBehaviour
    {
    
        public Slider progresBar;
        private static float num;
        public GameObject hide;
        private bool ulraReady;
        public GameObject Ulta;
        private bool toUp;
        private Color _color;
        private GameObject ult;
        private Vector2 vector;
        private Image spriteRenderer;
    
    
        // Start is called before the first frame update
        void Start()
        {
            spriteRenderer= hide.GetComponent<Image>();
            _color = spriteRenderer.color;
            spriteRenderer.color = _color;
            toUp = true;
            vector = new Vector2();
            progresBar.value = 0f;
            ulraReady = false;
        }

        public static void addTime(float f)
        {
            num += f;
        }
    

        // Update is called once per frame
        void Update()
        {
            if (progresBar.value > 1f) {progresBar.value = 1f;}
        
            if (!ulraReady)
            {
                //time += Time.deltaTime;
                progresBar.value += num;
                num = 0f;
            }
            else
            {
                if (toUp)
                {

                    _color.a += Time.deltaTime*1.5f;
                    if (_color.a >= 1f)
                    {
                        _color.a = 1f;
                        toUp = false;
                    }
                }
                else
                {
                
                    _color.a -= Time.deltaTime*1.5f;
                    if (_color.a <= 0f)
                    {
                        toUp = true;
                        _color.a = 0f;
                    }
                }
                spriteRenderer.color = _color;

            }

            if (!ulraReady)
            {
                if (progresBar.value >= 1f)
                {
                    ulraReady = true;
                    _color.a = 1f;
                    toUp = false;
                    num = 0f;
                }
            }
        }
    

        public void UltaShot(Vector2 position)
        {
            if (ulraReady)
            {
                ulraReady = false;
                num = 0f;
                progresBar.value = 0f;
                ult = Instantiate(Ulta);
                vector.x = 0.06f;
                vector.y = 0.06f;
                ult.transform.localScale = vector;
                ult.transform.position = position;
                _color.a = 1f;
                spriteRenderer.color = _color;
            }
        }
    
    }
}
