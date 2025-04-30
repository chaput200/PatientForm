using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitechProject
{
    public partial class PatientForm : Form
    {
        //ASSUME NEW BY DEFAULT
        private bool isEditMode = false; 
        //INIT PATIENT TO NEW EMPTY OBJ
        private Patient currentPatient = null;

        private void PatientForm_Load(object sender, EventArgs e)
        {
            InitializeStateDropdown();

            if (isEditMode && currentPatient != null)
            {
                LoadPatientData();
            }
        }

        //CONSTRUTOR FOR CREATING NEW PATIENT 
        public PatientForm()
        {
            InitializeComponent();
            //InitializeStateDropdown();
            this.Load += PatientForm_Load;

        }

        //CONSTRUTOR FOR EDITING EXISTING PATIENT
        public PatientForm(Patient patient)
        {
            InitializeComponent();
            isEditMode = true;
            currentPatient = patient; 
            this.Load += PatientForm_Load;


            //INIT DROP DOWN MENU
            //InitializeStateDropdown();
            //THIS FILLW IN TXT BOXES W PATIENT'S DATA ENTERED
            //LoadPatientData(); 
        }

        private void LoadPatientData()
        {
            txtFirstName.Text = currentPatient.FirstName;
            txtLastName.Text = currentPatient.LastName;
            txtMiddleInitial.Text = currentPatient.MiddleInitial;
            txtADDR1.Text = currentPatient.Address1;
            txtADDR2.Text = currentPatient.Address2;
            txtCity.Text = currentPatient.City;
            comboState.SelectedItem = currentPatient.State;
            txtZip.Text = currentPatient.ZipCode;
            txtHomePhone.Text = currentPatient.HomePhone;
            txtBusinessPhone.Text = currentPatient.BusineesPhone;
            txtCellPhone.Text = currentPatient.CellPhone;
            txtEmail.Text = currentPatient.EmailAddress;
        }


        private void InitializeStateDropdown()
        {
            // LIST EACH STATE ABREV. FOR THE DROP DOWN MENU FOR STATE SELECTION
            comboState.Items.AddRange(new string[]
            {
                "AL","AK","AZ","AR","CA","CO","CT","DE","FL","GA",
                "HI","ID","IL","IN","IA","KS","KY","LA","ME","MD",
                "MA","MI","MN","MS","MO","MT","NE","NV","NH","NJ",
                "NM","NY","NC","ND","OH","OK","OR","PA","RI","SC",
                "SD","TN","TX","UT","VT","VA","WA","WV","WI","WY"
            });
            //MAKE COMBO BOX INTO A DROP DOWN STYLE MENU
            comboState.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        //CHECK EMAIL IS VALID
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // METHOD FOR SUBMIT BUTTON
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            // VALIDATE FIELDS
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txtMiddleInitial.Text))
            {
                MessageBox.Show("Middle Initial is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMiddleInitial.Focus();
                return;
            }

            if (txtMiddleInitial.Text.Length > 1)
            {
                MessageBox.Show("Middle Initial must be a single character.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMiddleInitial.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Last Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtADDR1.Text))
            {
                MessageBox.Show("Address Line 1 is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtADDR1.Focus();
                return;
            }



            if (string.IsNullOrWhiteSpace(txtCity.Text))
            {
                MessageBox.Show("City is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCity.Focus();
                return;
            }

            if (comboState.SelectedItem == null)
            {
                MessageBox.Show("Please select a state.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboState.Focus();
                return;
            }

            //CHECK EMAIL IS VALID
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            //ZIP CODE LENGTH CHECK
            if (txtZip.Text.Length < 5 || txtZip.Text.Length > 10)
            {
                MessageBox.Show("ZIP Code must be between 5 and 10 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtZip.Focus();
                return;
            }

            //ADDRESS 2 IS OPTIONAL NULL
            

            //CREATE PATIENT OBJ
            Patient patient = new Patient
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                MiddleInitial = txtMiddleInitial.Text,
                Address1 = txtADDR1.Text,
                Address2 = string.IsNullOrWhiteSpace(txtADDR2.Text) ? null : txtADDR2.Text, // Optional
                City = txtCity.Text,
                State = comboState.SelectedItem?.ToString(),
                ZipCode = txtZip.Text,
                HomePhone = txtHomePhone.Text,
                BusineesPhone = txtBusinessPhone.Text,
                CellPhone = txtCellPhone.Text,
                EmailAddress = txtEmail.Text
            };

            //SAVE TO DATABASE
            try
            {
                // IF EDIT MODE...
                if (isEditMode)
                {
                    patient.PatientKEY = currentPatient.PatientKEY;
                    DatabaseHelper.UpdatePatient(patient);
                }
                else
                {
                    DatabaseHelper.CreatePatient(patient);
                }

                MessageBox.Show("Patient record saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving patient: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFN(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
