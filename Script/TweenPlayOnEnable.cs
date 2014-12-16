using UnityEngine;
using System.Collections;

namespace M8.NGUI {
    [AddComponentMenu("M8/NGUI/TweenPlayOnEnable")]
    public class TweenPlayOnEnable : MonoBehaviour {

        public UITweener tweener;

        void OnEnable() {
            tweener.enabled = true;
            tweener.SetStartToCurrentValue();
            tweener.SetEndToCurrentValue();
        }

        void Awake() {
            if(tweener == null)
                tweener = GetComponent<UITweener>();
        }
    }
}