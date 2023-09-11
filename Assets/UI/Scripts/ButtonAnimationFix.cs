using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.Dark
{
    public class ButtonAnimationFix : MonoBehaviour
    {
        private Button fixButton;

        void Start()
        {
            fixButton = gameObject.GetComponent<Button>();
            fixButton.onClick.AddListener(Fix);
        }

        public void Fix()
        {
            // bayad object hamono faal va gheir faal konim vararna rooye 
            // on animation highlight gir mikone. moshkele man nis
            // moshkele Unity hast :))))))
            fixButton.gameObject.SetActive(false);
            fixButton.gameObject.SetActive(true);
        }
    }
}