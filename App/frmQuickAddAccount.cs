﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace App
{
    public partial class frmQuickAddAccount : Form
    {
        public delegate void TaiKhoanAddedEventHandler(string tenDangNhap);
        public event TaiKhoanAddedEventHandler OnTaiKhoanAdded;

        private TaiKhoanBUS taiKhoanBUS;
        public frmQuickAddAccount()
        {
            InitializeComponent();
            taiKhoanBUS = new TaiKhoanBUS();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            TaiKhoanDTO newAccount = new TaiKhoanDTO
            {
                TenDangNhap = txtTenDangNhap.Text.Trim(),
                MatKhau = txtMatKhau.Text.Trim(),
                VaiTro = cboVaiTro.Text,
                KichHoat = chkKichHoat.Checked
            };

            if (taiKhoanBUS.ThemTaiKhoan(newAccount))
            {
                MessageBox.Show("Thêm tài khoản thành công!");
                OnTaiKhoanAdded?.Invoke(newAccount.TenDangNhap);

                this.Close(); // Đóng form
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại!");
            }

        }

        private void cboVaiTro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmQuickAddAccount_Load(object sender, EventArgs e)
        {
            cboVaiTro.Items.Add("Admin");
            cboVaiTro.Items.Add("Kho");
            cboVaiTro.Items.Add("BanHang");
            cboVaiTro.SelectedIndex = 0;
        }
    }
}
