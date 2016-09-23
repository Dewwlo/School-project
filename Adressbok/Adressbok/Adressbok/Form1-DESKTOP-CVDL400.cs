using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Adressbok
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Address> contact = new List<Address>();
        


        private void Form1_Load(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader("address book2.txt"))
            {
                string[] info = new string[7];
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    info = line.Split(',');
                    Address getInfo = new Address(info[0], info[1], info[2], info[3], info[4], info[5], Guid.Parse(info[6]));
                    listInformation.Items.Add(string.Format("{0} {1} {2} {3} {4} {5}", info[0], info[1], info[2], info[3], info[4], info[5]));
                    contact.Add(getInfo);
                }
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (StreamWriter sr = new StreamWriter("address book2.txt"))
            {
                foreach (var c in contact)
                {
                    sr.WriteLine(string.Format("{0},{1},{2},{3},{4},{5},{6}", c.Name, c.StreetAddress, c.Zip, c.City, c.Email, c.PhoneNumber, c.Id));
                }
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveChange();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {

            Search();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void cmdAddContact_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtStreetAddress.Clear();
            txtZip.Clear();
            txtCity.Clear();
            txtEmail.Clear();
            txtPhoneNumber.Clear();
        }

        public void AddContact()
        {
            if (CheckInput() == true)
            {
                Guid guid = Guid.NewGuid();
                Address info = new Address(txtName.Text.Trim(), txtStreetAddress.Text.Trim(), txtZip.Text.Trim(), txtCity.Text.Trim(), txtEmail.Text.Trim(), txtPhoneNumber.Text.Trim(), guid);
                contact.Add(info);
                listInformation.Items.Add(string.Format("{0} {1} {2} {3} {4} {5}", info.Name, info.StreetAddress, info.Zip, info.City, info.Email, info.PhoneNumber));
                txtName.Clear();
                txtStreetAddress.Clear();
                txtZip.Clear();
                txtCity.Clear();
                txtEmail.Clear();
                txtPhoneNumber.Clear();
            }
            else
            {
                MessageBox.Show("All text boxes must be filled out!");
            }
        }

        private void listInformation_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listInformation.SelectedItems.Count == 0)
            {
                return;
            }
            txtName.Text = contact[listInformation.SelectedItems[0].Index].Name;
            txtStreetAddress.Text = contact[listInformation.SelectedItems[0].Index].StreetAddress;
            txtZip.Text = contact[listInformation.SelectedItems[0].Index].Zip;
            txtCity.Text = contact[listInformation.SelectedItems[0].Index].City;
            txtEmail.Text = contact[listInformation.SelectedItems[0].Index].Email;
            txtPhoneNumber.Text = contact[listInformation.SelectedItems[0].Index].PhoneNumber;
        }

        public void Delete()
        {
            try
            {
                contact.RemoveAt(listInformation.SelectedItems[0].Index);
                listInformation.Items.Remove(listInformation.SelectedItems[0]);

            }
            catch
            {

            }
        }

        public void SaveChange()
        {
            if (CheckInput() == true)
            {
                contact[listInformation.SelectedItems[0].Index].Name = txtName.Text.Trim();
                contact[listInformation.SelectedItems[0].Index].StreetAddress = txtStreetAddress.Text.Trim();
                contact[listInformation.SelectedItems[0].Index].Zip = txtZip.Text.Trim();
                contact[listInformation.SelectedItems[0].Index].City = txtCity.Text.Trim();
                contact[listInformation.SelectedItems[0].Index].Email = txtEmail.Text.Trim();
                contact[listInformation.SelectedItems[0].Index].PhoneNumber = txtPhoneNumber.Text.Trim();
                listInformation.SelectedItems[0].Text = string.Format("{0} {1} {2} {3} {4} {5}", txtName.Text, txtStreetAddress.Text, txtZip.Text, txtCity.Text, txtEmail.Text, txtEmail.Text);
            }
            else
            {
                MessageBox.Show("All text boxes must be filled out!");
            }
        }

        public void Search()
        {
            var searchText = txtSearch.Text.Trim().ToLower();
            lbSearch.Items.Clear();

            foreach (var c in contact)
            {
                var text = string.Format("{0} {1} {2} {3} {4} {5}", c.Name, c.StreetAddress, c.Zip, c.City, c.Email, c.PhoneNumber).ToLower();
                var i = text.IndexOf(searchText);
                if (i != -1)
                {
                    lbSearch.Items.Add(string.Format("{0} {1} {2} {3} {4} {5}", c.Name, c.StreetAddress, c.Zip, c.City, c.Email, c.PhoneNumber));
                }
                i = -1;
            }
        }

        public bool CheckInput()
        {
            if (txtName.Text == "" || txtStreetAddress.Text == "" || txtZip.Text == "" || txtCity.Text == "" || txtEmail.Text == "" || txtPhoneNumber.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
