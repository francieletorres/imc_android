namespace CET107_Projeto_8_IMC
{
    [Activity(Label = "@string/app_name2", 
        Theme ="@style/AppTheme",
        Icon ="@mipmap/appicon",
        MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
        }
    }
}