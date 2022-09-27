using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aula6Katia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string numero = "";
        Candidato alguem;
        Candidato[] lista = new Candidato[4];
        int branco = 0, nulo = 0, eleitores =0;

        private void inserCandidato()
        {
            alguem = new Candidato();
            alguem.Numero = 12;
            alguem.Nome = "Ana";
            alguem.Turma = "1° ADS";
            alguem.Foto = "Ana.jpg";
            lista[0] = alguem;

            alguem = new Candidato();
            alguem.Numero = 23;
            alguem.Nome = "Joana Lima";
            alguem.Turma = "1° ADS";
            alguem.Foto = "joana.jpg";
            lista[1] = alguem;

            alguem = new Candidato();
            alguem.Numero = 34;
            alguem.Nome = "Antonio Silva";
            alguem.Turma = "1° ADS";
            alguem.Foto = "antonio.jpg";
            lista[2] = alguem;

            alguem = new Candidato();
            alguem.Numero = 45;
            alguem.Nome = "Vivian";
            alguem.Turma = "1° ADS";
            alguem.Foto = "vivian.jpg";
            lista[3] = alguem;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            txtNum1.Enabled = false; //desabilita o campo de texto 
            txtNum2.Enabled = false;
            btnConfirma.Enabled = false; // desabilita o botão Confirma 
            lblMensagem.Visible = false; //Panel ocultada
            inserCandidato();
        }

        private void bta1_Click(object sender, EventArgs e)
        {
            tecla();
            Preenche("1");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            tecla();
            Preenche("8");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            tecla();
            Preenche("6");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            tecla();
            Preenche("9");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            tecla();
            Preenche("4");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            tecla();
            Preenche("0");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            tecla();
            Preenche("3");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            tecla();
            Preenche("2");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            tecla();
            Preenche("5");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            tecla();
            Preenche("7");
        }

        private void tecla()
        {
            SoundPlayer som = new SoundPlayer(@"");
            som.Play();
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {

            SoundPlayer som = new SoundPlayer(@"");
            som.Play();
            int valido = 0;
            for (int i = 0; i < 4; i++)
            {   if (numero == "Branco")
                {
                    branco++;
                    valido = 1;
                }
                else
                {
                    if (int.Parse(numero) == lista[i].Numero)
                    {
                        lista[i].Voto++;
                        valido = 1;
                    }
                }
            }
                if(valido == 0)
                {  
                   nulo++;
                }
                eleitores++;
                corrige();
                if(eleitores ==9)
                {
                    string texto = "Nulo=" + nulo + "\nBranco" + branco; //concate nulo e braco
                    for(int i = 0; i < 4; i++)
                    {
                        texto+= "\n" + lista[i].Nome + "-" + lista[i].Voto; //concatena nome e voto candidato
                    }
                    MessageBox.Show(texto);
            }
        }
    

        private void btnBranco_Click(object sender, EventArgs e)
        {
            tecla();
            numero="branco";
            lblMensagem.Visible = true;
            btnConfirma.Enabled = true;
            lblCandidato.Text="VOTO EM BRANCO";
        }

        private void corrige()
        {

            txtNum1.Text = null;
            txtNum2.Text = null;
            lblCandidato.Text = null;
            lblTurma.Text = null;
            lblMensagem.Visible=false;
            btnConfirma.Enabled = false;
            numero = "";
            pxFoto.Image = null;
        }

        private void Preenche(string n)
        {
            if (numero.Length == 0)
            {
                txtNum1.Text = n;
                numero += n;//numero=numero+n
            }
            else
            {
                txtNum2.Text = n;
                numero += n;//numero=numero+n
                for(int i= 0; i < 4; i++)
                {
                    if(int.Parse(numero) == lista[i].Numero)
                    {
                        lblCandidato.Text = lista[i].Nome;
                        lblTurma.Text = lista[i].Turma;
                        pxFoto.Image = Image.FromFile(@"C:\Users\aluno\Pictures\Candidatos\" + lista[i].Foto);
                        lista[i].Voto += 1;
                        i = 3;
                    }
                    else
                    {
                        lblCandidato.Text = "VOTO NULO";
                    }
                    lblMensagem.Visible = true;
                    btnConfirma.Enabled = true;
                }
            }
        }

    }
}
