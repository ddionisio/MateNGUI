using UnityEngine;
using System.Collections;

[AddComponentMenu("M8/NGUI/ModalMessage")]
public class NGUIModalMessage : UIModalMessage {
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
        NGUILayoutBase.RefreshNow(transform);
    }

    void OKClick(GameObject go) {
        Click();
    }
}
