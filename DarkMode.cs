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
using HarmonyLib;
using MelonLoader.Utils;

namespace CheckoutTheme
{
    public class Darkmode : MelonMod
    {
        private MelonPreferences_Category themeCat;
        private MelonPreferences_Entry<string> cashRegisterBg;
        private MelonPreferences_Entry<string> cashRegisterTitleBg;
        private MelonPreferences_Entry<string> cashRegisterTitleText;
        private MelonPreferences_Entry<string> cashRegisterInfoPanel;
        private MelonPreferences_Entry<string> cashRegisterInfoPanelText;
        private MelonPreferences_Entry<string> cashRegisterInfoPanelCorrectChange;
        private MelonPreferences_Entry<string> cashRegisterInfoPanelDivider;
        private MelonPreferences_Entry<string> cashRegisterChangePanel;
        private MelonPreferences_Entry<string> paymentScreenBg;
        private MelonPreferences_Entry<string> paymentScreenTitleBg;
        private MelonPreferences_Entry<string> paymentScreenTitleText;
        private MelonPreferences_Entry<string> paymentScreenHeaders;
        private MelonPreferences_Entry<string> paymentScreenTotalPanelBg;
        private MelonPreferences_Entry<string> paymentScreenTotalBg;
        private MelonPreferences_Entry<string> paymentScreenTotalText;
        private MelonPreferences_Entry<string> posScreenBg;
        private MelonPreferences_Entry<string> posScreenInputBg;
        private MelonPreferences_Entry<string> posScreenInputText;
        private MelonPreferences_Entry<string> posScreenTotalTitle;
        private MelonPreferences_Entry<string> posScreenButtonBg;
        private MelonPreferences_Entry<string> posScreenButtonText;
        public static MelonPreferences_Entry<string> checkoutItemText;

