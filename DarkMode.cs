using MelonLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

namespace CashRegisterDarkTheme
{
    public class Darkmode : MelonMod
    {
        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (buildIndex == 1)
            {
                GameObject checkoutManager = GameObject.Find("---MANAGERS---/Checkout Manager");
                if (checkoutManager != null)
                {
                    foreach (Transform checkout in checkoutManager.transform)
                    {
                        if (checkout.name.StartsWith("Checkout"))
                        {
                            Transform cashRegister = checkout.Find("Cash Register");
                            if (cashRegister != null)
                            {
                                SetColorToComponent(cashRegister.Find("Screen/BG")?.gameObject, new Color(0.208f, 0.216f, 0.294f));
                                SetColorToComponent(cashRegister.Find("Screen/Title/BG")?.gameObject, new Color(0.204f, 0.286f, 0.333f));
                                SetColorToComponent(cashRegister.Find("Screen/Title/Title")?.gameObject, new Color(0.004f, 0.612f, 0.741f));
                                SetColorToComponent(cashRegister.Find("Screen/Title/Icon")?.gameObject, new Color(0.004f, 0.612f, 0.741f));
                                SetColorToComponent(cashRegister.Find("Screen/Info Panel")?.gameObject, new Color(0.314f, 0.447f, 0.482f));
                                SetColorToComponent(cashRegister.Find("Screen/Info Panel/Divider")?.gameObject, new Color(0.004f, 0.612f, 0.741f));
                                SetColorToComponent(cashRegister.Find("Screen/Change Panel")?.gameObject, new Color(0.204f, 0.286f, 0.333f));
                            }
                        }
                    }
                }
            }
        }

        void SetColorToComponent(GameObject go, Color color)
        {
            if (go == null) return;
            var image = go.GetComponent<Image>();
            if (image != null)
            {
                image.color = color;
                return;
            }
            var rawImage = go.GetComponent<RawImage>();
            if (rawImage != null)
            {
                rawImage.color = color;
                return;
            }
            var textMeshPro = go.GetComponent<TextMeshProUGUI>();
            if (textMeshPro != null)
            {
                textMeshPro.color = color;
            }
        }
    }
}
