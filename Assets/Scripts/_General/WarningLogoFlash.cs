using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningLogoFlash : MonoBehaviour
{
    public Image startLine;

    IEnumerator Start()
    {
        while (true)
        {
            //startLine.canvasRenderer.SetAlpha(0.0f);

            //fadein
            yield return new WaitForSeconds(1.0f);
            startLine.CrossFadeAlpha(1.0f, 0.5f, false);

            yield return new WaitForSeconds(1.0f);

            // fadeout
            yield return new WaitForSeconds(1.0f);
            startLine.CrossFadeAlpha(0.0f, 1.5f, false);

            yield return new WaitForSeconds(0.5f);
        }
    }
}
