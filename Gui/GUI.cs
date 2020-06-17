using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Bbuu20_s_Recoil_Handler_V2
{
    public partial class GUI : Form
    {
        private static RadioButton[] radioButtons;
        public static Button[] bindButtons;
        public static short selectedWeapon = 0;
        private static short selectedOptic = 4;
        private static short selectedAttachment = 2;
        public static short selectedBind = 0;
        public static string newBindText = "";

        public GUI()
        {
            InitializeComponent();
            radioButtons = new RadioButton[] { nailgunButton, revolverButton, pythonButton, p2Button, m9Button, customButton, thompsonButton, mp5Button, sarButton, akButton, m39Button, lrButton, m2Button };
            bindButtons = new Button[] { nailgunBind, revBind, pythonBind, p2Bind, m9Bind, customBind, thompsonBind, mp5Bind, sarBind, akBind, m39Bind, lrBind, m2Bind };
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void nailgunButton_CheckedChanged(object sender, EventArgs e)
        {
            SelectedWeaponChanged(nailgunButton, 0);
        }

        private void revolverButton_CheckedChanged(object sender, EventArgs e)
        {
            SelectedWeaponChanged(revolverButton, 1);
        }

        private void pythonButton_CheckedChanged(object sender, EventArgs e)
        {
            SelectedWeaponChanged(pythonButton, 2);
        }

        private void p2Button_CheckedChanged(object sender, EventArgs e)
        {
            SelectedWeaponChanged(p2Button, 3);
        }

        private void m9Button_CheckedChanged(object sender, EventArgs e)
        {
            SelectedWeaponChanged(m9Button, 4);
        }

        private void customButton_CheckedChanged(object sender, EventArgs e)
        {
            SelectedWeaponChanged(customButton, 5);
        }

        private void thompsonButton_CheckedChanged(object sender, EventArgs e)
        {
            SelectedWeaponChanged(thompsonButton, 6);
        }

        private void mp5Button_CheckedChanged(object sender, EventArgs e)
        {
            SelectedWeaponChanged(mp5Button, 7);
        }

        private void sarButton_CheckedChanged(object sender, EventArgs e)
        {
            SelectedWeaponChanged(sarButton, 8);
        }

        private void akButton_CheckedChanged(object sender, EventArgs e)
        {
            SelectedWeaponChanged(akButton, 9);
        }

        private void m39Button_CheckedChanged(object sender, EventArgs e)
        {
            SelectedWeaponChanged(m39Button, 10);
        }

        private void lrButton_CheckedChanged(object sender, EventArgs e)
        {
            SelectedWeaponChanged(lrButton, 11);
        }

        private void m2Button_CheckedChanged(object sender, EventArgs e)
        {
            SelectedWeaponChanged(m2Button, 12);
        }

        private void SelectedWeaponChanged(RadioButton selectedButton, short weaponIndex)
        {
            if (selectedButton.Checked)
            {
                //Console.WriteLine(selectedButton.Name);
                selectedWeapon = weaponIndex;
            }
        }

        public void UpdateSelectedWeapon()
        {
            radioButtons[selectedWeapon].Checked = true;
        }

        public void UpdateSelectedBind()
        {
            bindButtons[selectedBind].Text = newBindText;
        }

        public void UpdateTriggerBind()
        {
            TriggerBind.Text = newBindText;
            RecoilHandler.triggerKey = MainApp.KeyToHex(MainApp.SearchControls(0, "\\res\\Profile Settings\\Settings.txt"));
        }

        public void UpdateTrackLabel()
        {
            sensLabel.Text = "Sensitivity (" + newBindText + ")";
            sensitivityBar.Value = (int)(Double.Parse(newBindText) * 10);
        }

        private void UpdateTextFile(short selectedBind, Button buttonClicked, string path, Keys[] keys)
        {
            while (true)
            {
                if (InputHandler.IsKeyDown())
                {
                    string keyDown = InputHandler.GetKeyDown().ToString();
                    buttonClicked.Text = keyDown;
                    string textToWrite = "";
                    IEnumerable<string> keyText = File.ReadAllLines(Application.StartupPath + path);
                    int i = 0;
                    foreach (Keys key in keys)
                    {
                        if (i == selectedBind)
                        {
                            textToWrite += keyDown + "\n";
                        }
                        else
                        {
                            textToWrite += keyText.Skip(i).First() + "\n";
                        }
                        ++i;
                    }
                    File.WriteAllText(Application.StartupPath + path, textToWrite);
                    MainApp.UpdateControls();
                    break;
                }
                Thread.Sleep(10);
            }
        }

        private void nailgunBind_Click(object sender, EventArgs e)
        {
            UpdateTextFile(0, nailgunBind, "\\res\\Profile Settings\\Keys.txt", MainApp.keys);
        }

        private void revBind_Click(object sender, EventArgs e)
        {
            UpdateTextFile(1, revBind, "\\res\\Profile Settings\\Keys.txt", MainApp.keys);
        }

        private void pythonBind_Click(object sender, EventArgs e)
        {
            UpdateTextFile(2, pythonBind, "\\res\\Profile Settings\\Keys.txt", MainApp.keys);
        }

        private void p2Bind_Click(object sender, EventArgs e)
        {
            UpdateTextFile(3, p2Bind, "\\res\\Profile Settings\\Keys.txt", MainApp.keys);
        }

        private void m9Bind_Click(object sender, EventArgs e)
        {
            UpdateTextFile(4, m9Bind, "\\res\\Profile Settings\\Keys.txt", MainApp.keys);
        }

        private void customBind_Click(object sender, EventArgs e)
        {
            UpdateTextFile(5, customBind, "\\res\\Profile Settings\\Keys.txt", MainApp.keys);
        }

        private void thompsonBind_Click(object sender, EventArgs e)
        {
            UpdateTextFile(6, thompsonBind, "\\res\\Profile Settings\\Keys.txt", MainApp.keys);
        }

        private void mp5Bind_Click(object sender, EventArgs e)
        {
            UpdateTextFile(7, mp5Bind, "\\res\\Profile Settings\\Keys.txt", MainApp.keys);
        }

        private void sarBind_Click(object sender, EventArgs e)
        {
            UpdateTextFile(8, sarBind, "\\res\\Profile Settings\\Keys.txt", MainApp.keys);
        }

        private void akBind_Click(object sender, EventArgs e)
        {
            UpdateTextFile(9, akBind, "\\res\\Profile Settings\\Keys.txt", MainApp.keys);
        }

        private void m39Bind_Click(object sender, EventArgs e)
        {
            UpdateTextFile(10, m39Bind, "\\res\\Profile Settings\\Keys.txt", MainApp.keys);
        }

        private void lrBind_Click(object sender, EventArgs e)
        {
            UpdateTextFile(11, lrBind, "\\res\\Profile Settings\\Keys.txt", MainApp.keys);
        }

        private void m2Bind_Click(object sender, EventArgs e)
        {
            UpdateTextFile(12, m2Bind, "\\res\\Profile Settings\\Keys.txt", MainApp.keys);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void TriggerBind_Click(object sender, EventArgs e)
        {
            UpdateTextFile(0, TriggerBind, "\\res\\Profile Settings\\Settings.txt", MainApp.settingsKeys);
        }

        private void sensitivityBar_Scroll(object sender, EventArgs e)
        {
            IEnumerable<string> file = File.ReadAllLines(Application.StartupPath + "\\res\\Profile Settings\\Settings.txt");
            string textToWrite = "";
            string newLabelText = ((double)sensitivityBar.Value / 10).ToString();
            textToWrite += file.Skip(0).First() + "\n" + newLabelText;
            File.WriteAllText(Application.StartupPath + "\\res\\Profile Settings\\Settings.txt", textToWrite);
            sensLabel.Text = "Sensitivity (" + newLabelText + ")";
            RecoilHandler.sensitivity = Double.Parse(File.ReadAllLines(Application.StartupPath + "\\res\\Profile Settings\\Settings.txt").Skip(1).First());
        }

        private void handmadeButton_CheckedChanged(object sender, EventArgs e)
        {
            SelectedOpticChanged(-20, 0);
        }

        private void holoButton_CheckedChanged(object sender, EventArgs e)
        {
            SelectedOpticChanged(20, 1);
        }

        private void scope8xButton_CheckedChanged(object sender, EventArgs e)
        {
            SelectedOpticChanged(67.5, 2);
        }

        private void scope16xButton_CheckedChanged(object sender, EventArgs e)
        {
            SelectedOpticChanged(78.5, 3);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SelectedOpticChanged(0, 4);
        }

        private void SelectedOpticChanged(double fovChange, short opticIndex)
        {
            if (opticIndex == selectedOptic) //if this is the previously selected optic
            {
                RecoilHandler.fov += fovChange;
            }
            else
            {
                selectedOptic = opticIndex;
                RecoilHandler.fov -= fovChange;
            }
        }

        private void silencerButton_CheckedChanged(object sender, EventArgs e)
        {
            if (selectedAttachment == 0) //if this is the selected attachment
            {
                RecoilHandler.recoilMultiplier += 0.2;
            }
            else
            {
                RecoilHandler.recoilMultiplier -= 0.2;
                selectedAttachment = 0;
            }
        }

        private void boostButton_CheckedChanged(object sender, EventArgs e)
        {
            if (selectedAttachment == 1) //if this is the selected attachment
            {
                RecoilHandler.fireRateMultiplier += 0.1;
            }
            else
            {
                RecoilHandler.fireRateMultiplier -= 0.1;
                selectedAttachment = 1;
            }
        }

        private void noAttachmentButton_CheckedChanged(object sender, EventArgs e)
        {
            if (selectedAttachment != 2) //if this is the selected attachment
            {
                selectedAttachment = 2;
            }
        }
    }
}
