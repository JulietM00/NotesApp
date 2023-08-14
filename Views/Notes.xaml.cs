namespace NotesApp.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]

public partial class Notes : ContentPage
{
    string _FileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");


    public Notes()
	{
		InitializeComponent();

        if (File.Exists(_FileName))
            TextEditor.Text = File.ReadAllText(_FileName);
        
        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));
    }

    public string ItemId
    {
        set { LoadNote(value); }
    }

    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Notes note)
            File.WriteAllText(note.Filename, TextEditor.Text);

        
        
    }

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Notes note)
        {
            // Delete the file.
            if (File.Exists(note.Filename))
                File.Delete(note.Filename);
        }

    }

    private void LoadNote(string fileName)
    {
        Models.Notes noteModel = new Models.Notes();
        noteModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            noteModel.Date = File.GetCreationTime(fileName);
            noteModel.Text = File.ReadAllText(fileName);
        }

        BindingContext = noteModel;
    }
}