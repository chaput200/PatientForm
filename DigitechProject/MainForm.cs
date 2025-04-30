using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;



namespace DigitechProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadPatients(); // Loads the data when the form opens

            dataGridViewPatients.CellDoubleClick += (s, e) => OpenSelectedPatientForEdit();
            btnNew.Click += btnNew_Click;
            btnEdit.Click += btnEdit_Click;

        }

        //OPEN PATIENT FOR EDIT METHOD
        private void OpenSelectedPatientForEdit()
        {
            if (dataGridViewPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to edit.");
                return;
            }

            var row = dataGridViewPatients.SelectedRows[0];
            var patientKey = (Guid)row.Cells["PatientKEY"].Value;

            Patient patient = DatabaseHelper.GetPatientByKey(patientKey);

            if (patient == null)
            {
                MessageBox.Show("Could not load the selected patient.");
                return;
            }

            var form = new PatientForm(patient);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadPatients(); // Refresh grid after editing
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            OpenSelectedPatientForEdit();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var form = new PatientForm(); // Open empty form
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadPatients(); // Refresh the grid
            }

        }

        //LOAD PATIENT DATA
        private void LoadPatients()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["PatientDB"].ConnectionString;

            using (var conn = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=DigitechTestDB;Integrated Security=True;"))
            {
                string query = "SELECT * FROM Patients";

                var adapter = new SqlDataAdapter(query, conn);
                var table = new DataTable();
                adapter.Fill(table);

                dataGridViewPatients.DataSource = table;
                dataGridViewPatients.Columns["PatientKEY"].Visible = false; // hide internal ID
            }
        }

    }
}
