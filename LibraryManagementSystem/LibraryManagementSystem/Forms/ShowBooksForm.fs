module Forms.ShowBooksForm

open System
open System.Drawing
open System.Windows.Forms
open CoreFunctions

type ShowBooksForm() as this = 
    inherit Form()

    let dataGridView = new DataGridView(
        Dock = DockStyle.Fill, 
        AllowUserToAddRows = false, 
        ReadOnly = true, 
        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    )

    // Define the columns
    let addColumns() =
        dataGridView.Columns.Add(new DataGridViewTextBoxColumn(HeaderText = "Title", Name = "Title")) |> ignore
        dataGridView.Columns.Add(new DataGridViewTextBoxColumn(HeaderText = "Author", Name = "Author")) |> ignore
        dataGridView.Columns.Add(new DataGridViewTextBoxColumn(HeaderText = "Genre", Name = "Genre")) |> ignore
        dataGridView.Columns.Add(new DataGridViewTextBoxColumn(HeaderText = "Availability", Name = "Availability")) |> ignore

    // Populate the grid with book data
    let populateGrid() =
        dataGridView.Rows.Clear()
        let books = CoreFunctions.getAllBooksWithAvailability() // Get book data from CoreFunctions
        for (title, author, genre, availability) in books do
            dataGridView.Rows.Add(title, author, genre, availability) |> ignore

    do
        // Initialize form properties
        this.Text <- "Books List"
        this.Size <- Size(800, 400)
        this.StartPosition <- FormStartPosition.CenterScreen

        // Add columns and populate the grid
        addColumns()
        this.Controls.Add(dataGridView)
        populateGrid()
