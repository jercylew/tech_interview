using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileDistance
{
    public partial class MainWindow : Form
    {
        private string m_strSourceFile;
        private string m_strTargetFile;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void m_btnChooseSourceFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            m_strSourceFile = "";

            if (openFileDialog.ShowDialog() == DialogResult.OK )
            {
                m_strSourceFile = openFileDialog.FileName;
                m_txtSourceFile.Text = m_strSourceFile;
            }
        }

        private void m_btnChooseTargetFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            m_strTargetFile = "";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                m_strTargetFile = openFileDialog.FileName;
                m_txtTargetFile.Text = m_strTargetFile;
            }
        }

        private void m_btnCompare_Click(object sender, EventArgs e)
        {
            m_richTxtCompareResult.Text = string.Format("Difference Source: {0} Target: {1}\n", 
                m_strSourceFile, m_strTargetFile);

            //m_richTxtCompareResult.Font = new Font("Consolas", 18f, FontStyle.Bold);
            m_richTxtCompareResult.BackColor = Color.AliceBlue;

            //Read text fie
            int counter = 0;
            int nDistance;
            string lineSrc;
            string lineTarget;

            // Read the file and display it line by line.  
            System.IO.StreamReader fileSrc =
                new System.IO.StreamReader(m_strSourceFile);
            System.IO.StreamReader fileTarget =
                new System.IO.StreamReader(m_strTargetFile);
            while ((lineSrc = fileSrc.ReadLine()) != null &&
                (lineTarget = fileTarget.ReadLine()) != null)
            {
                lineSrc = lineSrc.Trim();
                lineTarget = lineTarget.Trim();

                nDistance = LevenshteinDistance(lineSrc, lineTarget);
                if (nDistance != 0)
                {
                    m_richTxtCompareResult.SelectionBackColor = Color.Plum;
                    m_richTxtCompareResult.AppendText("-" + lineSrc);
                    m_richTxtCompareResult.SelectionBackColor = Color.AliceBlue;
                    m_richTxtCompareResult.AppendText("\n");

                    m_richTxtCompareResult.SelectionBackColor = Color.Aquamarine;
                    m_richTxtCompareResult.AppendText("+" + lineTarget);
                    m_richTxtCompareResult.SelectionBackColor = Color.AliceBlue;
                    m_richTxtCompareResult.AppendText("\n");
                }
                else
                {
                    m_richTxtCompareResult.SelectionBackColor = Color.AliceBlue;
                    m_richTxtCompareResult.AppendText(lineSrc);
                    m_richTxtCompareResult.SelectionBackColor = Color.AliceBlue;
                    m_richTxtCompareResult.AppendText("\n");
                }
                counter++;
            }

            //Remaining lines
            while((lineSrc = fileSrc.ReadLine()) != null)
            {
                m_richTxtCompareResult.SelectionBackColor = Color.Plum;
                m_richTxtCompareResult.AppendText("-" + lineSrc);
                m_richTxtCompareResult.SelectionBackColor = Color.AliceBlue;
                m_richTxtCompareResult.AppendText("\n");
            }

            while ((lineTarget = fileTarget.ReadLine()) != null)
            {
                m_richTxtCompareResult.SelectionBackColor = Color.Aquamarine;
                m_richTxtCompareResult.AppendText("+" + lineTarget);
                m_richTxtCompareResult.SelectionBackColor = Color.AliceBlue;
                m_richTxtCompareResult.AppendText("\n");
            }

            fileSrc.Close();
            fileTarget.Close();
        }

        // Calculate Levenshtein Distance 
        // https://people.cs.pitt.edu/~kirk/cs1501/Pruhs/Spring2006/assignments/editdistance/Levenshtein%20Distance.htm
        private int LevenshteinDistance(string s, string t)
        {
            int m = s.Length;
            int n = t.Length;

            if (m == 0)
            {
                return n;
            }

            if (n == 0)
            {
                return m;
            }

            int cost;

            int[,] d = new int[m, n];
            
            for (int i = 0;i < m;i++)
            {
                d[i, 0] = i;
            }

            for (int j = 1; j < n; j++)
            {
                d[0, j] = j;
            }

            for (int i = 1; i < m;i++)
            {
                for (int j = 1; j < n;j++)
                {
                    cost = (s[i] == t[j]) ? 0 : 1;

                    //d[i - 1, j] + 1,     // deletion
                    //d[i, j - 1] + 1,     // insertion
                    //d[i - 1, j - 1] + cost   // substitution
                    d[i, j] = Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1);
                    d[i, j] = Math.Min(d[i, j], d[i - 1, j - 1] + cost);
                }
            }
            // Console.Write(string.Format("Distace: %d, %d deletions, %d insertions and %d substitution"));
            return d[m-1, n-1];
        }
    }
}
