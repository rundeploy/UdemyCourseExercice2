using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Training course udemy https://www.udemy.com/share/100K1SAEUbeVdbRHo=/
/// Cristian Mitul aka rundeploy
/// 20/12/2018
/// </summary>

namespace Udemy2
{
    public partial class frmTitles : Form
    {

        OleDbConnection conn;
        OleDbCommand titlesCommand;
        OleDbDataAdapter titlesAdapter;
        DataTable titlesTable;

        public frmTitles()
        {
            InitializeComponent();
        }

        private void frmTitles_Load(object sender, EventArgs e)
        {
            var connString = @"Provider=Microsoft.ACE.OLEDB.12.0;
                Data Source=D:\PROJETOS\UdemyCourse (Alex)\UdemyBooksDB\Books.accdb;
                Persist Security Info = False; ";

            conn = new OleDbConnection(connString);
            conn.Open();

            titlesCommand = new OleDbCommand("Select *  from Titles", conn);
            titlesAdapter = new OleDbDataAdapter();
            titlesAdapter.SelectCommand = titlesCommand;
            titlesTable = new DataTable();
            titlesAdapter.Fill(titlesTable);

            conn.Close();
            conn.Dispose();
            titlesAdapter.Dispose();
            titlesTable.Dispose();

        }
    }
}
