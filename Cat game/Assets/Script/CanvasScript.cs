using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public Image panel1;
    public Image panel2;
    public Image panel3;

    private float counter = 0;
    private float maxCount = 7;
    private int panel = 0;


    // Update is called once per frame
    void Update()
    {
        if (panel < 4) {
            switch (panel) {
                case 0:
                    break;
                case 1:
                    panel1.color = new Color32(0, 0, 0, 0);
                    break;
                case 2:
                    panel2.color = new Color(0, 0, 0, 0);
                    break;
                case 3:
                    panel3.color = new Color(0, 0, 0, 0);
                    panel++;
                    break;
            }

            counter += Time.deltaTime;
            if (counter >= maxCount) {
                panel++;
                counter = 0;
            }
        }

    }

    

   
}
