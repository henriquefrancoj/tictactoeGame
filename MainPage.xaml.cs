namespace MauiJogoDaVelha
{
    public partial class MainPage : ContentPage
    {
        string vez = "X"; // variavel que controla a vez do jogador

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            btn.IsEnabled = false; // Desabilita o botão após ser clicado
            btn.Text = vez; // Coloca o símbolo do jogador atual dentro do botão

            if(Venceu(vez))
            {
                await DisplayAlertAsync("Fim de jogo", "O jogador " + vez + " ganhou!", "OK");
                Zerar();
                vez = "X"; // Reinicia a vez para o jogador X após o término
                lblVez.Text = "Vez do jogador " + vez;
                return;
            }

            Button[] botoes = { btn10, btn11, btn12, btn20, btn21, btn22, btn30, btn31, btn32 };
            bool velha = true; // variável pra verificar se deu velha(empate)

            foreach (Button b in botoes)
            {
                if(b.IsEnabled)
                {
                    velha = false; // se ainda houver algum botão habilitado, não deu velha
                    break;
                }
            }

            if (velha)
            {
                await DisplayAlertAsync("Fim de jogo", "Deu velha!", "OK");
                Zerar();
                vez = "X";
                lblVez.Text = "Vez do jogador " + vez;
                return;
            }
            // Muda a vez para outro jogador
            if (vez == "X")
                vez = "O"; 
            else
                vez = "X";

            lblVez.Text = "Vez do jogador: " + vez;
        }

        bool Venceu(string jogador)
        {
            // linhas horizontais
            if (btn10.Text == jogador && btn11.Text == jogador && btn12.Text == jogador) return true;
            if (btn20.Text == jogador && btn21.Text == jogador && btn22.Text == jogador) return true;
            if (btn30.Text == jogador && btn31.Text == jogador && btn32.Text == jogador) return true;

            // linhas verticais
            if (btn10.Text == jogador && btn20.Text == jogador && btn30.Text == jogador) return true;
            if (btn11.Text == jogador && btn21.Text == jogador && btn31.Text == jogador) return true;
            if (btn12.Text == jogador && btn22.Text == jogador && btn32.Text == jogador) return true;

            // linhas diagonais
            if (btn10.Text == jogador && btn21.Text == jogador && btn32.Text == jogador) return true;
            if (btn12.Text == jogador && btn21.Text == jogador && btn30.Text == jogador) return true;

            return false;
        }

        void Zerar()
        {
            Button[] botoes = { btn10, btn11, btn12, btn20, btn21, btn22, btn30, btn31, btn32 };

            foreach (Button b in botoes)
            {
                b.Text = "";
                b.IsEnabled = true; // habilita o botão novamente para ser clicado
            }
        }
        private void Reiniciar_Clicked(object sender, EventArgs e)
        {
            Zerar();
            vez = "X";
            lblVez.Text = "Vez do jogador X";
        }
    }
}
