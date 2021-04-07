using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NadasyB_AdatbazisTabla
{
    public partial class Form1 : Form
    {

        private List<Auto> autokLista;
        DataTable raktarTable;
        public Form1()
        {
            InitializeComponent();
            ini();

        }

        private void ini()
        {
            autokLista = new List<Auto>();
            autokLista.Add(new Auto("Pál", "BMW", "zöld"));
            autokLista.Add(new Auto("Petra", "Opel", "kék"));
            autokLista.Add(new Auto("Gábor", "Toyota", "fehér"));
            autokLista.Add(new Auto("Péter", "BMW", "ezüst"));

            raktarTable = new DataTable();
            tablaKeszit();
            tablaTolt();

            //megjelenít
            dataGridView1.DataSource = raktarTable;
        }

        private void tablaTolt()
        {
            foreach (Auto auto in autokLista)
            {
                DataRow dr = raktarTable.NewRow();
                dr["Gyártó"] = auto.Gyarto;
                dr["Szín"] = auto.Szin;
                dr["Név"] = auto.Nev;
                
                raktarTable.Rows.Add(dr);
            }
        }

        private void tablaKeszit()
        {
            DataColumn autoldColumn = new DataColumn("Autó ID", typeof(int));
            autoldColumn.Caption = "Autó ID";
            autoldColumn.ReadOnly = true;
            autoldColumn.AllowDBNull = false;
            autoldColumn.Unique = true;
            autoldColumn.AutoIncrement = true;
            autoldColumn.AutoIncrementSeed = 1;
            autoldColumn.AutoIncrementStep = 1;

            DataColumn gyartoColumn = new DataColumn("Gyártó", typeof(string));
            DataColumn szinColumn = new DataColumn("Szín", typeof(string));
            DataColumn nevColumn = new DataColumn("Név", typeof(string));
            //autoNevColumn.Caption

            raktarTable.Columns.AddRange(new DataColumn[] {
                autoldColumn,
                gyartoColumn,
                szinColumn,
                nevColumn
            });
        }

        private void btnTorol_Click(object sender, EventArgs e)
        {
            try
            {
                raktarTable.Rows[int.Parse(txtTorol.Text)-1].Delete();
                raktarTable.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ini();
        }
    }
}
