using UnityEngine;
using System.Collections;

[AddComponentMenu("M8/NGUI/ModalConfirm")]
public class NGUIModalConfirm : UIModalConfirm {
    public UILabel title;
    public UILabel text;

    public UIEventListener yes;
    public UIEventListener no;

    protected override void OnSetInfo(string aTitle, string aText) {
        if(aTitle != null) title.text = aTitle;
        if(aText != null) text.text = aText;
    }

    protected override void OnActive(bool active) {
        if(active) {
            yes.onClick = YesClick;
            no.onClick = NoClick;

            UICamera.selectedObject = no.gameObject;
        }
        else {
            yes.onClick = null;
            no.onClick = null;
        }
    }

    protected override void OnOpen() {
        NGUILayoutBase.RefreshNow(transform);
    }

    protected override void OnClose() {
    }

    void YesClick(GameObject go) {
        Click(true);
    }

    void NoClick(GameObject go) {
        Click(false);
    }
}
