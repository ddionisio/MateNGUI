using UnityEngine;
using System.Collections;

namespace M8.NGUI {
    [AddComponentMenu("M8/NGUI/SelectClick")]
    public class SelectClick : MonoBehaviour {
        public GameObject select;

        void OnClick() {
            if(enabled && select != null) {
                UICamera.selectedObject = select;
            }
        }
    }
}