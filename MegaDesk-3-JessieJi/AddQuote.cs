﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_3_JessieJi
{
    public partial class AddQuote : Form
    {
        public AddQuote()
        {
            InitializeComponent();
            //deskDepthBox.Validating += new CancelEventHandler(deskWidthBox_Validating);
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = (MainMenu)this.Tag;
            mainMenu.Show();
            Close();
        }

        private void btnAddNewQuote_Click(object sender, EventArgs e)
        {
            ValidateChildren(ValidationConstraints.Enabled);
        }

        /* 
         * Validate Width
         */
        private void deskWidthBox_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg = "";
            string inputString = deskWidthBox.Text;
            if (!ValidateDeskWidth(inputString, out errorMsg))
            {
                e.Cancel = true;
                deskWidthBox.Focus();
            }
            else
            {
                e.Cancel = false;
            }
            errorProvider1.SetError(deskWidthBox, errorMsg);

        }

        public bool ValidateDeskWidth(string inputString, out string errorMsg)
        {
            int input;
            if (int.TryParse(inputString, out input))
            {
                if (input < 24 || input > 96)
                {
                    errorMsg = "Please enter a valid integer value.\n It should be between 24 and 96.";
                    return false;
                }
            }
            else //no input
            {
                errorMsg = "Please enter an integer value for the width of the desk";
                return false;
            }
            errorMsg = "";
            return true;
        }

        /* 
         * Validate Depth
         */
        /*
       private void deskDepthBox_Validating(object sender, CancelEventArgs e)
       {
           string errorMsg = "";
           string inputString = deskDepthBox.Text;
           if (!ValidateDeskDepth(inputString, out errorMsg))
           {
               e.Cancel = true;
               deskDepthBox.Focus();
           }
           else
           {
               e.Cancel = false;
           }
           errorProvider1.SetError(deskDepthBox, errorMsg);
       }

       public bool ValidateDeskDepth(string inputString, out string errorMsg)
       {
           int input;
           if (int.TryParse(inputString, out input))
           {
               if (input < 12 || input > 48)
               {
                   errorMsg = "Please enter a valid integer value.\n It should be between 12 and 48.";
                   return false;
               }
           }
           else //no input
           {
               errorMsg = "Please enter an integer value for the depth of the desk";
               return false;
           }
           errorMsg = "";
           return true;
       }
       */

        /* 
         * Validate Depth
         */
         //check what user entered at the moment
        private void deskDepthBox_Validating(object sender, KeyPressEventArgs e)
        {
            string errorMsg = "";            
            if (!char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                errorMsg = "Please enter integer value";
                e.Handled = false;
                deskDepthBox.Focus();
            }
            else
            {
                errorMsg = "";
            }
            errorProvider1.SetError(deskDepthBox, errorMsg);
        }

        //check if the value is in between min and max
        private void checkDeskDepthValue(object sender, EventArgs e)
        {
            int input;
            if (int.TryParse(deskDepthBox.Text, out input))
            {
                if (input < 12 || input > 48)
                {
                    errorProvider1.SetError(deskDepthBox, "Please enter a valid integer value.\n It should be between 12 and 48.");
                    deskDepthBox.Focus();
                }
            }
            else
            {
                errorProvider1.SetError(deskDepthBox, "Please enter an integer value for the depth of the desk");
                deskDepthBox.Focus();
            }
        }
        /* 
         * Validate Num
         */
        private void numDrawerBox_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg = "";
            string inputString = numDrawerBox.Text;
            if (!ValidateNumDrawer(inputString, out errorMsg))
            {
                e.Cancel = true;
                numDrawerBox.Focus();
            }
            else
            {
                e.Cancel = false;
            }
            errorProvider1.SetError(numDrawerBox, errorMsg);
        }

        public bool ValidateNumDrawer(string inputString, out string errorMsg)
        {
            int input;
            if (int.TryParse(inputString, out input))
            {
                if (input < 0 || input > 7)
                {
                    errorMsg = "Please enter a valid integer value.\n It should be between 0 and 7.";
                    return false;
                }
            }
            else //no input
            {
                errorMsg = "Please enter an integer value for the number of drawers";
                return false;
            }
            errorMsg = "";
            return true;
        }

    }
}
