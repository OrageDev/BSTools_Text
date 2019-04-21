using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using System.Collections;

namespace CountersPlus
{
    public class TextHelper
    {
        /*
         * Thank the god himself Viscoci for providing me with the code to fix displaying text with Counters+.
         * 
         * I cannot thank him enough.
         */
        private TMP_Text tmp_text;
        private GameObject CanvasGO;
        private Canvas CounterCanvas;

        public TMP_Text TMP_TEXT
        {
            get { return tmp_text; }
            set { tmp_text = value; }
        }

        public GameObject CANVAS_GO
        {
            get { return CanvasGO; }
            set { CanvasGO = value; }
        }
        
        public Canvas COUNTERCANVAS
        {
            get { return CounterCanvas; }
            set { CounterCanvas = value; }
        }
        
        private float ScaleFactor = 10;
        private int count = 0;
       // public static GameObject CanvasGO;
       
            
        

        public Canvas CreateCanvas(Vector3 Position, int counter)
        {
            Canvas canvas;
            count = counter;
            CANVAS_GO =  new GameObject("BSP text" + count);
            canvas = CANVAS_GO.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.WorldSpace;
            CANVAS_GO.transform.localScale = Vector3.one * 0.1f;
            CANVAS_GO.transform.position = Position;
            count++;
            return canvas;
        }

        public void CreateTextP(Vector3 anchoredPosition, string givenText, int counter)
        {
            if (CounterCanvas == null) COUNTERCANVAS = CreateCanvas(anchoredPosition,counter);
           // tmp_text = CanvasGO.AddComponent<TMP_Text>();
            CreateText(COUNTERCANVAS, anchoredPosition, givenText);
        }

        public void CreateText(Canvas canvas, Vector3 anchoredPosition, string givenText)
        {
            var rectTransform = canvas.transform as RectTransform;
            rectTransform.sizeDelta = new Vector2(100, 50);

            TMP_TEXT = CustomUI.BeatSaber.BeatSaberUI.CreateText(rectTransform, givenText, anchoredPosition * ScaleFactor);
            TMP_TEXT.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 2f);
            TMP_TEXT.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 2f);
            TMP_TEXT.enableWordWrapping = false;
            TMP_TEXT.overflowMode = TextOverflowModes.Overflow;
            TMP_TEXT.fontSize = 1;
            TMP_TEXT.color = Color.white;
            TMP_TEXT.alignment = TextAlignmentOptions.Center;
        }


    }
}
