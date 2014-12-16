using UnityEngine;
using System.Collections;

namespace M8.NGUI {
    [AddComponentMenu("M8/NGUI/ModalMessage")]
    public class ModalMessage : M8.UIModal.Dialogs.MessageDialogBase {
        public UILabel title;
        public UILabel text;

        public UIEventListener ok;

        protected override void OnSetInfo(string aTitle, string aText) {
            if(aTitle != null) title.text = aTitle;
            if(aText != null) text.text = aText;
        }

        protected override void OnActive(bool active) {
            if(active) {
                ok.onClick = OKClick;
            }
            else {
                ok.onClick = null;
            }
        }

        public override void Open() {
            LayoutBase.RefreshNow(transform);
        }

        void OKClick(GameObject go) {
            Click();
        }
    }
}