namespace CET107_Projeto_8_IMC
{
    [Activity(Label = "@string/app_name2", 
        Theme ="@style/AppTheme",
        Icon ="@mipmap/appicon",
        MainLauncher = true)]
    public class MainActivity : Activity
    {
        //atributos ou variáveis 

        //Entradas
        EditText etPesoC, etAlturaC;

        //Saídas
        EditText etIMCC;

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            etPesoC = FindViewById<EditText>(Resource.Id.etPeso);
            etAlturaC = FindViewById<EditText>(Resource.Id.etAltura);
            etIMCC = FindViewById<EditText>(Resource.Id.etIMC);
            Button btCalcularC = FindViewById<Button>(Resource.Id.btCalcular);
            Button btLimparC = FindViewById<Button>(Resource.Id.btLimpar);

            btCalcularC.Click += delegate
            {
                if(!string.IsNullOrEmpty(etPesoC.Text) && !string.IsNullOrEmpty(etAlturaC.Text))
                {
                    double peso = 0, altura = 0, imc = 0;

                    bool pesoValido = double.TryParse(etPesoC.Text,
                        System.Globalization.NumberStyles.Float,
                        System.Globalization.CultureInfo.InvariantCulture,
                        out peso);

                    bool alturaValida = double.TryParse(etAlturaC.Text,
                    System.Globalization.NumberStyles.Float,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out altura);

                    if(pesoValido && alturaValida)
                    {
                        if(altura != 0)
                        {
                            if(peso > 0 && altura > 0)
                            {
                                //imc = peso / (altura * altura);
                                imc = peso / Math.Pow(altura, 2);
                                etIMCC.Text = imc.ToString("F2",
                                    System.Globalization.CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                string mensagem = "Peso e altura devem ser valores positivos.";
                                if(peso < 0 && altura < 0)
                                {
                                    mensagem = "Peso e altura devem ser valores positivos.";
                                }
                                else if(peso < 0)
                                {
                                    mensagem = "Peso deve ser um valor positivo.";
                                }
                                else if(altura < 0)
                                {
                                    mensagem = "Altura deve ser um valor positivo.";
                                }

                                Toast.MakeText(this, mensagem, ToastLength.Long).Show();
                                etIMCC.Text = "Valores inválidos!";
                            }
                        }
                        else
                        {
                            Toast.MakeText(this, "Altura não pode ser zero.", ToastLength.Long).Show();
                            etIMCC.Text = "Erro: Altura zero.";
                        }
                    }
                    else
                    {
                        string mensagem = "Valores numéricos inválidos para peso e/ou altura.";
                        if(!pesoValido && !alturaValida)
                        {
                            mensagem = "Valores numéricos inválidos para peso e/ou altura.";
                        }
                        else if (!pesoValido)
                        {
                            mensagem = "Valor numérico inválido para peso.";
                        }
                        else if (!alturaValida)
                        {
                            mensagem = "Valor numérico inválido para altura.";
                        }

                        Toast.MakeText(this, mensagem,ToastLength.Long).Show();
                        etIMCC.Text = "Valores inválidos!";
                    }
                }
                else
                {
                    string mensagem = "Por favor preencha todos os campos.";

                    if(string.IsNullOrEmpty(etPesoC.Text) && string.IsNullOrEmpty(etAlturaC.Text))
                    {
                        mensagem = "Por favor preencha os campos de peso e altura.";
                    }
                    else if (string.IsNullOrEmpty(etPesoC.Text))
                    {
                        mensagem = "Por favor, preencha o campo de peso.";
                    }
                    else if(string.IsNullOrEmpty(etAlturaC.Text))
                    {
                        mensagem = "Por favor, preencha o campo de altura.";
                    }

                    Toast.MakeText(this,mensagem, ToastLength.Long).Show();
                    etIMCC.Text = "Sem valores!";

                }
            };

            btLimparC.Click += delegate
            {
                etPesoC.Text = string.Empty;
                etAlturaC.Text = string.Empty;
                etIMCC.Text = string.Empty;
            };
                    
        }
    }
}