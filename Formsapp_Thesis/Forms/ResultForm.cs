using DynamicAssignment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formsapp_Thesis
{
    public partial class ResultForm : Form
    {
        ResultPanel rp;
        BlockingPairsPanel bp;
        public ResultForm()
        {
            InitializeComponent();
            rp = new ResultPanel();
            panel1.Controls.Add(rp);
            statusLabel.Text = AssignmentPackage.AssignmentResult.Result;
            objectiveSumLabel.Text = AssignmentPackage.AssignmentResult.ObjectiveSum.ToString();
            blockingPairsLabel.Text = AssignmentPackage.AssignmentResult.BlockingPairs.Count.ToString();
            wallTimeLabel.Text = AssignmentPackage.AssignmentResult.wallTime.ToString();

            pairsRadio.CheckedChanged += GroupBox1_Checkchange;
            blockingPairsRadio.CheckedChanged += GroupBox1_Checkchange;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(AssignmentPackage.AssignmentResult.LpFile);
        }


        private void GroupBox1_Checkchange(object? sender, EventArgs e)
        {
            panel1.Controls.Clear();
            if (sender == pairsRadio)
            {
                rp = new ResultPanel();
                panel1.Controls.Add(rp);
            }

            else if (sender == blockingPairsRadio)
            {
                bp = new BlockingPairsPanel();
                panel1.Controls.Add(bp);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rp != null)
            {
                exportCSV(rp.dataGridView);
            }
            else if (bp != null)
            {
                exportCSV(bp.dataGridView);
            }

        }

        private void exportCSV(DataGridView dgw)
        {
            if (dgw.Rows.Count > 0)
            {

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "Output.csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Nem sikerült a lemezre való írás." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = dgw.Columns.Count;
                            string columnNames = "";
                            string[] outputCsv = new string[dgw.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += dgw.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; (i - 1) < dgw.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCsv[i] += dgw.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                }
                            }

                            File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                            MessageBox.Show("Fájl mentése sikerült", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("HIBA :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Nincsen adat, amit exportálni lehetne", "Info");
            }
        }
    }
}