        public override void OnInitializeMelon()
        {
            themeCat = MelonPreferences.CreateCategory("Checkout Theme");
            if (Directory.Exists("MLLoader") && Directory.Exists("BepInEx"))
            {
                themeCat.SetFilePath("MLLoader/UserData/checkouttheme.cfg", autoload: false);
            }
            else
            {
                themeCat.SetFilePath("UserData/checkouttheme.cfg", autoload: false);
            }

            CreateEntries();

            if (File.Exists("MLLoader/UserData/checkouttheme.cfg") || File.Exists("UserData/checkouttheme.cfg"))
            {
                themeCat.LoadFromFile();
            }
            else
            {
                themeCat.SaveToFile();
            }
        }
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
                                SetColorToComponent(cashRegister.Find("Screen/BG")?.gameObject, ColorFromHexString(cashRegisterBg.Value));
                                SetColorToComponent(cashRegister.Find("Screen/Title/BG")?.gameObject, ColorFromHexString(cashRegisterTitleBg.Value));
                                SetColorToComponent(cashRegister.Find("Screen/Title/Title")?.gameObject, ColorFromHexString(cashRegisterTitleText.Value));
                                SetColorToComponent(cashRegister.Find("Screen/Title/Icon")?.gameObject, ColorFromHexString(cashRegisterTitleText.Value));
                                SetColorToComponent(cashRegister.Find("Screen/Info Panel")?.gameObject, ColorFromHexString(cashRegisterInfoPanel.Value));
								SetColorToComponent(cashRegister.Find("Screen/Info Panel/Received")?.gameObject, ColorFromHexString(cashRegisterInfoPanelText.Value));
								SetColorToComponent(cashRegister.Find("Screen/Info Panel/Received MoneyText")?.gameObject, ColorFromHexString(cashRegisterInfoPanelText.Value));
								SetColorToComponent(cashRegister.Find("Screen/Info Panel/Total Price")?.gameObject, ColorFromHexString(cashRegisterInfoPanelText.Value));
								SetColorToComponent(cashRegister.Find("Screen/Info Panel/Total Price Text")?.gameObject, ColorFromHexString(cashRegisterInfoPanelText.Value));
                                SetColorToComponent(cashRegister.Find("Screen/Info Panel/Divider")?.gameObject, ColorFromHexString(cashRegisterInfoPanelDivider.Value));
								SetColorToComponent(cashRegister.Find("Screen/Info Panel/Correct Change")?.gameObject, ColorFromHexString(cashRegisterInfoPanelText.Value));
								SetColorToComponent(cashRegister.Find("Screen/Info Panel/Correct Change Text")?.gameObject, ColorFromHexString(cashRegisterInfoPanelCorrectChange.Value));
                                SetColorToComponent(cashRegister.Find("Screen/Change Panel")?.gameObject, ColorFromHexString(cashRegisterChangePanel.Value));
                            }
                            Transform paymentScreen = checkout.Find("Payment Screen");
                            if (paymentScreen != null)
                            {
                                SetColorToComponent(paymentScreen.Find("Screen Canvas/BG")?.gameObject, ColorFromHexString(paymentScreenBg.Value));
                                SetColorToComponent(paymentScreen.Find("Screen Canvas/Title")?.gameObject, ColorFromHexString(paymentScreenTitleBg.Value));
                                SetColorToComponent(paymentScreen.Find("Screen Canvas/Title/Checkout")?.gameObject, ColorFromHexString(paymentScreenTitleText.Value));
                                SetColorToComponent(paymentScreen.Find("Screen Canvas/Title/Icon")?.gameObject, ColorFromHexString(paymentScreenTitleText.Value));
                                SetColorToComponent(paymentScreen.Find("Screen Canvas/Headers/Product Name")?.gameObject, ColorFromHexString(paymentScreenHeaders.Value));
                                SetColorToComponent(paymentScreen.Find("Screen Canvas/Headers/Unit")?.gameObject, ColorFromHexString(paymentScreenHeaders.Value));
                                SetColorToComponent(paymentScreen.Find("Screen Canvas/Headers/Price")?.gameObject, ColorFromHexString(paymentScreenHeaders.Value));
                                SetColorToComponent(paymentScreen.Find("Screen Canvas/Headers/Total")?.gameObject, ColorFromHexString(paymentScreenHeaders.Value));
                                SetColorToComponent(paymentScreen.Find("Screen Canvas/Headers/Divider")?.gameObject, ColorFromHexString(paymentScreenHeaders.Value));
                                SetColorToComponent(paymentScreen.Find("Screen Canvas/Items Viewport")?.gameObject, new Color(1f, 1f, 1f, 0f));
                                SetColorToComponent(paymentScreen.Find("Screen Canvas/Total Panel/BG")?.gameObject, ColorFromHexString(paymentScreenTotalPanelBg.Value));
                                SetColorToComponent(paymentScreen.Find("Screen Canvas/Total Panel/Total BG")?.gameObject, ColorFromHexString(paymentScreenTotalBg.Value));
                                SetColorToComponent(paymentScreen.Find("Screen Canvas/Total Panel/Total BG/Total")?.gameObject, ColorFromHexString(paymentScreenTotalText.Value));
                                SetColorToComponent(paymentScreen.Find("Screen Canvas/Total Panel/Total BG/Total Price Text")?.gameObject, ColorFromHexString(paymentScreenTotalText.Value));
                            }
                            Transform posScreen = checkout.Find("POS Stand/POS Terminal/Pos Screen");
                            if (posScreen != null)
                            {
                                SetColorToComponent(posScreen.Find("BG")?.gameObject, ColorFromHexString(posScreenBg.Value));
                                SetColorToComponent(posScreen.Find("Total Title")?.gameObject, ColorFromHexString(posScreenTotalTitle.Value));
								SetColorToComponent(posScreen.Find("Input BG")?.gameObject, ColorFromHexString(posScreenInputBg.Value));
								SetColorToComponent(posScreen.Find("Input BG/Input")?.gameObject, ColorFromHexString(posScreenInputText.Value));
								SetColorToComponent(posScreen.Find("Input BG/Dollar Sign")?.gameObject, ColorFromHexString(posScreenInputText.Value));

                                SetColorToComponent(posScreen.Find("Buttons BG/Remove Button")?.gameObject, ColorFromHexString(posScreenButtonBg.Value));
                                SetColorToComponent(posScreen.Find("Buttons BG/Remove Button/Icon (1)")?.gameObject, ColorFromHexString(posScreenButtonText.Value));
                                GameObject buttonsBg = posScreen.Find("Buttons BG")?.gameObject;
                                if(buttonsBg != null)
                                {
                                    SetColorToComponent(buttonsBg, ColorFromHexString(posScreenButtonBg.Value));
                                    foreach (Transform button in buttonsBg.transform)
                                    {
                                        if (button.name.StartsWith("Button"))
                                        {
                                            SetColorToComponent(button.gameObject, ColorFromHexString(posScreenButtonBg.Value));
                                            SetColorToComponent(button.Find("Text (TMP)")?.gameObject, ColorFromHexString(posScreenButtonText.Value));
                                        }
                                    }
                                }
                                SetColorToComponent(posScreen.Find("Buttons BG/Remove Button")?.gameObject, ColorFromHexString(posScreenButtonBg.Value));
                                SetColorToComponent(posScreen.Find("Buttons BG/Remove Button/Icon (1)")?.gameObject, ColorFromHexString(posScreenButtonText.Value));
                            }
                        }
                    }
                }
            }
        }

        private void CreateEntries()
        {
            // Cash Register Screen
            cashRegisterBg = themeCat.CreateEntry<string>("cashRegisterBg", ColorToHexString(new Color(0.208f, 0.216f, 0.294f)),null,"Cash Register Screen");
            cashRegisterTitleBg = themeCat.CreateEntry<string>("cashRegisterTitleBg", ColorToHexString(new Color(0.204f, 0.286f, 0.333f)));
            cashRegisterTitleText = themeCat.CreateEntry<string>("cashRegisterTitleText", ColorToHexString(new Color(0.004f, 0.612f, 0.741f)));
            cashRegisterInfoPanel = themeCat.CreateEntry<string>("cashRegisterInfoPanel", ColorToHexString(new Color(0.314f, 0.447f, 0.482f)));
            cashRegisterInfoPanelText = themeCat.CreateEntry<string>("cashRegisterInfoPanelText", ColorToHexString(Color.white));
            cashRegisterInfoPanelCorrectChange = themeCat.CreateEntry<string>("cashRegisterInfoPanelCorrectChange", ColorToHexString(new Color(1f, 0.9324f, 0.5047f)));
            cashRegisterInfoPanelDivider = themeCat.CreateEntry<string>("cashRegisterInfoPanelDivider", ColorToHexString(new Color(0.004f, 0.612f, 0.741f)));
            cashRegisterChangePanel = themeCat.CreateEntry<string>("cashRegisterChangePanel", ColorToHexString(new Color(0.204f, 0.286f, 0.333f)));

            // Payment Screen
            paymentScreenBg = themeCat.CreateEntry<string>("paymentScreenBg", ColorToHexString(new Color(0.208f, 0.216f, 0.294f)),null,"Payment Screen");
            paymentScreenTitleBg = themeCat.CreateEntry<string>("paymentScreenTitleBg", ColorToHexString(new Color(0.204f, 0.286f, 0.333f)));
            paymentScreenTitleText = themeCat.CreateEntry<string>("paymentScreenTitleText", ColorToHexString(new Color(0.004f, 0.612f, 0.741f)));
            paymentScreenHeaders = themeCat.CreateEntry<string>("paymentScreenHeaders", ColorToHexString(Color.white));
            paymentScreenTotalPanelBg = themeCat.CreateEntry<string>("paymentScreenTotalPanelBg", ColorToHexString(new Color(0.5294f, 0.6745f, 0.7843f, 0.2353f)));
            paymentScreenTotalBg = themeCat.CreateEntry<string>("paymentScreenTotalBg", ColorToHexString(new Color(0.5294f, 0.6745f, 0.7843f)));
            paymentScreenTotalText = themeCat.CreateEntry<string>("paymentScreenTotalText", ColorToHexString(Color.white));

            // POS Screen
            posScreenBg = themeCat.CreateEntry<string>("posScreenBg", ColorToHexString(new Color(0.204f, 0.286f, 0.333f)),null,"Card Reader Screen");
            posScreenInputBg = themeCat.CreateEntry<string>("posScreenInputBg", ColorToHexString(new Color(0.0566f, 0.1376f, 0.2264f)));
            posScreenInputText = themeCat.CreateEntry<string>("posScreenInputText", ColorToHexString(Color.white));
            posScreenTotalTitle = themeCat.CreateEntry<string>("posScreenTotalTitle", ColorToHexString(new Color(0.004f, 0.612f, 0.741f)));
            posScreenButtonBg = themeCat.CreateEntry<string>("posScreenButtonBg", ColorToHexString(new Color(0.0566f, 0.1376f, 0.2264f)));
            posScreenButtonText = themeCat.CreateEntry<string>("posScreenButtonText", ColorToHexString(Color.white));

            // Checkout Item
            checkoutItemText = themeCat.CreateEntry<string>("checkoutItemText", ColorToHexString(new Color(0.004f, 0.612f, 0.741f)),null,"Checkout items on the Payment screen");
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

        public static Color ColorFromHexString(string hex)
        {
            ColorUtility.TryParseHtmlString(hex, out var color);
            return color;
        }

        public static string ColorToHexString(Color c)
        {
            return "#" + ColorUtility.ToHtmlStringRGBA(c);
        }
    }

    [HarmonyPatch(typeof(CheckoutItem))]
    [HarmonyPatch("UpdateUI")]
    public class CheckoutItemUpdateUIPatch
    {
        static void Postfix(CheckoutItem __instance)
        {
            Color itemColour = Darkmode.ColorFromHexString(Darkmode.checkoutItemText.Value);

            // Accessing private fields using Harmony's AccessTools
            TMP_Text productNameText = AccessTools.FieldRefAccess<CheckoutItem, TMP_Text>(__instance, "m_ProductNameText");
            TMP_Text unitCountText = AccessTools.FieldRefAccess<CheckoutItem, TMP_Text>(__instance, "m_UnitCountText");
            TMP_Text priceText = AccessTools.FieldRefAccess<CheckoutItem, TMP_Text>(__instance, "m_PriceText");
            TMP_Text totalText = AccessTools.FieldRefAccess<CheckoutItem, TMP_Text>(__instance, "m_TotalText");

            if (productNameText != null) productNameText.color = itemColour;
            if (unitCountText != null) unitCountText.color = itemColour;
            if (priceText != null) priceText.color = itemColour;
            if (totalText != null) totalText.color = itemColour;
        }
    }
}
