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

        List<Address> contactInformation = new List<Address>();
        List<Address> tempSearchList = new List<Address>();
        bool recentlySearched = false;


        private void Form1_Load(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader("address book2.txt"))
            {
                string[] person = new string[7];
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    person = line.Split(',');
                    Address getInfo = new Address(person[0], person[1], person[2], person[3], person[4], person[5], Guid.Parse(person[6]));
                    listViewInformation.Items.Add(person[0]);
                    contactInformation.Add(getInfo);
                }
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveToFile();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveChange();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            Search();
            recentlySearched = true;
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
            ClearTxtBoxes();
        }

        private void cmdShowAll_Click(object sender, EventArgs e)
        {
            listViewInformation.Clear();
            foreach (var contact in contactInformation)
            {
                listViewInformation.Items.Add(contact.Name);
            }
            recentlySearched = false;
        }

        private void listInformation_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                if (listViewInformation.SelectedItems.Count == 0)
                {
                    return;
                }
                else if (recentlySearched == false)
                {
                    txtName.Text = contactInformation[listViewInformation.SelectedItems[0].Index].Name;
                    txtStreetAddress.Text = contactInformation[listViewInformation.SelectedItems[0].Index].StreetAddress;
                    txtZip.Text = contactInformation[listViewInformation.SelectedItems[0].Index].Zip;
                    txtCity.Text = contactInformation[listViewInformation.SelectedItems[0].Index].City;
                    txtEmail.Text = contactInformation[listViewInformation.SelectedItems[0].Index].Email;
                    txtPhoneNumber.Text = contactInformation[listViewInformation.SelectedItems[0].Index].PhoneNumber;
                }
                else if (recentlySearched == true)
                {
                    txtName.Text = tempSearchList[listViewInformation.SelectedItems[0].Index].Name;
                    txtStreetAddress.Text = tempSearchList[listViewInformation.SelectedItems[0].Index].StreetAddress;
                    txtZip.Text = tempSearchList[listViewInformation.SelectedItems[0].Index].Zip;
                    txtCity.Text = tempSearchList[listViewInformation.SelectedItems[0].Index].City;
                    txtEmail.Text = tempSearchList[listViewInformation.SelectedItems[0].Index].Email;
                    txtPhoneNumber.Text = tempSearchList[listViewInformation.SelectedItems[0].Index].PhoneNumber;
                }
            }
            catch (Exception)
            {

            }

        }

        public void AddContact()
        {
            if (CheckAllTextBoxesInput() == true)
            {
                Guid guid = Guid.NewGuid();
                Address person = new Address(txtName.Text.Trim(), txtStreetAddress.Text.Trim(), txtZip.Text.Trim(), txtCity.Text.Trim(), txtEmail.Text.Trim(), txtPhoneNumber.Text.Trim(), guid);
                contactInformation.Add(person);
                listViewInformation.Items.Add(person.Name);
                ClearTxtBoxes();
            }
            else
            {
                MessageBox.Show("All text boxes must be filled out!");
            }
        }

        public void SaveChange()
        {
            try
            {
                if (CheckAllTextBoxesInput() == true)
                {

                    if (recentlySearched == false)
                    {
                        contactInformation[listViewInformation.SelectedItems[0].Index].Name = txtName.Text.Trim();
                        contactInformation[listViewInformation.SelectedItems[0].Index].StreetAddress = txtStreetAddress.Text.Trim();
                        contactInformation[listViewInformation.SelectedItems[0].Index].Zip = txtZip.Text.Trim();
                        contactInformation[listViewInformation.SelectedItems[0].Index].City = txtCity.Text.Trim();
                        contactInformation[listViewInformation.SelectedItems[0].Index].Email = txtEmail.Text.Trim();
                        contactInformation[listViewInformation.SelectedItems[0].Index].PhoneNumber = txtPhoneNumber.Text.Trim();
                        listViewInformation.SelectedItems[0].Text = (txtName.Text);
                    }
                    else if (recentlySearched == true)
                    {
                        listViewInformation.SelectedItems[0].Text = (txtName.Text);
                        SetTempListProp();
                        SyncListSave();
                    }
                }
                SaveToFile();

            }
            catch (Exception)
            {

            }
        }

        public void Delete()
        {
            ClearTxtBoxes();
            if (recentlySearched == false)
            {
                contactInformation.RemoveAt(listViewInformation.SelectedItems[0].Index);
                listViewInformation.Items.Remove(listViewInformation.SelectedItems[0]);
            }
            else if (recentlySearched == true)
            {
                SyncListDelete();
            }
        }

        public void Search()
        {
            var searchText = txtSearch.Text.Trim().ToLower();
            listViewInformation.Items.Clear();
            tempSearchList.Clear();
            ClearTxtBoxes();

            foreach (var c in contactInformation)
            {
                var text = string.Format("{0} {1} {2} {3} {4} {5}", c.Name, c.StreetAddress, c.Zip, c.City, c.Email, c.PhoneNumber).ToLower();
                var i = text.IndexOf(searchText);

                if (i != -1)
                {
                    listViewInformation.Items.Add(c.Name);
                    Address tempPerson = new Address(c.Name, c.StreetAddress, c.Zip, c.City, c.Email, c.PhoneNumber, c.Id);
                    tempSearchList.Add(tempPerson);
                }
            }
        }

        public bool CheckAllTextBoxesInput()
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

        public void SyncListSave()
        {
            for (int i = 0; i < contactInformation.Count; i++)
            {
                for (int t = 0; t < tempSearchList.Count; t++)
                {
                    if (contactInformation[i].Id == tempSearchList[t].Id)
                    {
                        contactInformation[i] = tempSearchList[t];
                    }
                }
            }
        }

        public void SyncListDelete()
        {
            var removeItem = listViewInformation.SelectedItems[0].Index;

            for (int i = 0; i < contactInformation.Count; i++)
            {

                if (contactInformation[i].Id == tempSearchList[removeItem].Id)
                {
                    contactInformation.RemoveAt(i);
                    listViewInformation.Items.RemoveAt(removeItem);
                }
            }
            SaveToFile();
        }

        public void ClearTxtBoxes()
        {
            txtName.Clear();
            txtStreetAddress.Clear();
            txtZip.Clear();
            txtCity.Clear();
            txtEmail.Clear();
            txtPhoneNumber.Clear();
        }

        public void SetTempListProp()
        {
            tempSearchList[listViewInformation.SelectedItems[0].Index].Name = txtName.Text.Trim();
            tempSearchList[listViewInformation.SelectedItems[0].Index].StreetAddress = txtStreetAddress.Text.Trim();
            tempSearchList[listViewInformation.SelectedItems[0].Index].Zip = txtZip.Text.Trim();
            tempSearchList[listViewInformation.SelectedItems[0].Index].City = txtCity.Text.Trim();
            tempSearchList[listViewInformation.SelectedItems[0].Index].Email = txtEmail.Text.Trim();
            tempSearchList[listViewInformation.SelectedItems[0].Index].PhoneNumber = txtPhoneNumber.Text.Trim();
        }

        public void SaveToFile()
        {
            using (StreamWriter sr = new StreamWriter("address book2.txt"))
            {
                foreach (var c in contactInformation)
                {
                    sr.WriteLine(string.Format("{0},{1},{2},{3},{4},{5},{6}", c.Name, c.StreetAddress, c.Zip, c.City, c.Email, c.PhoneNumber, c.Id));
                }
            }
        }
    }
}
