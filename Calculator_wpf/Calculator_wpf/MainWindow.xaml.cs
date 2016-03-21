using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace Calculator_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Parameters Values = new Parameters();

        List<Calc_Values> val_element = new List<Calc_Values>();

        List<double> _valor = new List<double>();
        List<String> _vencimento = new List<String>();
        List<double> _acumulador = new List<double>();

        List<double> val = new List<double>();
        List<String> venc = new List<String>();
        List<double> acc = new List<double>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Values.val_parcela = Convert.ToDouble(textBox.Text);
            Values.juros = Convert.ToDouble(textBox1.Text);
            Values.dia_venc = Convert.ToInt16(textBox2.Text);
            
            Values.quitacao = Convert.ToDateTime(datePicker.Text);
            Values.quant_parcelas = Convert.ToInt16(textBox4.Text);
            val_element.Clear();
            val.Clear();
            venc.Clear();
            acc.Clear();
            listView.Items.Clear();
            this._calcular();           
        }

        public void _calcular()
        {
            DateTime today = Values.quitacao;


            int dia = today.Day;
            int mes = today.Month;
            int ano = today.Year;

            double valor = Values.val_parcela;
            double acumulado = 0;
            double val0 = 0;
            double val1 = 1;

            DateTime _vencimento = DateTime.Today;

            Calc_Values _data;

            if(dia > Values.dia_venc)
            {
                mes = mes + 1;
                if (mes == 12)
                {
                    mes = 1;
                    ano = ano + 1;
                }
            }

            for(int i =0; i<Values.quant_parcelas;i++)
            {
                _data = new Calc_Values();

                String vencimento = Values.dia_venc + "/" + mes + "/" + ano;
                
                try
                {
                    _vencimento = DateTime.Parse(vencimento);
                    _data.vencimento = _vencimento.ToShortDateString();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Parse Excetion", e);
                }

                _data.vencimento = _vencimento.ToShortDateString();

                double dias = (_vencimento - Values.quitacao).TotalDays;

                val0 = Math.Pow((1.0 + Values.juros / 100.0), 1.0 / 30.0);
                val1 = Math.Pow(val0, dias);
                valor = Values.val_parcela / val1;

                _data.valor = Math.Round(valor * 100.0) / 100.0;

                acumulado = acumulado + valor;
                _data.acumulador = Math.Round(acumulado * 100.0) / 100.0;



                mes++;
                if(mes == 12)
                {
                    mes = 0;
                    ano = ano + 1;
                }

                val_element.Add(_data);

            }
            this.format_Values();
        }

        public void format_Values()
        {
            int sz = val_element.Count();            

            for (int i =0; i< sz; i++)
            {
                val.Add(val_element[i].valor);
                venc.Add(val_element[i].vencimento);
                acc.Add(val_element[i].acumulador);
            }
            this.update_listBox();
        }
        public void update_listBox()
        {
            int sz = val.Count();
            for(int i=0; i< sz;i++)
            {
                listView.Items.Add(new Calc_Values() { vencimento = venc[i], valor = val[i], acumulador = acc[i] });
            }
        }
        //-------------------------------------------------------------------------------------------------//
        //--------------------------------------Validação das textBox--------------------------------------//
        //-------------------------------------------------------------------------------------------------//

        private void textBox_TextChanged(object sender, TextChangedEventArgs e) //valor da parcela
        {
            string input = (sender as TextBox).Text; //1234567

            if (!Regex.IsMatch(input, @"^\s*-?[0-9]{1,10}\s*$") )
            {
                //MessageBox.Show("Erro, somente numeros!");
                if(textBox.Text.Length == 0)
                {
                    textBox.Text = textBox.Text.Substring(0, textBox.Text.Length);
                }
                else
                {
                    textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
                    textBox.SelectionStart = textBox.Text.Length;
                }              
            }
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e) //taxa de juros
        {
            string input = (sender as TextBox).Text; //1234567

            if (!Regex.IsMatch(input, @"^\s*-?[0-9]{1,2}\s*$"))
            {
                //MessageBox.Show("Erro, somente numeros!");
                if (textBox1.Text.Length == 0)
                {
                    textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length);
                }
                else
                {
                    textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                    textBox1.SelectionStart = textBox1.Text.Length;
                }
            }
        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e) //dia do vencimento
        {
            string input = (sender as TextBox).Text; //1234567

            if (!Regex.IsMatch(input, @"^\s*-?[0-9]{1,2}\s*$"))
            {
                //MessageBox.Show("Erro, somente numeros!");
                if (textBox2.Text.Length == 0)
                {
                    textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length);
                }
                else
                {
                    textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1);
                    textBox2.SelectionStart = textBox2.Text.Length;
                }
            }
        }

        private void textBox4_TextChanged(object sender, TextChangedEventArgs e) //quantidade de parcelas
        {
            string input = (sender as TextBox).Text; //1234567

            if (!Regex.IsMatch(input, @"^\s*-?[0-9]{1,3}\s*$"))
            {
                //MessageBox.Show("Erro, somente numeros!");
                if (textBox4.Text.Length == 0)
                {
                    textBox4.Text = textBox4.Text.Substring(0, textBox4.Text.Length);
                }
                else
                {
                    textBox4.Text = textBox4.Text.Substring(0, textBox4.Text.Length - 1);
                    textBox4.SelectionStart = textBox4.Text.Length;
                }
            }
        }

    }
}
