using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using System;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Popups;

namespace primeiro_app
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            Grid_all.CornerRadius = new CornerRadius(15);
            horario();
            async void horario()
            {
                while (true)
                {
                    await Task.Delay(1000);

                    string horario_atual = DateTime.Now.ToString("HH:mm:ss");
                    TextBox_horario.Text = horario_atual;
                    string[] array_horario = horario_atual.Split(":");
                    int hora = Convert.ToInt16(array_horario[0]);
                    if (hora > 0 && hora < 11)
                    {
                        TextBox_mensagem.Text = "Bom dia Usuário!";
                        estiliza_fundo("manha");
                    }
                    else if (hora < 19)
                    {
                        TextBox_mensagem.Text = "Boa tarde Usuário!";
                        estiliza_fundo("tarde");
                    }
                    else
                    {
                        TextBox_mensagem.Text = "Boa noite usuário!";
                        estiliza_fundo("noite");
                    }
                }
            }

            void estiliza_fundo(string periodo)
            {
                GradientStop primeira_cor = new GradientStop();
                GradientStop segunda_cor = new GradientStop();
                switch (periodo)
                {
                    case "manha":
                        primeira_cor.Color = Colors.LightSkyBlue;
                        segunda_cor.Color = Colors.CadetBlue;
                        break;
                    case "tarde":
                        primeira_cor.Color = Colors.OrangeRed;
                        segunda_cor.Color = Colors.Red;  
                        break;
                    case "noite":
                        primeira_cor.Color = Colors.RoyalBlue;
                        segunda_cor.Color = Colors.MediumPurple;
                        break;
                }
                primeira_cor.Offset = 0.48;
                segunda_cor.Offset = 0.55;

                LinearGradientBrush degrade = new LinearGradientBrush();
                degrade.StartPoint = new Point(0,0);
                degrade.EndPoint = new Point(1, 1);
                degrade.GradientStops.Add(primeira_cor);
                degrade.GradientStops.Add(segunda_cor);
                Fundo_app.Fill = degrade;
            }
        }
    }
}
