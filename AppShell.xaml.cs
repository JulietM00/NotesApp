namespace NotesApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(Views.Notes), typeof(Views.Notes));
    }
}
