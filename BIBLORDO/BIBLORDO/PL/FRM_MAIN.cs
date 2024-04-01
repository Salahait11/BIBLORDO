using System;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BIBLORDO.PL
{
    public partial class FRM_MAIN : Form
    {
        String State;
        int ID;
        BL.CLS_CAT BLCAT = new BL.CLS_CAT();
        BL.CLS_BOOKS BLBOOKS = new BL.CLS_BOOKS();
        BL.CLS_ST BLST = new BL.CLS_ST();
        BL.CLS_SELL BLSELL = new BL.CLS_SELL();
        BL.CLS_EMP BLEMP = new BL.CLS_EMP();
        BL.CLS_USERS BLUSER = new BL.CLS_USERS();
        public FRM_MAIN()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            if (P_MB.Size.Width == 227)
            {
                P_MB.Width = 50;
                lbname.Visible = false;
                lbprem.Visible = false;
                button1.Visible = false;
                button2.Visible = true;
                btnbooks.Visible = false;
                btnbooks2.Visible = true;
                button5.Visible = false;
                button6.Visible = true;
                button7.Visible = false;
                button8.Visible = true;
                button9.Visible = false;
                button10.Visible = true;
                button1.Visible = false;
                button12.Visible = true;
                btncat.Visible = false;
                btncat2.Visible = true;
                pictureBox1.Visible = false;
            }
            else
            {
                P_MB.Width = 227;
                lbname.Visible = true;
                lbprem.Visible = true;
                button1.Visible = true;
                button2.Visible = false;
                btnbooks.Visible = true;
                btnbooks2.Visible = false;
                button5.Visible = true;
                button6.Visible = false;
                button7.Visible = true;
                button8.Visible = false;
                button9.Visible = true;
                button10.Visible = false;
                button11.Visible = true;
                button12.Visible = false;
                btncat.Visible = true;
                btncat2.Visible = false;
                pictureBox1.Visible = true;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            P_HOME.Visible = false;
            P_MAIN.Visible = true;
            txt_search.Visible = true;
            State = "CAT";
            lb_title.Text = "CATÉGORIE";
            try
            {
                DataTable dt = new DataTable();
                dt = BLCAT.LOAD();
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "Séquence";
                dataGridView1.Columns[1].HeaderText = "Nom du Catégorie";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            P_HOME.Visible = false;
            P_MAIN.Visible = true;
            txt_search.Visible = true;
            State = "CAT";
            lb_title.Text = "CATÉGORIE";
            try
            {
                DataTable dt = new DataTable();
                dt = BLCAT.LOAD();
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "Séquence";
                dataGridView1.Columns[1].HeaderText = "Nom du Catégorie";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FRM_MAIN_Load(object sender, EventArgs e)
        {
            P_HOME.Visible = true;
            P_MAIN.Visible = false;
            lb_title.Text = "BIBLORDO";

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            //ajoute categorie
            if (State == "CAT")
            {
                PL.FRM_ADDCAT FCAT = new FRM_ADDCAT();
                FCAT.btnadd.ButtonText = "AJOUTER";
                FCAT.ID = 0;
                bunifuTransition1.ShowSync(FCAT);

            }
            //ajoute livre
            else if (State == "BOOKS")
            {
                PL.FRM_ADDBOOKS FBOOKS = new FRM_ADDBOOKS();
                FBOOKS.btnadd.ButtonText = "AJOUTER";
                FBOOKS.ID = 0;
                bunifuTransition1.ShowSync(FBOOKS);

            }
            else if (State == "ST")
            {
                //ajoute etudiant
                PL.FRM_ADDSTUDENTS FST = new FRM_ADDSTUDENTS();
                FST.btnadd.ButtonText = "AJOUTER";
                FST.ID = 0;
                bunifuTransition1.ShowSync(FST);

            }
            else if (State == "SELL")
            {
                //ajoute VENTE
                PL.FRM_ADDSELL FSELL = new FRM_ADDSELL();
                FSELL.btnadd.ButtonText = "AJOUTER";
                FSELL.ID = 0;
                bunifuTransition1.ShowSync(FSELL);

            }
            else if (State == "EMP")
            {
                //ajoute EMPRUNT
                PL.FRM_ADDSEMP FEMP = new FRM_ADDSEMP();
                FEMP.btnadd.ButtonText = "AJOUTER";
                FEMP.ID = 0;
                bunifuTransition1.ShowSync(FEMP);

            }
            else if (State == "USER")
            {
                //ajoute user
                PL.FRM_ADDUSER FUSER = new FRM_ADDUSER();
                FUSER.btnadd.ButtonText = "AJOUTER";
                FUSER.ID = 0;
                bunifuTransition1.ShowSync(FUSER);

            }
        }

        private void FRM_MAIN_Activated(object sender, EventArgs e)
        {
            //CHECK NUMBER
            //BOOK
            try
            {
                DataTable dt = new DataTable();
                dt = BLBOOKS.LOAD();
                lbnbook.Text=dt.Rows.Count.ToString();
            }
            catch {}
            //STUDANT
            try
            {
                DataTable dt = new DataTable();
                dt = BLST.LOAD();
                lbst.Text = dt.Rows.Count.ToString();
            }
            catch { }
            //VENTES
            try
            {
                DataTable dt = new DataTable();
                dt = BLSELL.LOAD();
                lbvente.Text = dt.Rows.Count.ToString();
            }
            catch { }
            //EMPRUNT
            try
            {
                DataTable dt = new DataTable();
                dt = BLEMP.LOAD();
                lbemp.Text = dt.Rows.Count.ToString();
            }
            catch { }
            //CAT
            try
            {
                DataTable dt = new DataTable();
                dt = BLCAT.LOAD();
                lbcat.Text = dt.Rows.Count.ToString();
            }
            catch { }
            //USER
            try
            {
                DataTable dt = new DataTable();
                dt = BLUSER.LOAD();
                lbuser.Text = dt.Rows.Count.ToString();
            }
            catch { }
            if (lbprem.Text == "ADMINISTRATEUR")
            {
                bunifuThinButton23.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
            }
            else
            {
                bunifuThinButton23.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
            }
        

            if (State == "CAT")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = BLCAT.LOAD();
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].HeaderText = "Séquence";
                    dataGridView1.Columns[1].HeaderText = "Nom du Catégorie";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (State == "BOOKS")
            {
                P_HOME.Visible = false;
                P_MAIN.Visible = true;
                State = "BOOKS";
                lb_title.Text = "LIVRES";
                try
                {
                    DataTable dt = new DataTable();
                    dt = BLBOOKS.LOAD();
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].HeaderText = "Séquence";
                    dataGridView1.Columns[1].HeaderText = "Nom du Livre";
                    dataGridView1.Columns[2].HeaderText = "AUTEUR";
                    dataGridView1.Columns[3].HeaderText = "CATÉGORIE";
                    dataGridView1.Columns[4].HeaderText = "PRIX";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (State == "ST")
            {
                P_HOME.Visible = false;
                P_MAIN.Visible = true;
                State = "ST";
                lb_title.Text = "ÉTUDIANTS";
                try
                {
                    DataTable dt = new DataTable();
                    dt = BLST.LOAD();
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].HeaderText = "Séquence";
                    dataGridView1.Columns[1].HeaderText = "NOM DE L'ÉTUDIANT";
                    dataGridView1.Columns[2].HeaderText = "ADRESSE";
                    dataGridView1.Columns[3].HeaderText = "NUMÉRO DE TÉLÉPHONE";
                    dataGridView1.Columns[4].HeaderText = "EMAIL";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else if (State == "SELL")
            {
                P_HOME.Visible = false;
                P_MAIN.Visible = true;
                State = "SELL";
                lb_title.Text = "VENTES";
                try
                {
                    DataTable dt = new DataTable();
                    dt = BLSELL.LOAD();
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].HeaderText = "Séquence";
                    dataGridView1.Columns[1].HeaderText = "Nom du Livre";
                    dataGridView1.Columns[2].HeaderText = "ACHETEUR";
                    dataGridView1.Columns[3].HeaderText = "PRIX";
                    dataGridView1.Columns[4].HeaderText = "DATE";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (State == "EMP")
            {
                P_HOME.Visible = false;
                P_MAIN.Visible = true;
                State = "EMP";
                lb_title.Text = "EMPRUNTS";
                try
                {
                    DataTable dt = new DataTable();
                    dt = BLEMP.LOAD();
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].HeaderText = "Séquence";
                    dataGridView1.Columns[1].HeaderText = "Nom d'Emprenteur";
                    dataGridView1.Columns[2].HeaderText = "Nom du Livre";
                    dataGridView1.Columns[3].HeaderText = "Début de l'Emprunt";
                    dataGridView1.Columns[4].HeaderText = "Fin de l'Emprunt";
                    dataGridView1.Columns[5].HeaderText = "PRIX";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (State == "USER")
            {
                P_HOME.Visible = false;
                P_MAIN.Visible = true;
                State = "USER";
                lb_title.Text = "UTILISATEURS";
                try
                {
                    DataTable dt = new DataTable();
                    dt = BLUSER.LOAD();
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].HeaderText = "Séquence";
                    dataGridView1.Columns[1].HeaderText = "Nom Complet";
                    dataGridView1.Columns[2].HeaderText = "Identifiant";
                    dataGridView1.Columns[3].HeaderText = "Mot De Passe";
                    dataGridView1.Columns[4].HeaderText = "Permission";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        } 
    

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            //MODIFIER categorie
            if (State == "CAT")
            {
                try
                {
                    PL.FRM_ADDCAT FCAT = new FRM_ADDCAT();
                    FCAT.btnadd.ButtonText = "MODIFIER";
                    FCAT.txt_catname.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                    FCAT.ID = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
                    bunifuTransition1.ShowSync(FCAT);
                }
                catch { }

            }
            //MODIFIER livres
            else if (State == "BOOKS")
            {
                try
                {
                    PL.FRM_ADDBOOKS FBOOKS = new FRM_ADDBOOKS();
                    FBOOKS.btnadd.ButtonText = "MODIFIER";
                    FBOOKS.ID = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
                    DataTable dt = new DataTable();
                    dt = BLBOOKS.LOADEDIT(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value));
                    object obj1 = dt.Rows[0]["TITLE"];
                    object obj2 = dt.Rows[0]["AUTEUR"];
                    object obj3 = dt.Rows[0]["CAT"];
                    object obj4 = dt.Rows[0]["PRICE"];
                    object obj5 = dt.Rows[0]["BDATE"];
                    object obj6 = dt.Rows[0]["RATE"];
                    object obj7 = dt.Rows[0]["COVER"];
                    FBOOKS.txt_title.Text = obj1.ToString();
                    FBOOKS.txt_auteur.Text = obj2.ToString();
                    FBOOKS.comboBox1.Text = obj3.ToString();
                    FBOOKS.txt_price.Text = obj4.ToString();
                    FBOOKS.txt_date.Value = (DateTime)obj5;
                    FBOOKS.txt_rate.Value = (int)obj6;
                    //load image
                    byte[] ob = (byte[])obj7;
                    MemoryStream ma = new MemoryStream(ob);
                    FBOOKS.cover.Image = Image.FromStream(ma);
                    bunifuTransition1.ShowSync(FBOOKS);
                }
                catch { }
            }
            else if (State == "ST")
            {
                try
                {
                    PL.FRM_ADDSTUDENTS FST = new FRM_ADDSTUDENTS();
                    FST.btnadd.ButtonText = "MODIFIER";
                    FST.ID = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
                    DataTable dt = new DataTable();
                    dt = BLST.LOADEDIT(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value));
                    object obj1 = dt.Rows[0]["NAME"];
                    object obj2 = dt.Rows[0]["ADRESSE"];
                    object obj3 = dt.Rows[0]["PHONE"];
                    object obj4 = dt.Rows[0]["EMAIL"];
                    object obj5 = dt.Rows[0]["SCHOOL"];
                    object obj6 = dt.Rows[0]["FILIERE"];
                    object obj7 = dt.Rows[0]["COVER"];
                    FST.txt_name.Text = obj1.ToString();
                    FST.txt_adresse.Text = obj2.ToString();
                    FST.txt_phone.Text = obj3.ToString();
                    FST.txt_email.Text = obj4.ToString();
                    FST.txt_school.Text = obj5.ToString();
                    FST.txt_filiere.Text = obj6.ToString();
                    //load image
                    byte[] ob = (byte[])obj7;
                    MemoryStream ma = new MemoryStream(ob);
                    FST.cover.Image = Image.FromStream(ma);
                    bunifuTransition1.ShowSync(FST);
                }
                catch { }
            }
            else if (State == "SELL")
            {
                try
                {
                    PL.FRM_ADDSELL FSELL = new FRM_ADDSELL();
                    FSELL.btnadd.ButtonText = "MODIFIER";
                    FSELL.ID = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
                    DataTable dt = new DataTable();
                    dt = BLSELL.LOADEDIT(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value));
                    object obj1 = dt.Rows[0]["PRICE"];
                    FSELL.txt_price.Text = obj1.ToString();
                    bunifuTransition1.ShowSync(FSELL);
                }
                catch { }
            }
            //ADD EMPRUNT
            else if (State == "EMP")
            {
                try
                {
                    PL.FRM_ADDSEMP FEMP = new FRM_ADDSEMP();
                    FEMP.btnadd.ButtonText = "MODIFIER";
                    FEMP.ID = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
                    DataTable dt = new DataTable();
                    dt = BLEMP.LOADEDIT(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value));
                    object obj1 = dt.Rows[0]["PRICE"];
                    FEMP.txt_price.Text = obj1.ToString();
                    bunifuTransition1.ShowSync(FEMP);
                }
                catch { }
            }
            //ADD USERS
            else if (State == "USER")
            {
                try
                {
                    PL.FRM_ADDUSER FUSER = new FRM_ADDUSER();
                    FUSER.btnadd.ButtonText = "MODIFIER";
                    FUSER.ID = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
                    DataTable dt = new DataTable();
                    dt = BLUSER.LOADEDIT(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value));
                    object obj1 = dt.Rows[0]["CNAME"];
                    object obj2 = dt.Rows[0]["CUSERNAME"];
                    object obj3 = dt.Rows[0]["CPASSWORD"];
                    object obj4 = dt.Rows[0]["CPREM"];
                    FUSER.txt_name.Text = obj1.ToString();
                    FUSER.txt_username.Text = obj2.ToString();
                    FUSER.txt_password.Text = obj3.ToString();
                    FUSER.txt_prem.Text = obj4.ToString();
                    bunifuTransition1.ShowSync(FUSER);
                }
                catch { }
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            //supprime categorie
            if (State == "CAT")
            {
                BLCAT.Delete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                PL.FRM_DDELETE FDELETE = new FRM_DDELETE();
                FDELETE.Show();
            }
            else if (State == "BOOKS")
            {
                //supprime LIVRES
                BLBOOKS.Delete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                PL.FRM_DDELETE FDELETE = new FRM_DDELETE();
                FDELETE.Show();
            }
            else if (State == "ST")
            {
                //supprime etudiant
                BLST.Delete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                PL.FRM_DDELETE FDELETE = new FRM_DDELETE();
                FDELETE.Show();
            }
            else if (State == "SELL")
            {
                //supprime vente
                BLSELL.Delete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                PL.FRM_DDELETE FDELETE = new FRM_DDELETE();
                FDELETE.Show();
            }
            else if (State == "EMP")
            {
                //supprime emprunte
                BLEMP.Delete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                PL.FRM_DDELETE FDELETE = new FRM_DDELETE();
                FDELETE.Show();
            }
            else if (State == "USER")
            {
                //supprime user
                BLUSER.Delete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                PL.FRM_DDELETE FDELETE = new FRM_DDELETE();
                FDELETE.Show();
            }
        }



        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            //search cat
            if (State == "CAT")
            {
                DataTable dt = new DataTable();
                dt = BLCAT.SEARCH(txt_search.Text);
                dataGridView1.DataSource = dt;
            }
            //search BOOK
            else if (State == "BOOKS")
            {
                DataTable dt = new DataTable();
                dt = BLBOOKS.SEARCH(txt_search.Text);
                dataGridView1.DataSource = dt;
            }
            //search student
            else if (State == "ST")
            {
                DataTable dt = new DataTable();
                dt = BLST.SEARCH(txt_search.Text);
                dataGridView1.DataSource = dt;
            }
            //search vente
            else if (State == "SELL")
            {
                DataTable dt = new DataTable();
                dt = BLSELL.SEARCH(txt_search.Text);
                dataGridView1.DataSource = dt;
            }
            //search EMPRUNTE
            else if (State == "EMP")
            {
                DataTable dt = new DataTable();
                dt = BLEMP.SEARCH(txt_search.Text);
                dataGridView1.DataSource = dt;
            }
           
        }

        private void btnbooks_Click(object sender, EventArgs e)
        {
            P_HOME.Visible = false;
            P_MAIN.Visible = true;
            txt_search.Visible = true;
            State = "BOOKS";
            lb_title.Text = "LIVRES";
            try
            {
                DataTable dt = new DataTable();
                dt = BLBOOKS.LOAD();
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "Séquence";
                dataGridView1.Columns[1].HeaderText = "Nom du Livre";
                dataGridView1.Columns[2].HeaderText = "AUTEUR";
                dataGridView1.Columns[3].HeaderText = "CATÉGORIE";
                dataGridView1.Columns[4].HeaderText = "PRIX";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnbooks2_Click(object sender, EventArgs e)
        {
            P_HOME.Visible = false;
            P_MAIN.Visible = true;
            txt_search.Visible = true;
            State = "BOOKS";
            lb_title.Text = "LIVRES";
            try
            {
                DataTable dt = new DataTable();
                dt = BLBOOKS.LOAD();
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "Séquence";
                dataGridView1.Columns[1].HeaderText = "Nom du Livre";
                dataGridView1.Columns[2].HeaderText = "AUTEUR";
                dataGridView1.Columns[3].HeaderText = "CATÉGORIE";
                dataGridView1.Columns[4].HeaderText = "PRIX";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            //details book
            if (State == "BOOKS")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = BLBOOKS.LOADEDIT(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value));
                    object obj1 = dt.Rows[0]["TITLE"];
                    object obj2 = dt.Rows[0]["AUTEUR"];
                    object obj3 = dt.Rows[0]["CAT"];
                    object obj4 = dt.Rows[0]["PRICE"];
                    object obj5 = dt.Rows[0]["BDATE"];
                    object obj6 = dt.Rows[0]["RATE"];
                    object obj7 = dt.Rows[0]["COVER"];
                    PL.FRM_INFOBOOKS INFOBOOKS = new PL.FRM_INFOBOOKS();
                    INFOBOOKS.txt_title.Text = obj1.ToString();
                    INFOBOOKS.txt_auteur.Text = obj2.ToString();
                    INFOBOOKS.txt_cat.Text = obj3.ToString();
                    INFOBOOKS.txt_price.Text = obj4.ToString();
                    INFOBOOKS.txt_date.Value = (DateTime)obj5;
                    INFOBOOKS.txt_rate.Value = (int)obj6;
                    //load image
                    byte[] ob = (byte[])obj7;
                    MemoryStream ma = new MemoryStream(ob);
                    INFOBOOKS.cover.Image = Image.FromStream(ma);
                    bunifuTransition1.ShowSync(INFOBOOKS);
                }
                catch { }
            }
            //details etudiant
            else if (State == "ST")
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = BLST.LOADEDIT(Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value));
                    object obj1 = dt.Rows[0]["NAME"];
                    object obj2 = dt.Rows[0]["ADRESSE"];
                    object obj3 = dt.Rows[0]["PHONE"];
                    object obj4 = dt.Rows[0]["EMAIL"];
                    object obj5 = dt.Rows[0]["SCHOOL"];
                    object obj6 = dt.Rows[0]["FILIERE"];
                    object obj7 = dt.Rows[0]["COVER"];
                    PL.FRM_INFOST INFOST = new PL.FRM_INFOST();
                    INFOST.txt_name.Text = obj1.ToString();
                    INFOST.txt_adresse.Text = obj2.ToString();
                    INFOST.txt_phone.Text = obj3.ToString();
                    INFOST.txt_email.Text = obj4.ToString();
                    INFOST.txt_school.Text = obj5.ToString();
                    INFOST.txt_filiere.Text = obj6.ToString();
                    //load image
                    byte[] ob = (byte[])obj7;
                    MemoryStream ma = new MemoryStream(ob);
                    INFOST.cover.Image = Image.FromStream(ma);
                    bunifuTransition1.ShowSync(INFOST);
                }
                catch { }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            P_HOME.Visible = false;
            P_MAIN.Visible = true;
            txt_search.Visible = true;
            State = "ST";
            lb_title.Text = "ÉTUDIANTS";
            try
            {
                DataTable dt = new DataTable();
                dt = BLST.LOAD();
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "Séquence";
                dataGridView1.Columns[1].HeaderText = "NOM DE L'ÉTUDIANT";
                dataGridView1.Columns[2].HeaderText = "ADRESSE";
                dataGridView1.Columns[3].HeaderText = "NUMÉRO DE TÉLÉPHONE";
                dataGridView1.Columns[4].HeaderText = "EMAIL";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            P_HOME.Visible = false;
            P_MAIN.Visible = true;
            txt_search.Visible = true;
            State = "ST";
            lb_title.Text = "ÉTUDIANTS";
            try
            {
                DataTable dt = new DataTable();
                dt = BLST.LOAD();
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "Séquence";
                dataGridView1.Columns[1].HeaderText = "NOM DE L'ÉTUDIANT";
                dataGridView1.Columns[2].HeaderText = "ADRESSE";
                dataGridView1.Columns[3].HeaderText = "NUMÉRO DE TÉLÉPHONE";
                dataGridView1.Columns[4].HeaderText = "EMAIL";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            P_HOME.Visible = false;
            P_MAIN.Visible = true;
            txt_search.Visible = true;
            State = "SELL";
            lb_title.Text = "VENTES";
            try
            {
                DataTable dt = new DataTable();
                dt = BLSELL.LOAD();
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "Séquence";
                dataGridView1.Columns[1].HeaderText = "Nom du Livre";
                dataGridView1.Columns[2].HeaderText = "ACHETEUR";
                dataGridView1.Columns[3].HeaderText = "PRIX";
                dataGridView1.Columns[4].HeaderText = "DATE";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            P_HOME.Visible = false;
            P_MAIN.Visible = true;
            txt_search.Visible = true;
            State = "SELL";
            lb_title.Text = "VENTES";
            try
            {
                DataTable dt = new DataTable();
                dt = BLSELL.LOAD();
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "Séquence";
                dataGridView1.Columns[1].HeaderText = "Nom du Livre";
                dataGridView1.Columns[2].HeaderText = "ACHETEUR";
                dataGridView1.Columns[3].HeaderText = "PRIX";
                dataGridView1.Columns[4].HeaderText = "DATE";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            P_HOME.Visible = false;
            P_MAIN.Visible = true;
            txt_search.Visible = true;
            State = "EMP";
            lb_title.Text = "EMPRUNTS";
            try
            {
                DataTable dt = new DataTable();
                dt = BLEMP.LOAD();
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "Séquence";
                dataGridView1.Columns[1].HeaderText = "Nom d'Emprenteur";
                dataGridView1.Columns[2].HeaderText = "Nom du Livre";
                dataGridView1.Columns[3].HeaderText = "Début de l'Emprunt";
                dataGridView1.Columns[4].HeaderText = "Fin de l'Emprunt";
                dataGridView1.Columns[5].HeaderText = "PRIX";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            P_HOME.Visible = false;
            P_MAIN.Visible = true;
            txt_search.Visible = true;
            State = "EMP";
            lb_title.Text = "EMPRUNTS";
            try
            {
                DataTable dt = new DataTable();
                dt = BLEMP.LOAD();
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "Séquence";
                dataGridView1.Columns[1].HeaderText = "Nom d'Emprenteur";
                dataGridView1.Columns[2].HeaderText = "Nom du Livre";
                dataGridView1.Columns[3].HeaderText = "Début de l'Emprunt";
                dataGridView1.Columns[4].HeaderText = "Fin de l'Emprunt";
                dataGridView1.Columns[5].HeaderText = "PRIX";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            P_HOME.Visible = false;
            P_MAIN.Visible = true;
            txt_search.Visible = false;
            State = "USER";
            lb_title.Text = "UTILISATEURS";
            try
            {
                DataTable dt = new DataTable();
                dt = BLUSER.LOAD();
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "Séquence";
                dataGridView1.Columns[1].HeaderText = "Nom Complet";
                dataGridView1.Columns[2].HeaderText = "Identifiant";
                dataGridView1.Columns[3].HeaderText = "Mot De Passe";
                dataGridView1.Columns[4].HeaderText = "Permission";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            P_HOME.Visible = false;
            P_MAIN.Visible = true;
            txt_search.Visible = false;
            State = "USER";
            lb_title.Text = "UTILISATEURS";
            try
            {
                DataTable dt = new DataTable();
                dt = BLUSER.LOAD();
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "Séquence";
                dataGridView1.Columns[1].HeaderText = "Nom Complet";
                dataGridView1.Columns[2].HeaderText = "Identifiant";
                dataGridView1.Columns[3].HeaderText = "Mot De Passe";
                dataGridView1.Columns[4].HeaderText = "Permission";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            P_HOME.Visible = true;
            P_MAIN.Visible = false;
            lb_title.Text = "BIBLORDO";
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            PL.FRM_LOGIN LOGIN = new PL.FRM_LOGIN();
            BLUSER.Logout();
            this.Hide();
            LOGIN.Show();
        }

        private void lb_title_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            P_HOME.Visible = true;
            P_MAIN.Visible = false;
            lb_title.Text = "BIBLORDO";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //ajoute categorie
            
                PL.FRM_ADDCAT FCAT = new FRM_ADDCAT();
                FCAT.btnadd.ButtonText = "AJOUTER";
                FCAT.ID = 0;
                bunifuTransition1.ShowSync(FCAT);

            
        }

        private void button16_Click(object sender, EventArgs e)
        {
            
                //ajoute EMPRUNT
                PL.FRM_ADDSEMP FEMP = new FRM_ADDSEMP();
                FEMP.btnadd.ButtonText = "AJOUTER";
                FEMP.ID = 0;
                bunifuTransition1.ShowSync(FEMP);

            
        }

        private void button17_Click(object sender, EventArgs e)
        {
            
                //ajoute VENTE
                PL.FRM_ADDSELL FSELL = new FRM_ADDSELL();
                FSELL.btnadd.ButtonText = "AJOUTER";
                FSELL.ID = 0;
                bunifuTransition1.ShowSync(FSELL);

        }

        private void button18_Click(object sender, EventArgs e)
        {
            
                //ajoute etudiant
                PL.FRM_ADDSTUDENTS FST = new FRM_ADDSTUDENTS();
                FST.btnadd.ButtonText = "AJOUTER";
                FST.ID = 0;
                bunifuTransition1.ShowSync(FST);

            
        }

        private void button19_Click(object sender, EventArgs e)
        {
              PL.FRM_ADDBOOKS FBOOKS = new FRM_ADDBOOKS();
                FBOOKS.btnadd.ButtonText = "AJOUTER";
                FBOOKS.ID = 0;
                bunifuTransition1.ShowSync(FBOOKS);


        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            PL.FRM_REPORT REPORT = new FRM_REPORT();
            REPORT.Show();
        }
    }
    
}