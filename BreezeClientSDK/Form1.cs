﻿using System;
using System.Reflection;

namespace BreezeClientSDK
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
  
        public Form1()
        {
            InitializeComponent();
            //configsdk();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarajustes();
        }


        public void cargarajustes()
        {
            metroLabel4.Text = String.Format("Version {0}", AssemblyVersion);
            bool rememberme;
            bool checktls;
            string extension;
            string pass;
            string sip;
            string domain;
            int port;


            rememberme = Properties.Settings.Default.remember;
            checktls = Properties.Settings.Default.tls;

            if (rememberme == true)
            {
                extension = Properties.Settings.Default.usuario;
                pass = Properties.Settings.Default.password;
                user_txt.Text = extension;
                pass_txt.Text = pass;

            }
            else
            {
                Console.WriteLine("Sin guardar datos");
               
            }
            sip = Properties.Settings.Default.sipcontroller;
            domain = Properties.Settings.Default.sipdomain;
            port = Int32.Parse(Properties.Settings.Default.puerto);

            sip_txt.Text = sip;
            domain_txt.Text = domain;
            puerto_txt.Text = port.ToString();
            if (checktls == true)
            {
                tls_chk.Checked = true;
            }
            else
            {
                tls_chk.Checked = false;
            }

        }

        public void guardarajustes()
        {
            Properties.Settings.Default.sipcontroller = sip_txt.Text;
            Properties.Settings.Default.sipdomain = domain_txt.Text;
            Properties.Settings.Default.puerto = puerto_txt.Text;
            Properties.Settings.Default.tls = tls_chk.Checked;
            Properties.Settings.Default.Save();

        }


        private void login_btn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.usuario = user_txt.Text;
            Properties.Settings.Default.password = pass_txt.Text;
            Properties.Settings.Default.remember = remember_chk.Checked;
            Properties.Settings.Default.Save();
            Main form = new Main();
            form.Show(); // or form.ShowDialog(this);

        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            guardarajustes();
        }


        //Metodos

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        //



    }
}
