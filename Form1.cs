using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DatabaseModelCreator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            HideItems();          
        }

        #region FormControls

        /// <summary>
        /// Fetch Tables button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connString = txtConnString.Text;
                (bool success, string errorMessage) = ValidationHelper.ValidateConnString(connString);

                if (!success)
                {
                    MessageBox.Show(errorMessage);
                    return;
                }

                // Fetch all tables
                List<string> tables = DatabaseHelper.FetchTables(connString);

                // Fetch all views
                List<string> views = DatabaseHelper.FetchViews(connString);

                if (tables.IsEmpty() && views.IsEmpty())
                {
                    MessageBox.Show("No table or view exist in the database. Please try with different database");
                    return;
                }

                BindTablesAndViewToGenerate(tables, views);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        /// <summary>
        /// Generate model button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string outDir = txtoutDir.Text;

                // Check if output directory is empty
                if (string.IsNullOrWhiteSpace(outDir))
                {
                    MessageBox.Show("Please enter the output directory");
                    return;
                }

                // Check if output directory is valid
                if (!Directory.Exists(outDir))
                {
                    MessageBox.Show("Directory does not exist. Please enter the correct directory");
                    return;
                }

                // If no table or view is selected
                if (TablesList.CheckedIndices.Count == 0 && ViewsList.CheckedIndices.Count == 0)
                {
                    MessageBox.Show("Please select some tables or views first before proceeding");
                    return;
                }

                // Generate the model of selected tables
                GenerateModelsFromTables(outDir, txtConnString.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        /// <summary>
        /// Reset the current connection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearItems();
            HideItems();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Bind the table to the checkboxes
        /// </summary>
        /// <param name="tables"></param>
        private void BindTablesAndViewToGenerate(List<string> tables, List<string> views)
        {
            // Flush previous items
            ClearItems();
            ShowItems();

            // Bind Tables and Views
            TablesList.Items.AddRange(tables.ToArray());
            ViewsList.Items.AddRange(views.ToArray());
        }

        /// <summary>
        /// Hide items on page load
        /// </summary>
        private void HideItems(bool show = false)
        {
            // Enable the connection string textbox
            txtConnString.Enabled = true;

            //Hide labels
            lblTables.Hide();
            lblViews.Hide();
            lbloutDir.Hide();

            //Hide Textboxes and list
            TablesList.Hide();
            ViewsList.Hide();
            txtoutDir.Hide();

            //Hide buttons
            btnGenerate.Hide();
            btnReset.Hide();
        }

        /// <summary>
        /// Show items on page load
        /// </summary>
        private void ShowItems(bool show = false)
        {
            // Disable the connection string textbox
            txtConnString.Enabled = false;

            //Hide labels
            lblTables.Show();
            lblViews.Show();
            lbloutDir.Show();

            //Hide Textboxes and list
            TablesList.Show();
            ViewsList.Show();
            txtoutDir.Show();

            //Show buttons
            btnGenerate.Show();
            btnReset.Show();
        }

        /// <summary>
        /// Flushes the lists
        /// </summary>
        private void ClearItems()
        {
            // Clear the output directory textbox
            txtoutDir.Text = string.Empty;

            // Clear the tables and views list
            TablesList.Items.Clear();
            ViewsList.Items.Clear();
        }

        /// <summary>
        /// Generate the models
        /// </summary>
        private void GenerateModelsFromTables(string outDir, string connString)
        {
            // Gets the checked tables
            List<string> checkedTablesOrView = GetCheckedTablesOrViews();

            foreach (var tableOrView in checkedTablesOrView)
            {
                string modelString = DatabaseHelper.GetModelStringFromDatabase(connString, tableOrView);

                // Save the model string to output directory as .cs file
                File.WriteAllText(outDir + @"\" + tableOrView + ".cs", FormatHelper.FormatModelIntoClass(modelString));
            }

            MessageBox.Show($"{checkedTablesOrView.Count} Models generated successfully at path {outDir}");
            HideItems();
        }

        /// <summary>
        /// Returns the list of selected tables
        /// </summary>
        /// <returns></returns>
        private List<string> GetCheckedTablesOrViews()
        {
            List<string> checkdTablesOrViews = new List<string>();

            // Checked tables
            foreach (var item in TablesList.CheckedItems)
            {
                checkdTablesOrViews.Add(item.ToString());
            }

            // Checked views
            foreach (var item in ViewsList.CheckedItems)
            {
                checkdTablesOrViews.Add(item.ToString());
            }

            return checkdTablesOrViews;
        }

        #endregion
    }
}
