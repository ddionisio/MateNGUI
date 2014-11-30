using UnityEngine;
using System.Collections;

public class NGUIModalGraphicsDialog : UIController {
    public UIEventListener resolution;
    public UIEventListener fullscreen;
    public UIEventListener apply;
    public UIEventListener back;

    public UILabel resolutionLabel;
    public UILabel fullscreenLabel;

    private int mCurResInd;
    private bool mIsFull;

    private string[] mResLabels;
    private Resolution[] mRes;

    protected override void OnActive(bool active) {
        if(active) {
            UICamera.selectedObject = resolution.gameObject;

            resolution.onKey = OnResKey;
            fullscreen.onKey = OnFullKey;
            apply.onClick = OnApplyClick;

            if(back)
                back.onClick = OnBackClick;

            RefreshSettings(UserSettingScreen.instance);
        }
        else {
            resolution.onKey = null;
            fullscreen.onKey = null;
            apply.onClick = null;

            if(back)
                back.onClick = null;
        }
    }

    void Awake() {
        mRes = Screen.GetResolution;
        mResLabels = new string[mRes.Length];
        for(int i = 0; i < mRes.Length; i++)
            mResLabels[i] = string.Format("{0}x{1}x{2}", mRes[i].width, mRes[i].height, mRes[i].refreshRate);
    }

    void OnResKey(GameObject go, KeyCode key) {
        if(key == KeyCode.LeftArrow) {
            mCurResInd--;
            if(mCurResInd < 0)
                mCurResInd = mRes.Length - 1;

            resolutionLabel.text = mResLabels[mCurResInd];
        }
        else if(key == KeyCode.RightArrow) {
            mCurResInd++;
            if(mCurResInd == mRes.Length)
                mCurResInd = 0;

            resolutionLabel.text = mResLabels[mCurResInd];
        }
    }

    void OnFullKey(GameObject go, KeyCode key) {
        if(key == KeyCode.LeftArrow || key == KeyCode.RightArrow) {
            mIsFull = !mIsFull;

            fullscreenLabel.text = mIsFull ? "YES" : "NO";
        }
    }

    void OnApplyClick(GameObject go) {
        Resolution r = mRes[mCurResInd];
        UserSettingScreen.instance.ApplyResolution(r.width, r.height, r.refreshRate, mIsFull);
    }

    void OnBackClick(GameObject go) {
        UIModalManager.instance.ModalCloseTop();
    }

    void RefreshSettings(UserSettingScreen uss) {
        mCurResInd = 0;
        for(int i = 0; i < mRes.Length; i++) {
            Resolution r = mRes[i];
            if(r.width == uss.screenWidth && r.height == uss.screenHeight && r.refreshRate == uss.screenRefreshRate) {
                mCurResInd = i;
                break;
            }
        }

        mIsFull = uss.fullscreen;

        resolutionLabel.text = mResLabels[mCurResInd];
        fullscreenLabel.text = mIsFull ? "YES" : "NO";
    }

    void UserSettingsChanged(UserSetting s) {
        RefreshSettings(s as UserSettingScreen);
    }
}
