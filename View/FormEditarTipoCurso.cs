﻿using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class FormEditarTipoCurso : Form
    {
        MTipoCurso Item;
        public bool Salvou = false;

        public FormEditarTipoCurso(MTipoCurso item)
        {
            Item = item;
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool erro = false;

            if (txtNome.Text.Trim() == "")
            {
                errorProvider1.SetError(txtNome, Erros.TipoCursoNome);
                erro = true;
            }

            if (erro == false)
            {
                Item.Nome = txtNome.Text.Trim();

                try
                {
                    CTipoCurso.Atualizar(Item);
                    MessageBox.Show("Cadastro atualizado com sucesso", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Salvou = true;
                    Close();
                }
                catch (ExcecaoPersonalizada ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show(Erros.ErroPadrao, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormEditarTipoCurso_Load(object sender, EventArgs e)
        {
            Item = CTipoCurso.Obter(Item);
            txtNome.Text = Item.Nome;
        }
    }
}
